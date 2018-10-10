using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class ArticleType
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ATID { get; set; }
        [StringLength(20)]
        public string ATName { get; set; }
    }
}
