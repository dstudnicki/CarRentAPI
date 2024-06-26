using ProjektBackend.Core.Entities;
using ProjektBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackend.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext _context;

        public CarRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Cars> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Cars GetCarById(int carId)
        {
            return _context.Cars.Find(carId);
        }

        public void AddCar(Cars car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Cars car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(Cars car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}
