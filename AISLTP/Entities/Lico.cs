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

        [Display( Name = "Дата рождения" )]
        [DataType( DataType.Date )]
        public DateTime Dr { get; set; }

        [Display( Name = "Пол" )]
        public int? PolID { get; set; }
        public Pol Pol { get; set; }

        [StringLength( 255 , ErrorMessage = "Длина строки должна 14 символов" )]
        [Display( Name = "Идетификационный номер паспорта" )]
        public string Pasport { get; set; }

        [Display( Name = "Национальность" )]
        public int?  NacID { get; set; }
        public Nac Nac { get; set; }

        [Display( Name = "Область" )]
        public int? OblID { get; set; }
        public Obl Obl { get; set; }

        [Display( Name = "Район" )]
        public int? RnID { get; set; }
        public Rn Rn { get; set; }
        
        [Display( Name = "Населенный пункт" )]
        public int? NpID { get; set; }
        public Np Np { get; set; }

        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        [Display( Name = "Внешность" )]
        public string Vneshnost { get; set; }
    }
}
