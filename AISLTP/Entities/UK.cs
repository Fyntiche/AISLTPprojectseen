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
        public string Point { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Часть")]
        public string Part { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Статья")]
        public string Article { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Примечание")]
        public string Prim { get; set; }
    }
}