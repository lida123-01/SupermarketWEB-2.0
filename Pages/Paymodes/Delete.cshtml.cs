using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Paymodes
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Paymode Paymode { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Paymodes == null)
            {
                return NotFound();
            }

            var paymode = await _context.Paymodes.FirstOrDefaultAsync(m => m.Id == id);

            if (paymode == null)
            {
                return NotFound();
            }
            else
            {
                Paymode = paymode;
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Paymodes == null)
            {
                return NotFound();
            }

            var paymode = await _context.Paymodes.FindAsync(id);

            if (paymode != null)
            {
                Paymode = paymode;
                _context.Paymodes.Remove(paymode);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");

        }
    }
}
