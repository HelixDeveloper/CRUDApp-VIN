using CRUDApp.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDApp.Controllers
{
    public class CountrManageController : Controller
    {
        //DI
        private readonly LocationDbContext _context;
        CountryModel _country;
        public CountrManageController(LocationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Asyc all method
            //await

            //return result of country table data
            return View(await _context.Countries.ToListAsync());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryModel country)
        {
            if(country == null)
            {
                ViewBag.Error = "Please add valid data!";
                return View();
            }
            try
            {
                //code
                await _context.Countries.AddAsync(country);
                _context.SaveChanges();
                ViewBag.Message = "Saved Country Details!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //add the error alert code
                ViewBag.Error = ex.Message;
            }

            return View();
        }


    }
}
