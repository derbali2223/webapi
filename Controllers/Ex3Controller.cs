using Exercices10.Models;
using Exercices10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercices10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ex3Controller : ControllerBase
    {
        private readonly IMessageService service;
        private readonly ICustomerRepository repository;

        public Ex3Controller(IMessageService service, ICustomerRepository repository)
        {
            this.service = service;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult call1()
        {
            return Ok(service.sayhello());
        }

        
        [HttpGet]
        [Route("customers")]
        public IActionResult getAll()
        {
            return Ok(repository.GetCustomers());
        }

        [HttpPost]
        [Route("customers")]
        public IActionResult add([FromBody] Customer2 customer)
        {
            if (ModelState.IsValid)
            {
                return Ok(repository.AddCustomer(customer));
            }
            return BadRequest("Opération d'ajout non exécutée");
        }

        [HttpPut]
        [Route("customers/{id}")]
        public IActionResult modify(int id, [FromBody] Customer2 customer)
        {
            if (ModelState.IsValid)
            {
                Customer2 old = repository.GetCustomerById(id);
                if (old != null) {
                    old.FirstName = customer.FirstName;
                    old.LastName = customer.LastName;
                    old.Gender = customer.Gender;
                    return Ok(repository.UpdateCustomer(old));
                } 
            }
            return BadRequest("Opération de mise à jour non exécutée");
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public IActionResult remove(int id)
        {
                Customer2 customer = repository.GetCustomerById(id);
                if(customer != null)
                    return Ok(repository.DeleteCustomer(customer));
                return BadRequest("Opération de suppression non exécutée");
        }


    }
}
