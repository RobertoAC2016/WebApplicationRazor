using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationRazor.Data;
using WebApplicationRazor.Modelos;

namespace WebApplicationRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [TempData]
        public string Mensaje { get; set; }

        public IEnumerable<Curso> Cursos { get; set; }
        public async Task OnGet()
        {
            Cursos = await _context.Curso.ToListAsync();
        }
        public async Task<IActionResult> OnPostBorrar(int id)
        {
            if (!ModelState.IsValid) return Page();
            var dbcurso = await _context.Curso.FindAsync(id);
            if (dbcurso == null) return NotFound();
            _context.Curso.Remove(dbcurso);
            await _context.SaveChangesAsync();
            Mensaje = "Curso Borrado correctamente!!!";
            return RedirectToPage("Index");
        }
    }
}
