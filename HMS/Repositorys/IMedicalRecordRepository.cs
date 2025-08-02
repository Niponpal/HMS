using HMS.Models;

namespace HMS.Repositorys
{
    public interface IMedicalRecordRepository
    {
        IEnumerable<MedicalRecord> GetAllData();
        String AddData(MedicalRecord medicalRecord);
        MedicalRecord GetById(int id);
        void UpdateDate(MedicalRecord medicalRecord);
        string DeleteData(int id); 
    }
}
