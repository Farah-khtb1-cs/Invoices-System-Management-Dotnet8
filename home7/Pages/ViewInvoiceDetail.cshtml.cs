using home7.Models;
using home7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace home7.Pages
{
    public class ViewInvoiceDetailModel : PageModel
    {

        private readonly Iservices _services;
        public ViewInvoiceDetailModel(Iservices services)
        {
            _services = services;
        }
        public InvoiceView Invoiceview { get; set; } = new InvoiceView();
        public async Task OnGet(int id)
        {
            var invoice = await _services.GetInvoiceById(id);
            if (invoice == null)
            {
                ModelState.AddModelError("", "Invoice not found.");
                return;
            }
            Invoiceview.Number = invoice.Number;
            Invoiceview.Status = invoice.Status;
            Invoiceview.IssueDate = invoice.IssueDate;
            Invoiceview.DueDate = invoice.DueDate;
            Invoiceview.Service = invoice.Service;
            Invoiceview.UnitPrice = invoice.UnitPrice;
            Invoiceview.Quantity = invoice.Quantity;
            Invoiceview.ClientName = invoice.ClientName;
            Invoiceview.Email = invoice.Email;
            Invoiceview.Phone = invoice.Phone;
            Invoiceview.Address = invoice.Address;
         

        }
    }
}
