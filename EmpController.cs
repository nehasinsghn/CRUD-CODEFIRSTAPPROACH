using CoreFirstApproach.Database;
using Microsoft.AspNetCore.Mvc;

namespace CoreFirstApproach.Controllers
{
    public class EmpController : Controller
    {
        private readonly StudentContex _db;
        private int Id;
        private string? Name;

        public string? Email { get; private set; }
        public string? Mobile { get; private set; }
        public string? Company { get; private set; }
        public string? Dept { get; private set; }

        public EmpController(StudentContex db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           var result = _db.Students.ToList();
            
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student m)
        {
            if (ModelState.IsValid)
            {
                var c = new Student();
                {

                    Name = m.Name;
                    Email = m.Email;
                    Mobile = m.Mobile;
                    Company = m.Company;
                    Dept = m.Dept;

                };
                _db.Students.Add(c);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty fild con not submit";
                return View(m);
            }

        }
        public IActionResult Delete(int id)
        {
            var d = _db.Students.SingleOrDefault(e => e.Id == id);
            _db.Students.Remove(d);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var E = _db.Students.SingleOrDefault(e => e.Id == id);
            var result = new Student();
            {
                Name = E.Name;
                Email = E.Email;
                Mobile = E.Mobile;
                Company = E.Company;
                Dept = E.Dept;
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Student m)
        {
            var c = new Student();
            {
                Id = m.Id;
                Name = m.Name;
                Email = m.Email;
                Mobile = m.Mobile;
                Company = m.Company;
                Dept = m.Dept;

            };
            _db.Students.Update(c);
            return View();
        }

    }
}
