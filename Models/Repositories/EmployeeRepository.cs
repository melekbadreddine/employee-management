using System;
using System.Collections.Generic;
using System.Linq;

namespace VotreNamespace.Models.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        List<Employee> lemployees;

        public EmployeeRepository()
        {
            lemployees = new List<Employee>()
            {
                new Employee {Id=1,Name="Sofien ben ali", Departement= "comptabilité",Salary=1000},
                new Employee {Id=2,Name="Mourad triki", Departement= "RH",Salary=1500},
                new Employee {Id=3,Name="ali ben mohamed", Departement= "informatique",Salary=1700},
                new Employee {Id=4,Name="tarak aribi", Departement= "informatique",Salary=1100}
            };
        }

        public void Add(Employee e)
        {
            e.Id = lemployees.Max(emp => emp.Id) + 1;
            lemployees.Add(e);
        }

        public void Delete(int id)
        {
            var employee = lemployees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
                lemployees.Remove(employee);
        }

        public Employee FindByID(int id)
        {
            return lemployees.FirstOrDefault(e => e.Id == id);
        }

        public IList<Employee> GetAll()
        {
            return lemployees;
        }

        public List<Employee> Search(string term)
        {
            return lemployees.Where(e => e.Name.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Update(int id, Employee newemployee)
        {
            var employee = lemployees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.Name = newemployee.Name;
                employee.Departement = newemployee.Departement;
                employee.Salary = newemployee.Salary;
            }
        }
    }
}