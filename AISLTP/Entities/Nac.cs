using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Nac
    {
        [Key]
        public int ID { get; set; }
        [Display( Name = "Национальность" )]
        public string Txt { get; set; }

        public ICollection<Lico> Licos { get; set; }
        public Nac()
        {
            Licos = new List<Lico>();
        }
    }
}
