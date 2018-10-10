﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class MusicType
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MTID { get; set; }
        [StringLength(50)]
        public string MTName { get; set; }
    }
}
