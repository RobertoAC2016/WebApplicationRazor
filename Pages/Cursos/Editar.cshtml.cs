using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRazor.Data;
using WebApplicationRazor.Modelos;

namespace WebApplicationRazor.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Curso Curso { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Curso = await _context.Curso.FindAsync(id);
            if (Curso == null)
            {
                Mensaje = "El curso no fue encontrado.";
                return RedirectToPage("Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            var dbcurso = await _context.Curso.FindAsync(Curso.Id);
            if (dbcurso == null)
            {
                return RedirectToPage("Index");
            }
            dbcurso.NombreCurso = Curso.NombreCurso;
            dbcurso.CantidadClases = Curso.CantidadClases;
            dbcurso.Precio = Curso.Precio;
            await _context.SaveChangesAsync();
            Mensaje = "Curso modificado correctamente!!!";
            return RedirectToPage("Index");
        }
    }
}
