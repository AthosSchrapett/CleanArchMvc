using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;

namespace CleanArchMvc.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ICategoryRepository? _categoryRepository;
    private IProductRepository? _productRepository;

    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context) => _context = context;

    public ICategoryRepository CategoryRepository
    {
        get => _categoryRepository = _categoryRepository != null ? _categoryRepository : new CategoryRepository(_context);
    }

    public IProductRepository ProductRepository
    {
        get => _productRepository = _productRepository != null ? _productRepository : new ProductRepository(_context);
    }

    public async Task<int> Commit()
    {
        return await _context.SaveChangesAsync();
    }


    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }

        GC.SuppressFinalize(this);
    }

}
