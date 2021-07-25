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

namespace HttpServerProject
{
	class HttpServer
	{
		static HttpListener _httpListener = new HttpListener();
		string url = "http://localhost:3000/";
		HttpClient client = new HttpClient();
		

		public static async Task Main(string[] args)
		{
			bool teste = true;
			Console.WriteLine("Starting server...");
			_httpListener.Prefixes.Add("http://localhost:3000/"); 
			_httpListener.Start(); 
			Console.WriteLine("Server started.");

			//Thread _responseThread = new Thread(ResponseThread);
			//_responseThread.Start();
			HttpServer programa = new HttpServer();
			await programa.ResponseThread();
			await programa.ObterJson();


		}
		public async Task ResponseThread()
		{

			while (true)
			{
				HttpListenerContext context = _httpListener.GetContext(); 
				byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 3000</title></head>" +
				"<body>Welcome to the <strong>Localhost server</strong> -- <em>port 3000!</em></body></html>"); // get the bytes to response
				context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); // write bytes to the output stream
				context.Response.KeepAlive = false; // set the KeepAlive bool to false
				var teste = context.Request.RawUrl.ToCharArray();
				context.Response.Close(); // close the connection
				Console.WriteLine("Uma resposta foi solicitada");
				Console.WriteLine(teste[1].ToString() + teste[2].ToString() + teste[3].ToString()) ;
					
				
			}
		}

		public async Task ObterJson()
        {
			client.BaseAddress = new Uri("http://localhost:3000/");
			
			//client.DefaultRequestHeaders.Accept.Clear();
			// HTTP GET
			var response2 = new HttpResponseMessage();
			HttpResponseMessage response = await client.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine(response2);
				Console.WriteLine("Deu certo");
			}
		}
	}


}
