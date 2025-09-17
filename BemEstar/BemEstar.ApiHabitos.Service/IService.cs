namespace BemEstar.ApiHabitos.Service;

public interface IService <T>
{
       
    void Create(T model);
    List<T> Read();
    void Update(T model);
    void Delete(int id);
    T ReadById(int id);
}