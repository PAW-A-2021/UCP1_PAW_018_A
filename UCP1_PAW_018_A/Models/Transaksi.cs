using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_018_A.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdMenu { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdKasir { get; set; }
        public int? TotalTransaksi { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Kasir IdKasirNavigation { get; set; }
        public virtual Menu IdMenuNavigation { get; set; }
    }
}
