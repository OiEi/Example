using Example.Models;
using System.Collections.Generic;
using System.Linq;


namespace Example.Interfaces
{
    public class CompanyRepository : Repository
    {
        public CompanyRepository(MyDbContext context) : base(context)
        { }
        public List<Employee> GetEmployeesInCompany(int companyid)
        {
            return (from e in this.GetAll<Employee>()
                    where e.CompanyId == companyid
                    select e).ToList();
        }
    }
}