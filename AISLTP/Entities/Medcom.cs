﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Medcom
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Мед. комиссия")]
        public string Txt { get; set; }

        public ICollection<Medic> Medics { get; set; }

        public Medcom()
        {
            Medics = new List<Medic>();
        }
    }
}