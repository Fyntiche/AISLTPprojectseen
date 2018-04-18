using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Soderotnosh
    {

        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Display(Name = "Ф.И.О. лица")]
        public string Name { get; set; }

        [Display(Name = "Отношение")]
        public int? OtnoshID { get; set; }
        public virtual Otnosh Otnosh { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Soderotnosh()
        {
            Licos = new List<Lico>();
        }
    }
}