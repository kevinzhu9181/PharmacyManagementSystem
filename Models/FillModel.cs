using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Models
{
    public class FillModel
    {
        public int Id { get; set; }
        public int FillNumber { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FillDate { get; set; }
        public int FillQuantity { get; set; }
        public int DaySupply { get; set; }
        public string FilledBy { get; set; }
        public int ScriptId { get; set; }
        public virtual ScriptModel Script { get; set; }
    }
}
