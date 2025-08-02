using HMS.Models;

namespace HMS.Repositorys
{
    public interface IHospitalRoomRepository
    {
        IEnumerable<HospitalRoom> GetAllData();
        string AddData(HospitalRoom hospitalRoom);
        HospitalRoom GetById(int id);
        void UpdateData(HospitalRoom hospitalRoom);
        string DeleteData(int  id);
    }
}
