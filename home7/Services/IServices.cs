using home7.Models;

namespace home7.Services
{
    public interface Iservices
    {
        public Task<List<Invoice>> GetInvoices();
        public Task<int> AddInvoice(InvoiceBinding binding);
        public Task<int> DeleteInvoice(int Id);
        public Task<Invoice> GetInvoiceById(int id);
        public Task<Invoice> UpdateInvoice(int  Id, InvoiceBinding binding);


    }
}
