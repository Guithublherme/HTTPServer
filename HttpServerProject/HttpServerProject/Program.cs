using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

namespace HttpServerProject
{
	class HttpServer
	{
		static HttpListener _httpListener = new HttpListener();
		string url = "http://localhost:3000/";
		//HttpClient client = new HttpClient();
		numExtenso num = new numExtenso();

		public static async Task Main(string[] args)
		{

			Console.WriteLine("Starting server...");
			_httpListener.Prefixes.Add("http://localhost:3000/"); 
			_httpListener.Start(); 
			Console.WriteLine("Server started.");
			HttpServer programa = new HttpServer();
			await programa.ResponseThread();

		}
		public async Task ResponseThread()
		{

			while (true)
			{
				HttpListenerContext context = _httpListener.GetContext(); 
				context.Response.KeepAlive = false; 
				string pathUrl = context.Request.RawUrl.ToString();
				string pedacoCaminhoUrl = pathUrl.Length > 1? pathUrl[1].ToString():"";
				
				if (pedacoCaminhoUrl != "f" && pathUrl.Length > 1)
				{
					Console.WriteLine("Um caminho foi solicitado");
					string numPorExtenso = num.ConverteCaminhoEmNumExtenso(pathUrl);
					Console.WriteLine(numPorExtenso);
					//POST
					using (Stream stream = context.Response.OutputStream)
					{
						using (StreamWriter escreve = new StreamWriter(stream))
						{
							string str = "{ \"extenso\": \"" + numPorExtenso + "\" }";
							var json = JObject.Parse(str);
							var json2 = JsonConvert.SerializeObject(json);
							escreve.Write(json);
						}
					}
					context.Response.Close();



				}
			}	
		}

		//public async Task ObterJson()
  //      {
		//	client.BaseAddress = new Uri("http://localhost:3000/");
			
		//	var response2 = new HttpResponseMessage();
		//	HttpResponseMessage response = await client.GetAsync(url);
		//	if (response.IsSuccessStatusCode)
		//	{
		//		Console.WriteLine(response2);
		//		Console.WriteLine("Deu certo");
		//	}
		//}
	}


}
