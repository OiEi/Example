using Example.Interfaces;
using Example.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace Example.Controllers
{
    public class MyController : ApiController
    {
        private readonly IRepository _repo;
        public MyController(IRepository repository)
        {
            _repo = repository;
        }

        [Route("api/get_employees")]
        public  IEnumerable<Employee> GetAllEmployee()
        {
            return _repo.GetAll<Employee>();
        }
               
        [Route("api/get_empl/{companyid}")]
        public List<Employee> GetEmplInCompany(int companyid)
        {
            return (from u in _repo.GetAll<Employee>() where u.CompanyId == companyid select u).ToList();
        }
    }
}
