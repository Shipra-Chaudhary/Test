using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCase.Models;

namespace TestCase.Controllers
{
    public class EMployeeController : Controller
    {

        private readonly EmployeeDBContext _dbContext;
        public EMployeeController(EmployeeDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Create()
        {
           
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var employee = await _dbContext.Employees.ToListAsync();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            
            _dbContext.Employees.Add(emp);
            await _dbContext.SaveChangesAsync();
            TempData["Sucess"] = "Data Saved Successfully";
            return RedirectToAction("Index");
            
            //return View();
        }
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var employee1 = await _dbContext.Employees.FindAsync(id);

            return View(employee1);
        }
        [HttpPost]
        public async Task <IActionResult> Edit(int id,Employee obj)
        {
            if (id != obj.ID)
            {
                return NotFound();
            }
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            else
            {
                _dbContext.Update(obj);
                await _dbContext.SaveChangesAsync();
                TempData["Success"] = "Data Updated SuccesFully";
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
