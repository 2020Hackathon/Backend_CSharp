using ChwJjunJinDam.Interface;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ChwJjunJinDam
{
    class Server
    {
        static void Main(string[] args)
        {
            var server = new WebServiceHost(typeof(Services.ChwJjunJinDamService));
            server.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            server.Open();
            Console.Title = "ChwJjunJinDam Server";
            Console.WriteLine("ChwJjunJinDam Server Start");
            Console.WriteLine("If you want to exit this application, please push enter key.");
            Console.ReadLine();
            Console.WriteLine("ChwJjunJinDam Server Stop");
        }
    }
}
