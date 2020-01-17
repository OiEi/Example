using Example.Interfaces;
using Example.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Example.Controllers
{
    public class MyController : ApiController
    {
        private readonly IRepository _repo;
        public MyController(IRepository repository)
        {
            _repo = repository;
        }

        [Route("api/get_all/employee")]
        public  IEnumerable<Employee> GetAllEmployee()
        {
            return _repo.GetAll<Employee>();
        }

/*        [Route("api/get_empl/{companyid}")]
        public IEnumerable<Employee> GetEmplInCompany(int companyid)
        {
            return _repo.GetAll<Company>();
        }*/



    }
}
