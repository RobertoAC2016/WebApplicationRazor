using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRazor.Data;
using WebApplicationRazor.Modelos;

namespace WebApplicationRazor.Pages
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Curso Curso { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            Curso.FechaCreacion = DateTime.Now;
            await _context.Curso.AddAsync(Curso);
            await _context.SaveChangesAsync();
            Mensaje = "El curso se ha creado correctamente!!!";
            return RedirectToPage("Index");
        }
    }
}
