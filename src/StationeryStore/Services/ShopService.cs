using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;
using StationeryStore.Data;
using StationeryStore.Data.DAOs;
using StationeryStore.Models;
namespace StationeryStore.Services;
public class ShopService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<ShopService> _logger;
    public ShopService(ApplicationDbContext dbContext, 
        IMapper mapper, ILogger<ShopService> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }
    public bool AddToCart(CartProductViewModel model, string UserId)
    {
        _logger.LogInformation($"find prod {model.Id}");
        var foundProduct = _dbContext.Products
            .FirstOrDefault(p => /*p.Name == model.Product.Name 
                &&*/ p.Id == model.Product.Id);
        if(foundProduct == null)
            return false;
        _logger.LogInformation("Before mapping");
        CartProduct cartProduct =  _mapper.Map<CartProductViewModel, CartProduct>(model);
        _logger.LogInformation("After map");
        cartProduct.Product = foundProduct;
        User user = _dbContext.Users.FirstOrDefault(u => u.Id == UserId)!;
        cartProduct.User = user;
        cartProduct.Id =0;
        _logger.LogInformation($"CartProduct.id: {cartProduct.Id}");
        _dbContext.CartProducts.Add(cartProduct);
        _dbContext.SaveChanges();
        return true;
    }
    public bool DeleteFromCart(CartProductViewModel model, string UserId)
    {
        var foundProduct = _dbContext.CartProducts
            .FirstOrDefault(p => p.Id == model.Id);
        if(foundProduct == null)
            return false;
        _dbContext.CartProducts.Remove(foundProduct);
        _dbContext.SaveChanges();
        return true;
    }
    public ProductViewModel? GetProductInfo(int id)
    {
        var foundProduct = _dbContext.Products
            .FirstOrDefault(p => p.Id == id);
        if(foundProduct == null)
            return null;
        ProductViewModel model = _mapper
            .Map<Product, ProductViewModel>(foundProduct);   
        return model;
    }
    public IEnumerable<ProductViewModel> GetProducts()
    {
        var products = _dbContext.Products.AsEnumerable();
        var models = _mapper
            .Map<IEnumerable<Product>, 
                IEnumerable<ProductViewModel>>(products);
        return models;
    }
    public IEnumerable<CartProductViewModel> GetCartProducts(string userId)
    {
    
        var user = _dbContext
        .Users
        .Include(u => u.Cart)
        .ThenInclude(c => c.Product)
        .FirstOrDefault(u => u.Id == userId);
        var cartProducts = user!.Cart.AsEnumerable();
        var models = _mapper
            .Map<IEnumerable<CartProduct>, IEnumerable<CartProductViewModel>>(cartProducts);
        return models;
    }
}