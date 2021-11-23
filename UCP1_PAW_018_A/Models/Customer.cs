using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_018_A.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string MejaCustomer { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
