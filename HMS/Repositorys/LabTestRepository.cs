using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositorys
{
    public class LabTestRepository : ILabTestRepository
    {
       private readonly ApplicationDbContext _dbContext;
        public LabTestRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AddData(LabTest labTest)
        {
            _dbContext.LabTests.Add(labTest);
            _dbContext.SaveChanges();
            return "Data Added Sucessfully";
        }

        public string DeleteData(int id)
        {
            var data = _dbContext.LabTests.Find(id);
            if (data != null)
            {
                return "NotFound";
            }
            _dbContext.LabTests.Remove(data);
            _dbContext.SaveChanges() ;
            return "Data Delte Sucessfull";
        }

        public IEnumerable<LabTest> GetAllData()
        {
            var data = _dbContext.LabTests.ToList();
            return data;
        }

        public LabTest GetById(int id)
        {
            var data = _dbContext.LabTests.Find(id);
            return data;
        }

        public void UpdateData(LabTest labTest)
        {
            _dbContext.LabTests.Find(labTest.Id);
            _dbContext.SaveChanges();
        }
    }
}
