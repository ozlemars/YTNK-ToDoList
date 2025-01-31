using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListMVC.Models;
using ToDoListMVC.ToDo.Repository.Contexts;
using ToDoListMVC.ToDo.Service.Abstracts;

namespace ToDoListMVC.Controllers
{
    public class GorevController : Controller
    {
        private readonly IGorevService _gorevService;
        public GorevController(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }

        //Create
        public IActionResult VCreate()
        {
            return View("VCreate", new Gorev());
        }
        //post

        [HttpPost]
        public async Task<IActionResult> VCreate(Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                await _gorevService.CreateTaskAsync(gorev);
                TempData["SuccessMessage"] = "Görev başarıyla eklendi!";
                return RedirectToAction("Index", gorev);
            }
            else
            {
                TempData["ErrorMessage"] = "Görev eklenirken bir hata oluştu!";
                return View("VCreate", gorev); 
            }
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var gorev = await _gorevService.GetTaskByIdAsync(id);
            if (gorev == null)
            {
                TempData["ErrorMessage"] = "Görev bulunamadı.";
                return RedirectToAction("Index");
            }
            return View(gorev);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                await _gorevService.EditTaskAsync(gorev);
                TempData["SuccessMessage"] = "Görev başarıyla güncellendi!";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Görev güncellenirken bir hata oluştu.";
            return View(gorev);
        }
       
        public async Task<IActionResult> Delete(Guid id)
        {
            var gorev = await _gorevService.GetTaskByIdAsync(id);  
            if (gorev == null)
            {
                TempData["ErrorMessage"] = "Görev bulunamadı.";
                return RedirectToAction("Index");
            }
            return View(gorev);  
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
              await _gorevService.DeleteTaskAsync(id);
                TempData["SuccessMessage"] = "Görev başarıyla silindi!";
                return RedirectToAction("Index");
            }
    

        public async Task <IActionResult> Index()
        {
            try
            {
                var gorevler = await _gorevService.GetAllTasksAsync();
                return View(gorevler ?? new List<Gorev>());
            }
            catch (Exception ex)
            {
                // Hata
                Console.WriteLine($"Hata: {ex.Message}");
                TempData["ErrorMessage"] = "Görevler yüklenirken bir hata oluştu!";
                return View(new List<Gorev>());
            }
        }
    }
}
