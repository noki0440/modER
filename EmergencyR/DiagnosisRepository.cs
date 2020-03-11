using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using EmergencyR.Models;
using Testing.Models;

namespace EmergencyR
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly IDbConnection _conn;

        public DiagnosisRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        public IEnumerable<Diagnosis> GetAllDiagnoses()
        {
            return _conn.Query<Diagnosis>("SELECT * FROM diagnosis;");
        }

        public Diagnosis GetDiagnosis(int id)
        {
            return (Diagnosis)_conn.QuerySingle<Diagnosis>("SELECT * FROM diagnosis WHERE DiagnosisID = @id;", new { id = id });

        }

        public void UpdateDiagnosis(Diagnosis diagnosis)
        {
            _conn.Execute("UPDATE diagnosis SET SpecificationID = @specificationID, Name = @name, SeverityID = @severityID, Date = @date WHERE DiagnosisID = @diagnosisID;",
                new { specificationID = diagnosis.SpecificationID, name = diagnosis.Name, severityID = diagnosis.SeverityID, date = diagnosis.Date, diagnosisID = diagnosis.DiagnosisID });
        }

        public void InsertDiagnosis(Diagnosis diagnosisToInsert)
        {
            _conn.Execute("INSERT INTO diagnosis(SPECIFICATIONID, NAME, SEVERITYID, DATE) VALUES (@specID, @name, @sevID, @date);",
                new {specID = diagnosisToInsert.SpecificationID, name = diagnosisToInsert.Name, sevID = diagnosisToInsert.SeverityID, date = diagnosisToInsert.Date});
        }

        public IEnumerable<Spec> GetSpecifications()
        {
            return _conn.Query<Spec>("SELECT * FROM specification;");
        }

        public Diagnosis AssignSpec()
        {
            var specList = GetSpecifications();
            var diagnosis = new Diagnosis();
            diagnosis.Specification = specList;

            return diagnosis;
        }

        //-------------

        public IEnumerable<RunningEntry> GetEntries()
        {
            return _conn.Query<RunningEntry>("SELECT DISTINCT(Name) FROM diagnosis;");
        }


        public Diagnosis AssignRunningEntry()
        {
            var entryList = GetEntries();
            var diagnosis = new Diagnosis();
            diagnosis.Entries = entryList;

            return diagnosis;
        }

        public void DeleteDiagnosis(Diagnosis diagnosis)
        {
            _conn.Execute("DELETE FROM diagnosis WHERE DiagnosisID = @Did;", new { Did = diagnosis.DiagnosisID });
        }

    }
}
