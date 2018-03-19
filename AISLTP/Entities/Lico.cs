using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Lico
    {

        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        [Display( Name = "Фамилия" )]
        public string Fam { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        [Display( Name = "Имя" )]
        public string Ima { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        [Display( Name = "Отчество" )]
        public string Otc { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [Display( Name = "Дата рождения" )]
        public DateTime Dr { get; set; }

        public int? PolID { get; set; }
        public Pol Pol { get; set; }

        [StringLength( 255 , ErrorMessage = "Длина строки должна 14 символов" )]
        [Display( Name = "Идетификационный номер паспорта" )]
        public string Pasport { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [Display( Name = "Нацильность" )]
        public int Nac { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [Display( Name = "Область" )]
        public int Obl { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [Display( Name = "Район" )]
        public int Rn { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [Display( Name = "Населенный пункт" )]
        public int Np { get; set; }

        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        [Display( Name = "Внешность" )]
        public string Vneshnost { get; set; }

        [Display( Name = "Нацильность" )]
        public int Prim { get; set; }
    }
}
