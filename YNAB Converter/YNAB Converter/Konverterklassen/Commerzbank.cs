using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNAB_Converter.Konverterklassen
{
    public class Commerzbank
    {
        public Commerzbank(string Dateipfad, string Outputpfad)
        {
            List<string> result = new List<string>();

            //Auslesen
            result = Klassen.Aktionen.Ergebnis_Auslesen(Dateipfad);

            //Entfernen der Spaltenüberschriften
            result.RemoveRange(0, 9);

            //Hinzufügen der YNAB Spalte zu Beginn
            List<Klassen.Transaktion> Transaktionen = new List<Klassen.Transaktion>();
            for (int i = 0; i < result.Count - 1; i++)
            {
                Klassen.Transaktion Transaktion = new Klassen.Transaktion();
                Transaktion.Date = result[i];
                if (result[i + 4].First() == '-')
                {
                    Transaktion.Outflow = result[i + 4].Replace("-","");
                }
                else
                {
                    Transaktion.Inflow = result[i + 4];
                }
                Transaktion.Category = "";
                Transaktion.Memo = result[i + 3];
                Transaktionen.Add(Transaktion);
                i += 8;
            }

            //Speichern
            Klassen.Aktionen.Ergebnis_Speichern(Outputpfad, Transaktionen);
        }
    }
}
