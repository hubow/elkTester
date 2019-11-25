using System;
using Serilog;
using System.Configuration;
using Serilog.Sinks.Network;

namespace serilogTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length<=0)
            {
                Console.WriteLine("Please specify host and port, e.g.: dotnet elkTester.dll localhost 5001");
            } else {            
                var host = args[0];
                var port = args[1];
                Console.WriteLine("Sending message to: " + args[0] + ":" + args[1]);

                var config = ConfigurationManager.AppSettings["app.config"];
                var log = new LoggerConfiguration()
                    // .ReadFrom.AppSettings(config)
                    .Enrich.WithProperty("type", "elk-testing")
                    .Enrich.WithProperty("hostname",  Environment.MachineName)
                    .WriteTo.TCPSink("tcp://" + args[0] + ":" + args[1])
                    .WriteTo.Console(outputTemplate: "[{Timestamp} [{Level}] {Message} {Exception} {Properties} {NewLine}")
                    .CreateLogger();
                log.Information("This is me testing ELK (Serilog.Sinks.Network)");
            }
        }
    }
}