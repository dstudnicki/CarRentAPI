using Microsoft.AspNetCore.Cors.Infrastructure;
using ProjektBackend.Core.Entities;
using ProjektBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektBackend.Infrastructure.Repositories;

namespace ProjektBackend.Application.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<Cars> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }

        public Cars GetCarById(int carId)
        {
            return _carRepository.GetCarById(carId);
        }

        public void AddCar(Cars car)
        {
            _carRepository.AddCar(car);
        }

        public void UpdateCar(Cars car)
        {
            _carRepository.UpdateCar(car);
        }

        public void DeleteCar(Cars car)
        {
            _carRepository.DeleteCar(car);
        }
    }
}
