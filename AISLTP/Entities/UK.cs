using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class UK
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пункт")]
        public string Punkt { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Часть")]
        public string Chast { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Статья")]
        public string St { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Примечание")]
        public string Prim { get; set; }
    }
}