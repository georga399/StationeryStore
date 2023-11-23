using Microsoft.EntityFrameworkCore;
using StationeryStore.Data;
using AutoMapper;
using StationeryStore.Models;
using StationeryStore.Data.DAOs;

namespace StationeryStore.Services;
public class AdminService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public AdminService(ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public bool CreateProduct(ProductViewModel model)
    {
        Product? foundProduct = _dbContext.Products.FirstOrDefault(p => p.Name == model.Name);
        if(foundProduct != null)
            return false;
        Product product = _mapper.Map<ProductViewModel, Product>(model);
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return true;
    }
    public bool EditProduct(ProductViewModel model)
    {
        Product? foundProduct = _dbContext.Products
            .FirstOrDefault(p => p.Name == model.Name 
                && p.Id == model.Id);
        if(foundProduct == null)
            return false;
        Product product = _mapper.Map<ProductViewModel, Product>(model);
        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
        return true;
    }
    public bool DeleteProduct(ProductViewModel model)
    {
        Product? foundProduct = _dbContext.Products
            .FirstOrDefault(p => p.Name == model.Name && 
                p.Id == model.Id);
        if(foundProduct == null)
            return false;
        _dbContext.Products.Remove(foundProduct);
        _dbContext.SaveChanges();
        return true;
    }
}