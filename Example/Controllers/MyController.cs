using Example.Interfaces;
using Example.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net.Http;
using System.Net;

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
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _repo.GetEntity<Employee>();
        }

        [Route("api/get_empl/{companyid}")]
        public List<Employee> GetEmplInCompany(int companyid)
        {
            
            return  _repo.GetEntity<Employee>().Where(e=> e.CompanyId == companyid).ToList();
        }

        [Route("api/delete_empl/{Id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var employee = _repo.GetEntity<Employee>().Where(e=> e.id == Id).FirstOrDefault();
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id {Id} not found");
            }
            else
            {                
                _repo.DeleteEntity(employee);
                _repo.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, $"Employee with id {Id} was remove");
            }
        }


    }
}
