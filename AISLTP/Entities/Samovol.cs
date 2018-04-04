using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Samovol
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Самовольное оставление ЛТП")]
        public string Txt { get; set; }
    }
}