using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Unicast;
using SignalR.Infrastructure;

namespace SignalR.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            RegisterBus();

            System.Console.WriteLine("Enter message and hit ENTER to send");

            while (true)
            {
                System.Console.Write("> ");
                var input = System.Console.ReadLine();

                Bus.Send(new Event1 {Msg = input});
            }
        }
        
        static IBus Bus { get; set; }


        static void RegisterBus()
        {
            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
            Bus = Configure.With()
                .DefaultBuilder()
                .Log4Net()
                .XmlSerializer()
                .MsmqTransport()
                .UnicastBus()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

        }
    }
}
