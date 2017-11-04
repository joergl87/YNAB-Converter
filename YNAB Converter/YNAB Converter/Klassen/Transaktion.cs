using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNAB_Converter.Klassen
{
    public class Transaktion
    {
        public string Date { get; set; }
        public string Payee { get; set; }
        public string Category { get; set; }
        public string Memo { get; set; }
        public string Outflow { get; set; }
        public string Inflow { get; set; }

        public Transaktion(string Date, string Payee, string Category, string Memo, string Outflow, string Inflow)
        {
            this.Date = Date;
            this.Payee = Payee;
            this.Category = Category;
            this.Memo = Memo;
            this.Outflow = Outflow;
            this.Inflow = Inflow;
        }

        public Transaktion()
        {

        }
    }
}
