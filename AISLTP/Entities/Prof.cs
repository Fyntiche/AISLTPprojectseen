using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Prof
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Профессия")]
        public string Txt { get; set; }
    }
}