using tp3.Models;
namespace tp3.Models.Repositories
{
public class EmployeeRepository : IRepository<Employee>
{
    private List<Employee> Iemployees;

    public EmployeeRepository()
    {
        Iemployees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Sofien ben ali", Departement = "comptabilité", Salary = 1000 },
            new Employee { Id = 2, Name = "Mourad triki", Departement = "RH", Salary = 1500 },
            new Employee { Id = 3, Name = "ali ben mouhamed", Departement = "informatique", Salary = 1700 },
            new Employee { Id = 4, Name = "tarak aribi", Departement = "informatique", Salary = 1100 }
        };
    }

    public void Add(Employee e)
    {
        Iemployees.Add(e);
    }

    public void Delete(int id)
    {
        var employee = Iemployees.FirstOrDefault(emp => emp.Id == id);
        if (employee != null)
            Iemployees.Remove(employee);
    }

    public Employee? FindByID(int id)
    {
        return Iemployees.FirstOrDefault(emp => emp.Id == id);
    }

    public IList<Employee> GetAll()
    {
        return Iemployees;
    }

    public List<Employee> Search(string term)
    {
        return Iemployees
            .Where(emp => emp.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();
    }

    public void Update(int id, Employee newemployee)
    {
        var employee = Iemployees.FirstOrDefault(emp => emp.Id == id);
        if (employee != null)
        {
            employee.Name = newemployee.Name;
            employee.Departement = newemployee.Departement;
            employee.Salary = newemployee.Salary;
        }
    }
}
}