using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Models
{
    public class DrugModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public double PackageSize { get; set; }
        public double NetCost { get; set; }
        public string ABRating { get; set; }
        public string GPI { get; set; }
        public string Manufacturer { get; set; }
        public int ScheduleClass { get; set; }
        public string GenericName { get; set; }
        public string IsGeneric { get; set; }
        public virtual ICollection<ScriptModel> Scripts { get; set; }
    }
}
