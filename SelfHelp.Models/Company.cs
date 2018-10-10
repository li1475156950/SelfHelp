using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //公司表ID
        public int ComID { get; set; }
        //公司唯一标识
        [StringLength(50)]
        public string ComIndentity { get; set; }
        //公司简介图片
        [StringLength(500)]
        public string  ComImages { get; set; }
        //公司介绍
        [MaxLength]
        public string ComIntroduce { get; set; }
        //创建人
        [StringLength(50)]
        public string CreatePerson { get; set; }
        //创建时间
        public DateTime? CreateTime { get; set; }
    }
}
