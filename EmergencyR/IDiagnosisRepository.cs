using System;
using System.Collections.Generic;
using EmergencyR.Models;
using Testing.Models;

namespace EmergencyR
{
    public interface IDiagnosisRepository
    {
        public IEnumerable<Diagnosis> GetAllDiagnoses();
        public Diagnosis GetDiagnosis(int id);
        public void UpdateDiagnosis(Diagnosis diagnosis);
        public void InsertDiagnosis(Diagnosis diagnosisToInsert);
        public IEnumerable<Spec> GetSpecifications();
        public Diagnosis AssignSpec();

        public IEnumerable<RunningEntry> GetEntries();
        public Diagnosis AssignRunningEntry();

        public void DeleteDiagnosis(Diagnosis diagnosis);


    }
}
