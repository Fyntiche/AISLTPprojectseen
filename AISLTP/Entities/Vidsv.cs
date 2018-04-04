using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Vidsv
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Вид связи")]
        public string Txt { get; set; }
    }
}