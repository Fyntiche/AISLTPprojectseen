﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Address
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Display( Name = "Область" )]
        public int? OblID { get; set; }
        public Obl Obl { get; set; }

        [Display( Name = "Район" )]
        public int? RnID { get; set; }
        public Rn Rn { get; set; }

        [Display( Name = "Населенный пункт" )]
        public int? NpID { get; set; }
        public Np Np { get; set; }

        [Display( Name = "Улица" )]
        public string Ul { get; set; }

        [Display( Name = "Дом" )]
        public string Dom { get; set; }

        [Display( Name = "Корпус" )]
        public string Korpus { get; set; }

        [Display( Name = "Квартира" )]
        public string Kvartira { get; set; }
                
    }
}