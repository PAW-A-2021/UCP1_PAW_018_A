using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_018_A.Models
{
    public partial class Kasir
    {
        public Kasir()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdKasir { get; set; }
        public string UsernameKasir { get; set; }
        public string PasswordKasir { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
