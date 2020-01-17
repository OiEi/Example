using Example.Interfaces;
using Example.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Example.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IRepository _studentrepository;
        public StudentController(IRepository repository)
        {
            _studentrepository = repository;
        }

        [Route("api/getall")]
        public  IEnumerable<Student> GetAllStudent()
        {
            return _studentrepository.GetAll<Student>();
        }
    }
}
