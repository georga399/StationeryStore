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
    public void CreateCategory(CategoryViewModel model)
    {    
        Category category = _mapper.Map<CategoryViewModel, Category>(model);
        _dbContext.Categories.Add(category);
    }
    public void CreateProduct()
    {
        
    }
    public void EditProduct()
    {
        
    }
}