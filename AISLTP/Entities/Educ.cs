using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Educ
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Образование")]
        public string Txt { get; set; }
    }
}