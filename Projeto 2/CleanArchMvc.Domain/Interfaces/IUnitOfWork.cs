namespace CleanArchMvc.Domain.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    Task<int> Commit();
    void Dispose();
}
