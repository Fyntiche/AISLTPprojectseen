﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Cout
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Номер ЛТП")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Населенный пункт")]
        public string Np { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Улица")]
        public string Ul { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дом")]
        public string Dom { get; set; }

        [Display(Name = "Почтовый индекс")]
        public int Pindex { get; set; }

        [Display(Name = "Телефон")]
        public string Teldej { get; set; }

        [Display(Name = "Электронная почта")]
        public string Email { get; set; }
    }
}