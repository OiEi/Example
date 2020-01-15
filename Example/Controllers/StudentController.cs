using Example.Interfaces;
using Example.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Example.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IRepository _repository;
        public StudentController(IRepository repository)
        {
            _repository = repository;
        }

        [Route("api/getall")]
        public  IEnumerable<Student> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
