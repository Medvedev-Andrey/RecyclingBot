using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace RecyclingBot
{
  public class Program
  {
    public static string Port
    {
      get
      {
        const string portVariableName = "PORT";
        string port = Environment.GetEnvironmentVariable(portVariableName);

        if (string.IsNullOrWhiteSpace(port))
        {
          Console.WriteLine("{0} is not set", portVariableName);
        }

        return port;
      }
    }

    public static void Main(string[] args)
    {
      new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .UseUrls($"http://*:{Port}")  
        //  We have to listen on port provided by Heroku
        .UseApplicationInsights()
        .Build()
        .Run();
    }    
  }
}
