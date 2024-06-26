using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjektBackend.Core.Entities;
using ProjektBackend.Core.Interfaces;
using ProjektBackend.Shared.Models;

namespace ProjektBackendLab.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            ICarRepository carRepository, ICategoryRepository categoryRepository, IClientRepository clientRepository,
            IOrderRepository orderRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await CreateAdminUser();

            var cars = _carRepository.GetAllCars();

            return Ok(cars); // Zwraca listę samochodów jako odpowiedź HTTP 200 OK
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound(); // Zwraca 404 Not Found, jeśli samochód nie istnieje
            }
            return Ok(car); // Zwraca szczegóły samochodu jako odpowiedź HTTP 200 OK
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Cars car)
        {
            var categoryExists = _categoryRepository.CategoryExists(car.CategoryId);

            if (!categoryExists)
            {
                return BadRequest("Invalid Category selected."); // Zwraca błąd 400 Bad Request
            }

            var selectedCategory = _categoryRepository.GetCategoryById(car.CategoryId);
            if (selectedCategory != null)
            {
                car.CategoryName = selectedCategory.CategoryName;
            }

            _carRepository.AddCar(car);

            return Ok(); // Zwraca pusty wynik jako odpowiedź HTTP 200 OK
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, Cars car)
        {
            if (id != car.CarId)
            {
                return BadRequest("Car ID in the route does not match the Car ID in the request body.");
            }

            var categoryExists = _categoryRepository.CategoryExists(car.CategoryId);

            if (!categoryExists)
            {
                return BadRequest("Invalid Category selected.");
            }

            var selectedCategory = _categoryRepository.GetCategoryById(car.CategoryId);
            if (selectedCategory != null)
            {
                car.CategoryName = selectedCategory.CategoryName;
            }

            _carRepository.UpdateCar(car);

            return Ok(); // Zwraca pusty wynik jako odpowiedź HTTP 200 OK
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound(); // Zwraca 404 Not Found, jeśli samochód nie istnieje
            }

            _carRepository.DeleteCar(car);

            return Ok(); // Zwraca pusty wynik jako odpowiedź HTTP 200 OK
        }

        private async Task CreateAdminUser()
        {
            string roleName = "Administrator";
            IdentityResult roleResult;

            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExist)
            {
                roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var user = await _userManager.FindByEmailAsync("admin@admin.pl");

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "admin@admin.pl",
                    Email = "admin@admin.pl",
                };
                await _userManager.CreateAsync(user, "Admin123@");
            }

            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
