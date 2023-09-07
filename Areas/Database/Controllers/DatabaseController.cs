using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controller_View.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controller_View.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage")]
    public class DatabaseController : Controller
    {

        private readonly AppDbContext _DbContext;

        public DatabaseController(AppDbContext DbContext)
        {
            this._DbContext = DbContext;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index()
        {


            return View();
        }

        [Route("delete-db")]
        [HttpGet]
        public IActionResult DeleteDb(string dbName)
        {
            return View("DeleteDatabase", dbName);
        }

        [Route("delete-db")]
        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var success = await _DbContext.Database.EnsureDeletedAsync();

            StatusMessage = success ? "Xóa Database thành công" : "Không xóa được Db";

            return RedirectToAction(nameof(Index));
        }

        [Route("migration")]
        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _DbContext.Database.MigrateAsync();

            StatusMessage = "Cập nhật Database thành công";

            return RedirectToAction(nameof(Index));
        }
    }
}