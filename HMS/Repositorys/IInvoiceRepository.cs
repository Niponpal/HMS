using HMS.Models;

namespace HMS.Repositorys
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAllData();
        string AddData(Invoice invoice);
        Invoice GetById(int id);
        void UpdateData(Invoice invoice);
        string DeleteData(int id);
    }
}
