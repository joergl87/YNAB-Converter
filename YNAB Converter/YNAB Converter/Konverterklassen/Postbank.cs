using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNAB_Converter.Konverterklassen
{
    public class Postbank
    {
        public Postbank(string Dateipfad, string Outputpfad)
        {
            List<string> result = new List<string>();

            //Auslesen
            result = Klassen.Aktionen.Ergebnis_Auslesen(Dateipfad);

            //Entfernen der Spaltenüberschriften
            result.RemoveRange(0, 21);

            //Hinzufügen der YNAB Spalte zu Beginn
            List<Klassen.Transaktion> Transaktionen = new List<Klassen.Transaktion>();
            for (int i = 0; i < result.Count - 1; i++)
            {
                Klassen.Transaktion Transaktion = new Klassen.Transaktion();
                Transaktion.Date = result[i];
                if (result[i + 6].First() == '-')
                {
                    Transaktion.Payee = result[i + 5];
                }
                else
                {
                    Transaktion.Payee = result[i + 4];
                }
                Transaktion.Category = "";
                Transaktion.Memo = result[i + 3];
                if (result[i + 6].First() == '-')
                {
                    Transaktion.Outflow = result[i + 6].Replace("-", "");
                    Transaktion.Inflow = "";
                }
                else
                {
                    Transaktion.Inflow = result[i + 6];
                    Transaktion.Outflow = "";
                }
                Transaktionen.Add(Transaktion);
                i += 7;
            }

            //Speichern
            Klassen.Aktionen.Ergebnis_Speichern(Outputpfad, Transaktionen);
        }
    }
}
