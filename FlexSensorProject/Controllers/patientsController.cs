using FlexSensorProject.Data;
using FlexSensorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlexSensorProject.Controllers
{
    public class patientsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public patientsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var patients = await _context.Patients.ToListAsync();
            return View(patients);
        }

        public async Task<IActionResult> ViewTests(int id) 
        {
            var patient = await _context.Patients
                .Include(p => p.Tests)
                .FirstOrDefaultAsync(p => p.Id == id);

            return View(patient);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient) 
        {
            
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) { 
                return NotFound();
            }

            Patient? patientForEditng = _context.Patients.Find(id);
            if (patientForEditng == null) { return NotFound(); }

            return View(patientForEditng);
        
        }

        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            
            _context.Patients.Update(patient);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            Patient patientForDelete = _context.Patients.Find(id);
            if (patientForDelete == null)
            {
                return NotFound();
            }
            return View(patientForDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Patient obj = _context.Patients.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }

            _context.Patients.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: /Patients/CreateTest/{patientId}
        // Action for displaying the form to create a test
        public IActionResult CreateTest(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            var test = new Test
            {
                PatientId = patientId,
                Patient = patient,
                date = DateTime.Today
            };

            return View(test);
        }


        // POST: /Patients/CreateTest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTest(Test test)
        {
           
                _context.Tests.Add(test);
                _context.SaveChanges();
                return RedirectToAction("Index");
            

           
        }



    }



    
}
