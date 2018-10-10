using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class AnalysisData
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ADID { get; set; }
        [StringLength(100)]
        public string TableName { get; set; }
        [StringLength(100)]
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public int TabID { get; set; }
        public Int64 StayTime { get; set; }
        public DateTime CreateTime { get; set; }
        [StringLength(100)]
        public string CreatePeople { get; set; }
    }
}
