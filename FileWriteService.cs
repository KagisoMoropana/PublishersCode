using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using NPOI.SS.UserModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;

namespace AuthorService
{
    public class FileWriteService:ServiceBase
    {
        public Thread Worker = null;
        
        public FileWriteService()
        {
            ServiceName = "MyAuthorService";
           
        }
        protected void OnStart(string[] args)
        {
            ThreadStart start = new ThreadStart(Working);
            Worker = new Thread(start);
            Worker.Start();
        }
        public void Working()
        {
            int nsleep = 60;
            try
            {
                while (true)
                {
                    string Filename = @"C:\GUID_" + DateTime.Now.ToString("yyMMddHHss") + ".csv";
                    using (StreamWriter writer = new StreamWriter(Filename, true))
                    {
                        string APIqueryString = "https://localhost/GetAuthors/1";
                        HttpClient client = new HttpClient();
                        var response = client.GetAsync(APIqueryString);

                        dynamic data = null;
                        if (response != null)
                        {
                            HttpResponseMessage json = client.GetAsync("api/GetAuthors/1").Result;
                            data = JsonConvert.DeserializeObject(json.ToString());
                        }
                        var csvFileLenth = new System.IO.FileInfo(Filename).Length;

                        if (data.IsSuccessStatusCode)
                        {

                            if (csvFileLenth == 0)
                            {
                                writer.WriteLine(string.Format("{0}://{1}/{2}", "Author ID", "Last Name", "First Name", "Phone Number",
                                                                "Address", "City", "State", "Zip", "Contract"));

                            }
                            else
                            {
                                foreach (var author in data)
                                {
                                    writer.WriteLine("{0}://{1}/{2}", author.au_id, author.au_lname, author.au_fname, author.phone, author.address, author.city,
                                                        author.state, author.zip, author.contract);
                                }
                                writer.Close();
                            }
                        }
                    }
                }
                Thread.Sleep(nsleep * 60 * 1000);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
