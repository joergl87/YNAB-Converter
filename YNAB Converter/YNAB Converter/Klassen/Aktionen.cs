using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNAB_Converter.Klassen
{
    public static class Aktionen
    {
        public static List<string> Ergebnis_Auslesen(string Dateipfad)
        {
            List<string> result = new List<string>();
            string value;
            StreamReader reader;
            reader = new StreamReader(Dateipfad, Encoding.Default);

            using (TextReader fileReader = reader)
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.Encoding = Encoding.Unicode;

                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        result.Add(value);
                    }
                }
            }

            return result;
        }

        public static void Ergebnis_Speichern(string Outputpfad, List<Transaktion> Transaktionen)
        {
            using (TextWriter writer = new StreamWriter(Outputpfad))
            {
                var csv = new CsvWriter(writer);
                //csv.Configuration.Encoding = Encoding.Default;
                csv.WriteRecords(Transaktionen); // where values implements IEnumerable
            }
        }
    }
}
