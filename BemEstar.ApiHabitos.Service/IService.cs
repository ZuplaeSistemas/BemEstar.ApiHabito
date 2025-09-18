namespace DefaultNamespace;

public interface IService
{
    void Create(T model);
    List<T> Read();
    void Update(T model);
    void Delete(int id);
    T ReadById(int id); 
}