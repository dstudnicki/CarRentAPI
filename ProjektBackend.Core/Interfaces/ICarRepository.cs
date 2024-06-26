using ProjektBackendLab.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackendLab.Core.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Cars> GetAllCars();
        Cars GetCarById(int carId);
        void AddCar(Cars car);
        void UpdateCar(Cars car);
        void DeleteCar(Cars car);
    }
}
