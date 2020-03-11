using System;
using System.Collections.Generic;
using Testing.Models;

namespace EmergencyR.Models
{
    public class Diagnosis
    {

        public int DiagnosisID { get; set; }
        public int SpecificationID { get; set; }
        public string Name { get; set; }
        public int SeverityID { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Spec> Specification { get; set; }
        public IEnumerable<RunningEntry> Entries { get; set; }
    }
}
