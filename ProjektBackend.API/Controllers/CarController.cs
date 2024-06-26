using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektBackend.Application.Services;
using ProjektBackend.Core.Entities;

namespace ProjektBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;
        private readonly CategoryService _categoryService;

        public CarController(CarService carService, CategoryService categoryService)
        {
            _carService = carService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cars = _carService.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetDetails(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Cars car)
        {
            if (!_categoryService.CategoryExists(car.CategoryId))
            {
                return BadRequest("Invalid Category selected.");
            }

            var selectedCategory = _categoryService.GetCategoryById(car.CategoryId);
            if (selectedCategory != null)
            {
                car.CategoryName = selectedCategory.CategoryName;
            }

            _carService.AddCar(car);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, Cars car)
        {
            if (id != car.CarId)
            {
                return BadRequest("Car ID in the route does not match the Car ID in the request body.");
            }

            if (!_categoryService.CategoryExists(car.CategoryId))
            {
                return BadRequest("Invalid Category selected.");
            }

            var selectedCategory = _categoryService.GetCategoryById(car.CategoryId);
            if (selectedCategory != null)
            {
                car.CategoryName = selectedCategory.CategoryName;
            }

            _carService.UpdateCar(car);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            _carService.DeleteCar(car);
            return Ok();
        }
    }
}
