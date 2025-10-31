using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filetrycatch
{
    internal class Program
    {


        static void Main(string[] args)
        {
            List<Address> addresses = new List<Address>();
            string path = "/Users/utente/source/repos/Filetrycatch/addresses.csv";
           var stream = File.OpenText(path);
            int i = 0;
            while (stream.EndOfStream == false)
            {
                string line = stream.ReadLine();
                //Console.WriteLine(line);
                i++;
                if (i < 2)
                {
                    continue;
                }
                try { 
                var dates = line?.Split(',');
                    if (dates.Length < 6)
                    {
                        Console.WriteLine($"Riga non valida {i}: Dati mancanti");
                    }
                string name = dates[0];
                string surname = dates[1];
                string street = dates[2];
                string city = dates[3];
                string province = dates[4];
                int zip ;

                bool isValidZip = int.TryParse(dates[5], out zip);
                    if (!isValidZip)
                    {
                        Console.WriteLine($"CAP non valido alla riga: {i}");
                    }

                        Address address = new Address(name, surname, street, city, province, zip);
                addresses.Add(address);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Errore alla linea {i}: {e.Message}");
                    Console.WriteLine($"Contenuto della linea: {line}");
                }

            }
            foreach (var address in addresses)
            {
                Console.WriteLine(address.ToString());  
            }
            stream.Close();
        }
    } 
}
     