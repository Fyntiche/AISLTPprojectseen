using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Np
    {
        [Key]
        public int ID { get; set; }
        [Display( Name = "Населенный пункт" )]
        public string Txt { get; set; }

        public string TypeTxt { get; set; }

        public ICollection<Lico> Licos { get; set; }
        public Np()
        {
            Licos = new List<Lico>();
        }
    }
}