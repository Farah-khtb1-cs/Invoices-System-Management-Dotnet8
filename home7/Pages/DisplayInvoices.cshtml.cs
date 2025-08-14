using home7.Models;
using home7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace home7.Pages
{
    public class DisplayInvoicesModel : PageModel
    {
        private readonly Iservices _services;

        public DisplayInvoicesModel(Iservices services)
        {
            _services = services;
        }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public async Task OnGet()
        {
            Invoices = await _services.GetInvoices();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var s = await _services.DeleteInvoice(id);
            if (s > 0)
            {
                return RedirectToPage("DisplayInvoices");
            }
            else
            {
                ModelState.AddModelError("", "Error deleting invoice");
                return Page();
            }
        }
    }
}


