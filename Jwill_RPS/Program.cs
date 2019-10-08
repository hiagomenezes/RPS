using System;
using System.IO;
using System.Text;
using Newtonsoft;

namespace Jwill_RPS
{

  class Program
    {
        static void Main(string[] args)
        {
            //Retorno API 
            var rpsApiString = File.ReadAllText(@"C:\Temp\input\rsp_retorno_api.json");
            RPS_Input rpsApi =  Newtonsoft.Json.JsonConvert.DeserializeObject<RPS_Input>(rpsApiString);
            //Retorno API 


            //formatando dados
            Header(rpsApi);
            Detail(rpsApi.notas);


            //transformar em texto
            var arqFinalString = CreateTXT(rpsApi);



            //salvar arquivo


            File.WriteAllText(@"C:\Temp\output\rps_output_malaco.txt", arqFinalString);


        }



        public static string CreateTXT(RPS_Input rps)
        {
            var rpsFile = new StringBuilder();

            //header
            rpsFile.AppendLine(string.Format("{0}{1}", rps.nome, rps.cnpj));


            foreach (var nota in rps.notas)
            {
                rpsFile.AppendLine(string.Format("{0}{1}", nota.numero, nota.valor));
            }


            return rpsFile.ToString();
        }


        public static void Header(RPS_Input rps)
        {
            rps.cnpj = string.Format("999.999.999", rps.cnpj);
        }


        public static void Detail(Nota[] notas)
        {
            foreach (var nota in notas)
            {
                nota.numero = string.Format("999999999", nota.numero);
                nota.valor = string.Format("R$99,99", nota.valor);
            }
        }



    }


    public class RPS_Input
    {
        public string cnpj { get; set; }
        public string nome { get; set; }
        public Nota[] notas { get; set; }
    }


    public class Nota
    {
        public string numero { get; set; }
        public string valor { get; set; }
    }


}
