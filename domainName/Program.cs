using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace domainName
{
    class Program
    {
        static void Main(string[] args)
        {
            string allText = "";

            using (var reader = new StreamReader(@"D:\User\Darbvisma\allNames.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    allText += line + "\n";
                }
            }
            string[] array = allText.Split('\n');
            
            Console.WriteLine("ALL AVAILABLE DOMAIN NAMES:\n");

            for (int i = 0; i < array.Length; i++)
            {
                if (!isURLExist("http://www." + array[i] + ".com"))
                {
                    Console.WriteLine(array[i]);
                }
                Debug.WriteLine(i);
            }

            Console.ReadLine();
        }

        public static bool isURLExist(string url)
        {
            bool exists = false;

            try
            {
                WebRequest req = WebRequest.Create(url);

                WebResponse res = req.GetResponse();


                exists = true;
            }
            catch (WebException ex)
            {
                if (ex.Message.Contains("remote name could not be resolved"))
                {
                    
                }
            }

            return exists;
        }
    }
}
