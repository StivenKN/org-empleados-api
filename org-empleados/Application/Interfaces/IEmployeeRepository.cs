namespace org_empleados.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<string> ListAll();
        Task<bool> ListOne();
        Task<string> Create();
    }
}
