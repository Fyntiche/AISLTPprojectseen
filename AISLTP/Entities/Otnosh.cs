using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Otnosh
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Отношения")]
        public string Txt { get; set; }
    }
}