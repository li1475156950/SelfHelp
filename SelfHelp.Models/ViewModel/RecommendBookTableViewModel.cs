﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models.ViewModel
{
    public class RecommendBookTableViewModel
    {
        public List<RecommendBook> ModelList { get; set; }
        public int PageCount { get; set; }
    }
}
