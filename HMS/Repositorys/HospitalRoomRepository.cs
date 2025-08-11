using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace HMS.Repositorys
{
    public class HospitalRoomRepository : IHospitalRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public HospitalRoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddData(HospitalRoom hospitalRoom)
        {
           _context.HospitalRooms.Add(hospitalRoom);
           _context.SaveChanges();
            return "Data Added Successful";
        }

        public string DeleteData(int id)
        {
            var data = _context.HospitalRooms.Find(id);
            if (data == null)
            {
                return "NotFound";
            }
            _context.HospitalRooms.Remove(data);
            _context.SaveChanges();
            return "Data Delete Successful";
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            var data = _context.HospitalRooms.Select(x => new SelectListItem
            {
                Text = x.RoomNumber,
                Value = x.Id.ToString()
            }).ToList();
            return data;
        }

       

        public IEnumerable<HospitalRoom> GetAllData()
        {
          var data = _context.HospitalRooms.ToList();
            return data;
        }

        public HospitalRoom GetById(int id)
        {
            var data = _context.HospitalRooms.Find(id);
            return data;
        }

        public void UpdateData(HospitalRoom hospitalRoom)
        {
            _context.HospitalRooms.Find(hospitalRoom.Id);
            _context.SaveChanges();
        }
    }
}
