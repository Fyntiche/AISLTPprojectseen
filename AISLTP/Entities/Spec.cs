using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Spec
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Специальность")]
        public string Txt { get; set; }
    }
}