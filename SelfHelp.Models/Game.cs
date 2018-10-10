using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class Game
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameID { get; set; }
        [StringLength(20)]
        public string GameName { get; set; }
        [StringLength(100)]
        public string GameSrc { get; set; }
        [StringLength(100)]
        public string GameImgSrc { get; set; }
        [MaxLength]
        public string GameIntroduce { get; set; }
        public int GTID { get; set; }
    }
}
