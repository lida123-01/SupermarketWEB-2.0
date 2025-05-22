using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Paymodes
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;

        public EditModel(SupermarketContext context)
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
            Paymode = paymode;
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Paymode).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymodeExists(Paymode.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PaymodeExists(int id)
        {
            return (_context.Paymodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
