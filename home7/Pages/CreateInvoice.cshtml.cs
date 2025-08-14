using home7.Models;
using home7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace home7.Pages
{
    public class CreateInvoiceModel : PageModel
    {
        private readonly Iservices _services;

        public CreateInvoiceModel(Iservices services)
        {
            _services = services;
        }

        [BindProperty]
        public InvoiceBinding InvoiceBinding { get; set; } = new InvoiceBinding();

        // no need for flag anymore — we use InvoiceBinding.Id

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (InvoiceBinding.Id != 0) // update mode
            {
                var inv = await _services.UpdateInvoice(InvoiceBinding.Id, InvoiceBinding);
                if (inv == null)
                {
                    ModelState.AddModelError("", "Error updating invoice");
                    return RedirectToPage("DisplayInvoices");
                }
            }
            else // insert mode
            {
                int id = await _services.AddInvoice(InvoiceBinding);
            }

            return RedirectToPage("DisplayInvoices");
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
            {
                return Page(); // create mode
            }

            var invView = await _services.GetInvoiceById(id.Value);
            if (invView == null)
            {
                return NotFound();
            }

            // fill binding model
            InvoiceBinding.Id = invView.Id;
            InvoiceBinding.Number = invView.Number;
            InvoiceBinding.Status = invView.Status;
            InvoiceBinding.IssueDate = invView.IssueDate;
            InvoiceBinding.DueDate = invView.DueDate;
            InvoiceBinding.Service = invView.Service;
            InvoiceBinding.UnitPrice = invView.UnitPrice;
            InvoiceBinding.Quantity = invView.Quantity;
            InvoiceBinding.ClientName = invView.ClientName;
            InvoiceBinding.Email = invView.Email;
            InvoiceBinding.Phone = invView.Phone;
            InvoiceBinding.Address = invView.Address;

            return Page();
        }
    }
}
