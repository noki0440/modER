using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyR.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmergencyR.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly IDiagnosisRepository repo;

        public DiagnosisController(IDiagnosisRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var diagnosis = repo.GetAllDiagnoses();

            return View(diagnosis);
        }

        public IActionResult ViewDiagnosis(int id)
        {
            var diagnosis = repo.GetDiagnosis(id);

            return View(diagnosis);
        }

        public IActionResult UpdateDiagnosis(int id)
        {
            Diagnosis diag = repo.GetDiagnosis(id);

            repo.UpdateDiagnosis(diag);

            if (diag == null)
            {
                return View("DiagnosisNotFound");

            }

            return View(diag);
        }

        public IActionResult UpdateDiagnosisToDatabase(Diagnosis diagnosis)
        {
            repo.UpdateDiagnosis(diagnosis);

            return RedirectToAction("ViewDiagnosis", new { id = diagnosis.DiagnosisID });
        }

        public IActionResult InsertDiagnosis()
        {
            //CHANGED HERE FROM SPEC TO RUNNINGENTRY
            var diag = repo.AssignRunningEntry();

            return View(diag);
        }

        public IActionResult InsertDiagnosisToDatabase(Diagnosis diagnosisToInsert)
        {
            repo.InsertDiagnosis(diagnosisToInsert);

            return RedirectToAction("Index");
        }

       public IActionResult DeleteDiagnosis(Diagnosis diagnosis)
        {
            repo.DeleteDiagnosis(diagnosis);

            return RedirectToAction("Index");
        }

    }
}
