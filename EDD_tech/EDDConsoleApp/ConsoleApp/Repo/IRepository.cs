namespace EddTech.ConsoleApp.Repo;

public interface IRepository<T>
{
    void Save(string id, T entity);
    T? FindById(string id);
    IReadOnlyList<T> FindAll();
    void Delete(string id);
}
