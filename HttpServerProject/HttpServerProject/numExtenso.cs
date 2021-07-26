using System;
using System.Linq;

namespace HttpServerProject
{
    class numExtenso
    {
        string[]? unidade = new string[10] { "","um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
        string[]? dezena1 = new string[10] { "dez","onze","doze","treze","quatorze","quinze","dezesseis","dezessete","dezoito","dezenove"};
        string[]? dezena = new string[10] { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        string[]? centena = new string[10] { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

        public String ConverteCaminhoEmNumExtenso(string numString)
        {
           
            var numsCharVet = numString.ToCharArray();
            int quantCaracter = numString.Count(a => a == '-'); //conta quantos caracteres '-' possui
            var numsNegativo= numString.Replace('-','/').Substring(1); //caso negativo
            var numsCharVet2 = numsNegativo.ToCharArray();
            bool numNegativo = quantCaracter>1? false : (numsCharVet[1] == '-'? true: false); //caso tenha mais de um caracter '-' significa q está inválido, permanece false
            
            numsCharVet = numNegativo ? numsCharVet2: numsCharVet;
            numString = numNegativo ? numsNegativo : numString;
            
            if (numsCharVet.Length - 1 > 6 || contemNumeros(numString))
            {
                return "Intervalo incorreto";
            } 
            else
            {
                if(numsCharVet.Length - 1 == 6 && numsCharVet[1]!= '-' )
                    return "Intervalo incorreto";
                else
                {
                    int i = 0;
                    int[] ordenados = new int[numsCharVet.Length - 1];
                    for (int j = numsCharVet.Length - 1; j > 0; j--)
                    {
                        ordenados[i] = int.Parse(numsCharVet[j].ToString(), 0);
                        i++;
                    }


                    string uni  = ordenados.Length < 1 ? "" : ( ordenados[0]!=0) ? unidade[ordenados[0]]: "";
                    string dez = ordenados.Length < 2 ? "" : (ordenados[1] == 1) ? dezena1[ordenados[0]]  : dezena[ordenados[1]];
                    string cen = ordenados.Length < 3 ? "" : ((ordenados[0] == 0 && ordenados[1] == 0 && ordenados[2]==1)? "cem": centena[ordenados[2]]);
                    string uniMil = ordenados.Length < 4 ? "" : ((ordenados[3] == 1 ) ? "mil" : unidade[ordenados[3]] + " mil");
                    string dezMil = ordenados.Length < 5 ? "" : (ordenados[4] == 1) ? dezena1[ordenados[3]] + " mil" : dezena[ordenados[4]];


                    if (ordenados.Length > 1)
                    {
                        if (dez != "")
                        {
                            uni = ordenados[1] == 1 ? "" : uni;
                        }
                    }

                    if (ordenados.Length > 3)
                    {
                        if (ordenados[3] == 0)
                        {
                            uniMil = "";
                        }
                        if (dezMil == "")
                        {
                            uniMil = unidade[ordenados[3]] == "" ? "" : uniMil;
                        }
                    }
                    if (ordenados.Length > 4)
                    {
                        if (dezMil != "")
                        {
                            uniMil = ordenados[4] == 1 ? "" : uniMil;
                        }
                        if (ordenados[3] == 1 )
                        {
                            uniMil = unidade[ordenados[3]] + " mil";
                            if (ordenados[4] == 1)
                                uniMil = "";
                        }
                        if (ordenados[3] == 0 && ordenados[4] != 1 && ordenados[4] != 0)
                        {
                            uniMil = " mil";
                        }
                        if(ordenados[4] == 0 && ordenados[3] == 1)
                            uniMil = "mil";

                    }

                        string extenso = dezMil + " " + uniMil + " " + cen + " " +  dez + " " + uni;
                        

                    string[] extenso2 = extenso.Trim(' ').Split(' ');
                
                    string junta = "";
                    for (int l = 0; l < extenso2.Count(); l++)
                    {

                        if (l < extenso2.Count() - 1)
                            if (extenso2[l + 1] != "" && extenso2[l + 1] != "mil")
                                junta += extenso2[l].ToString() + " e ";
                            else
                            {
                                if(extenso2[l + 1] == "mil")
                                    junta += extenso2[l].ToString() + " ";
                                else
                                    junta += extenso2[l].ToString();
                            }

                        else
                            junta += extenso2[l].ToString();           
                       
                    }

                    junta = numNegativo ? "menos " + junta : junta;
                    
                    return junta;
                }

            }
        
        }

        public bool contemNumeros(string texto)
        {
            
            if (texto.Where(c => char.IsNumber(c)).Count() != texto.Length-1)
                return true;
            else
                return false;
        }



    }
}

