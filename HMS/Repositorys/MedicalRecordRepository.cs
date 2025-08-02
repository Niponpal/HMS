using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HMS.Repositorys
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _context;
        public MedicalRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddData(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            _context.SaveChanges();
            return "Data Added Successfully";
        }
        public string DeleteData(int id)
        {
            var data = _context.MedicalRecords.Find(id);
            if (data == null) 
            {
                return "NotFound";
            }
            _context.MedicalRecords.Remove(data);
            _context.SaveChanges() ;
            return "Data Delete Successfully";
        }

        public IEnumerable<MedicalRecord> GetAllData()
        {
           var data = _context.MedicalRecords.ToList();
            return data;
        }

        public MedicalRecord GetById(int id)
        {
            var data = _context.MedicalRecords.Find(id);
            return data;
        }

        public void UpdateDate(MedicalRecord medicalRecord)
        {
           _context.MedicalRecords.Find(medicalRecord.Id);
            _context.SaveChanges();
        }
    }
}
