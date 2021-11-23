using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_018_A.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdMenu { get; set; }
        public int? HargaMenu { get; set; }
        public string JumlahMenu { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
