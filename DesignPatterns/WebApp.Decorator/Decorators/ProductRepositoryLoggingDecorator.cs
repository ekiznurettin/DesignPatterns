using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Decorator.Models;
using WebApp.Decorator.Repositories;

namespace WebApp.Decorator.Decorators
{
    public class ProductRepositoryLoggingDecorator : BaseProductRepositoryDecorator
    {
        private readonly ILogger<ProductRepositoryLoggingDecorator> _logger;
        public ProductRepositoryLoggingDecorator(IProductRepository productRepository, ILogger<ProductRepositoryLoggingDecorator> logger) : base(productRepository)
        {
            _logger = logger;
        }

        public override Task<List<Product>> GetAll()
        {
            _logger.LogInformation("GetAll metodu çalıştı");
            return base.GetAll();
        }
        public override Task<List<Product>> GetAll(string UserId)
        {
            _logger.LogInformation("GetAll(string UserId) metodu çalıştı");
            return base.GetAll(UserId);
        }
        public override Task<Product> Save(Product product)
        {
            _logger.LogInformation("Save(Product product) metodu çalıştı");
            return base.Save(product);
        }
        public override Task Update(Product product)
        {
            _logger.LogInformation("Update(Product product) metodu çalıştı");
            return base.Update(product);
        }
        public override Task Remove(Product product)
        {
            _logger.LogInformation("Remove(Product product) metodu çalıştı");
            return base.Remove(product);
        }
    }
}
