﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Lico
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Фамилия")]
        public string Fam { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Имя")]
        public string Ima { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Отчество")]
        public string Otc { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime Dr { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пол")]
        public int? PolID { get; set; }

        public virtual Pol Pol { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна 14 символов")]
        [Display(Name = "Идетификационный номер паспорта")]
        public string Pasport { get; set; }

        [Display(Name = "Национальность")]
        public int? NacID { get; set; }

        public virtual Nac Nac { get; set; }

        [Display(Name = "Область")]
        public int? OblID { get; set; }

        public virtual Obl Obl { get; set; }

        [Display(Name = "Район")]
        public int? RnID { get; set; }

        public virtual Rn Rn { get; set; }

        [Display(Name = "Населенный пункт")]
        public int? NpID { get; set; }

        public virtual Np Np { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Внешность")]
        public string Vneshnost { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Prof> Profs { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
        public virtual ICollection<UK> UKs { get; set; }
        public virtual ICollection<Koap> Koaps { get; set; }
        public virtual ICollection<Medic> Medics { get; set; }
        public virtual ICollection<Privent> Privents { get; set; }
        public virtual ICollection<Educ> Educs { get; set; }
        public virtual ICollection<Naprav> Napravs { get; set; }

        public Lico()
        {
            Addresses = new List<Address>();
            Profs = new List<Prof>();
            Specs = new List<Spec>();
            UKs = new List<UK>();
            Koaps = new List<Koap>();
            Privents = new List<Privent>();
            Educs = new List<Educ>();
            Napravs = new List<Naprav>();
        }
    }
}