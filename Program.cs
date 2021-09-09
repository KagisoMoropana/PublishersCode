using System;
using System.ServiceProcess;

namespace AuthorService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service=new FileWriteService())
            {
                ServiceBase.Run(service);
            }
        }
    }
}
