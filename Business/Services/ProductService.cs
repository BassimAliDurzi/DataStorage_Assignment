using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class ProductService(ProductRepository productRepository)
{
    private readonly ProductRepository _productRepository = productRepository;

    public async Task CreateProductAsync(ProductForm form)
    {
        var productEntity = ProductFactory.Create(form);
        await _productRepository.CreateAsync(productEntity!);
    }

    public async Task<IEnumerable<Prodcut?>> GetProductAsync()
    {
        var productEntities = await _productRepository.GetAllAsync();
        return productEntities.Select(ProductFactory.Create);

    }

    public async Task<Prodcut?> GetProductByIdAsync(int id)
    {
        var productEntity = await _productRepository.GetByIdAsync(id);
        return ProductFactory.Create(productEntity!);
    }


    public async Task<bool> UpdateProductAsync(ProductForm form)
    {
        var productEntity = ProductFactory.Create(form);
        return await _productRepository.UpdateAsync(productEntity!);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }


}
