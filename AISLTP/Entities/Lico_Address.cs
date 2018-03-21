using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Lico_Address
    {
        public int ID { get; set; }

        public int? LicoID { get; set; }
        public Lico Lico { get; set; }

        public int? AddressID { get; set; }
        public Address Address { get; set; }

    }
}