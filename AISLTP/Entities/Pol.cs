using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Pol
    {
        [Key]
        public int ID { get; set; }
        public string Txt { get; set; }

        public ICollection<Lico> Licos { get; set; }
        public Pol()
        {
            Licos = new List<Lico>();
        }
    }
}