using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hashconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new [] {0, 1, 2, 3, 4};
            var s = new Slice<int>(arr,3,2);
            Console.WriteLine(string.Join(",", s.ToArray()));
            Console.WriteLine(s.Length);

            for (var i = 0; i < s.Length; ++i)
                s[i] = -1*i;
            Console.WriteLine(string.Join(",", s.ToArray()));
            var mySerializer = new XmlSerializer(typeof(Slice<int>));

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // Insert code to set properties and fields of the object.  
           using (var ms = new MemoryStream())
            {
                // To write to a file, create a StreamWriter object.  
                mySerializer.Serialize(ms, s);
                var sha256 = SHA256.Create();
                var hashValue = sha256.ComputeHash(ms);
                Console.WriteLine(string.Join(",", hashValue));
                
            }
           /*
            byte[] bytes = Encoding.Unicode.GetBytes("sdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfffffffffffffsdfsdfsdfsdfsdfsdfsdfsdfsdfsdf");
            var sha256 = SHA256.Create();
            var hashValue = sha256.ComputeHash(bytes);
            Console.WriteLine(string.Join(",", hashValue));*/
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.Read();

        }
    }
}
