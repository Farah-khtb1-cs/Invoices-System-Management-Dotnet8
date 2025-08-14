using home7.Data;
using home7.Models;
using Microsoft.EntityFrameworkCore;

namespace home7.Services
{
    public class Services : Iservices
    {

        private readonly AppDbContext _context;
        public Services(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Invoice>> GetInvoices()
        {
            return await  _context.Invoices.ToListAsync();
        }

        public async Task<int> AddInvoice(InvoiceBinding binding)
        {
          var Invoice = new Invoice
          {
              Number = binding.Number,
              Status = binding.Status,
              IssueDate = binding.IssueDate,
              DueDate = binding.DueDate,
              Service = binding.Service,
              UnitPrice = binding.UnitPrice,
              Quantity = binding.Quantity,
              ClientName = binding.ClientName,
              Email = binding.Email,
              Phone = binding.Phone,
              Address = binding.Address
          };
            _context.Invoices.Add(Invoice);
            await _context.SaveChangesAsync();
            return Invoice.Id;
        }

        public Task<int> DeleteInvoice(int Id)
        {
            var invoice = _context.Invoices.Find(Id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(0);
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<Invoice> UpdateInvoice(int Id, InvoiceBinding binding)
        {
            Invoice invoice = await _context.Invoices.FindAsync(Id);
            if (invoice == null)
            {
                return null;
            }
            invoice.Id = Id; // Ensure the Id is set correctly
            invoice.Number = binding.Number;
            invoice.Status = binding.Status;
            invoice.IssueDate = binding.IssueDate;
            invoice.DueDate = binding.DueDate;
            invoice.Service = binding.Service;
            invoice.UnitPrice = binding.UnitPrice;
            invoice.Quantity = binding.Quantity;
            invoice.ClientName = binding.ClientName;
            invoice.Email = binding.Email;
            invoice.Phone = binding.Phone;
            invoice.Address = binding.Address;

            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

    }
}
