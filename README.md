#  Desafio Instituto CERTI Sapientia
# :page_with_curl: - HTTPServer

### Na linguagem de sua preferência, crie um servidor HTTP que, para cada requisição GET, retorne um JSON cuja chave extenso seja a versão por extenso do número inteiro enviado no path. Os números podem estar no intervalo [-99999, 99999].

>Exemplos:                          
> $curl http://localhost:3000/39321
>```json
>{
>  "extenso": "trinta e nove mil e trezentos e vinte e um"
>}

> $curl http://localhost:3000/-51011
>```json
>{
>  "extenso": "menos cinquenta e um mil e onze"
>}

> $curl http://localhost:3000/-01810
>```json
>{
> "extenso": "menos mil e oitocentos e dez"
>}

> $curl http://localhost:3000/-7a198
>```json
>{
>  "extenso": "Intervalo incorreto"
>}

## Executando

#### Passo 1
Baixe e execute o arquivo:
>:open_file_folder: [HttpServerProject.exe](https://github.com/Guithublherme/HTTPServer/blob/24_07_2021_CriandoProjetoHTTPServer/HttpServerProject/HttpServerProject/bin/Debug/netcoreapp3.1/HttpServerProject.exe)

#### Passo 2
Abra seu navegador e insira a url:
>:computer: http://localhost:3000/

Insira valores no intervalo de [-99999, 99999] para os devidos testes. 

## Principais Classes

São duas as classes utilizadas na construção desse desafio.

A primeira classe é [HttpServer.cs](https://github.com/Guithublherme/HTTPServer/blob/24_07_2021_CriandoProjetoHTTPServer/HttpServerProject/HttpServerProject/HttpServer.cs), onde é realizada a inicialização do server e a lógica de obtenção e de postagem das informações.

A segunda classe [numExtenso.cs](https://github.com/Guithublherme/HTTPServer/blob/24_07_2021_CriandoProjetoHTTPServer/HttpServerProject/HttpServerProject/numExtenso.cs), possui a lógica de conversão e da validação da string com o valor por extenso.

