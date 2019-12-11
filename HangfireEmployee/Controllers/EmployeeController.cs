namespace HangfireEmployee.Controllers
{
    using DAL.Repository;
    using Microsoft.AspNetCore.Mvc;
    using HangfireEmployee.Models;
    using DAL.Models;
    using System.Collections.Generic;
    using Hangfire;

    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository EmployeeRepository;
        private readonly EventRepository EventRepository;
        public EmployeeController()
        {
            EmployeeRepository = new EmployeeRepository();
            EventRepository = new EventRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            var employeeList = EmployeeRepository?.GetEmployees();
            var employeeDtoList = new List<EmployeeDto>();
            foreach(var employee in employeeList)
            {
                var employeeDto = new EmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name
                };
                employeeDtoList.Add(employeeDto);
            }
            return View(employeeDtoList);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var addEmployeeDto = new AddEmployeeDto();
            return View(addEmployeeDto);
        }

        [HttpPost]
        public ActionResult Create(AddEmployeeDto addEmployeeDto)
        {
            Employee employee = new Employee()
            {
                Name= addEmployeeDto.Name
            };

            EmployeeRepository.AddEmployee(employee);
            BackgroundJob.Enqueue(() => AddNewEvent(employee.Name));
            return Redirect("/");
        }

        public void AddNewEvent(string employeeName)
        {
            string eventDescription = employeeName + "Added";
            Event @event = new Event()
            {
                EventDescription = eventDescription
            };
            EventRepository.AddEvent(@event);
        }


    }
}