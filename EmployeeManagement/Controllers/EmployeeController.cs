using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _db;

        private readonly IHostEnvironment _hostEnvironment;

        public EmployeeController(EmployeeContext db, IHostEnvironment hostEnvironment)
        {
            _db= db;
            _hostEnvironment= hostEnvironment;
        }
        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _db.Employees.ToList();
            return View(objEmployeeList);
        }

        public IActionResult AddNew() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Employee obj)
        {
            if (obj.FirstName == obj.LastName)
            {
                ModelState.AddModelError("lastname", "First Name and Last Name can not be same.");
            }

            if (ModelState.IsValid) 
            {
                if (obj.ProfilePic != null &&  obj.ProfilePic.Length > 0)
                {
                    string extention = Path.GetExtension(obj.ProfilePic.FileName).ToLower();

                    string fileName = obj.FirstName.ToLower().Replace(' ', '-') + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extention;
                    obj.ProfilePicName = fileName;
                    string uploadFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "images", "employees");

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string filePath = Path.Combine(uploadFolder,fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    obj.ProfilePic.CopyTo(stream);
                }

                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee added sussessfully";
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }

            Employee? employeeFromDb = _db.Employees.Find(id);
            if (employeeFromDb == null) 
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ProfilePic != null && obj.ProfilePic.Length > 0)
                {
                    string extension = Path.GetExtension(obj.ProfilePic.FileName).ToLower();
                    string fileName = obj.FirstName.ToLower().Replace(' ', '-') + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;
                    obj.ProfilePicName = fileName;

                    string uploadFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "images", "employees");

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string filePath = Path.Combine(uploadFolder, fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    obj.ProfilePic.CopyTo(stream);
                }

                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? employeeFromDb = _db.Employees.Find(id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Employee? obj = _db.Employees.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }

            if(!string.IsNullOrEmpty(obj.ProfilePicName))
            {
                string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "images", "employees", obj.ProfilePicName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee deleted sussessfully";
            return RedirectToAction("Index");
        }
    }
}
