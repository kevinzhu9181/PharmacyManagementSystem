using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Models
{
    public class ScriptModel
    {
        public int Id { get; set; }
        public string RxOrigin { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateWritten { get; set; }
        public int DrugQuantity { get; set; }
        public string Directions { get; set; }
        public int DaySupply { get; set; }
        public int RefillNumbers { get; set; }
        public string FilledBy { get; set; }
        public int PatientId { get; set; }
        public virtual PatientModel Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual DoctorModel Doctor { get; set; }
        public int DrugId { get; set; }
        public virtual DrugModel Drug { get; set; }
        public virtual ICollection<FillModel> Fills { get; set; }
    }
}
