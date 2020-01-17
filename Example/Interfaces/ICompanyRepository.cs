using Example.Models;
using System.Collections.Generic;


namespace Example.Interfaces
{
    public interface ICompanyRepository : IRepository
    {
        List<Employee> GetEmployeeInCompany(int companyid);
    }
}