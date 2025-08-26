namespace EddTech.ConsoleApp.Repo;

public sealed class InMemoryRepository<T> : IRepository<T>
{
    private readonly Dictionary<string, T> _store = new();

    public void Save(string id, T entity) => _store[id] = entity;
    public T? FindById(string id) => _store.TryGetValue(id, out var v) ? v : default;
    public IReadOnlyList<T> FindAll() => _store.Values.ToList();
    public void Delete(string id) => _store.Remove(id);
}
