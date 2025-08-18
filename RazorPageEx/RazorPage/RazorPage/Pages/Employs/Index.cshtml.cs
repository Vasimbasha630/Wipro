using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RajorExamples.Models;
 // Adjust namespace

namespace RazorPage.Pages.Employs
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreDbContext _context;

        public IndexModel(EFCoreDbContext context)
        {
            _context = context;
        }

        public IList<Employ> Employees { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }
    }
}
