using Microsoft.AspNetCore.Mvc;
using StudentAPIFakeDataCRUD.UI.Models;

namespace StudentAPIFakeDataCRUD.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly HttpClient _httpClient;

        public StudentsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Student>>("https://localhost:7284/api/Students");
            return View(model);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,StudentClass")] Student student)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7284/api/Students", student);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(IndexAsync));
                }
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _httpClient.GetFromJsonAsync<Student>($"https://localhost:7284/api/Students/{id}");
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,StudentClass")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7284/api/Students/{id}", student);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(IndexAsync));
                }
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _httpClient.GetFromJsonAsync<Student>($"https://localhost:7284/api/Students/{id}");
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7284/api/Students/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            return View();
        }
    }
}
