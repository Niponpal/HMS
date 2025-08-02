using HMS.Data;
using HMS.Models;

namespace HMS.Repositorys
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;
       public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddData(Invoice invoice)
        {
            var data = _context.invoices.Add(invoice);
            if (data == null) 
            {
                return "NotFound";
            }
            _context.SaveChanges();
            return "Added Data Successfully";
        }

        public string DeleteData(int id)
        {
            var data = _context.invoices.Find(id);
            if (data == null)
            {
                return "notFound";
            }
             _context.Remove(data);
            _context.SaveChanges();
            return "Data Delete Successfully";
        }

        public IEnumerable<Invoice> GetAllData()
        {
            var data = _context.invoices.ToList();
            return data;
        }

        public Invoice GetById(int id)
        {
            var data = _context.invoices.Find(id);
            return data;
        }

        public void UpdateData(Invoice invoice)
        {
           _context.invoices.Find(invoice.Id);
            _context.SaveChanges();
            
        }
    }
}
