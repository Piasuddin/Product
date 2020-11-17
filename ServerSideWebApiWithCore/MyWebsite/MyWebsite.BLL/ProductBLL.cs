using Microsoft.AspNetCore.Hosting;
using MyWesite.DAL.Models;
using MyWesite.DAL.Repository;
using MyWesite.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebsite.BLL
{
    public class ProductBLL
    {
        private readonly IRepository<Product> repository;
        private readonly IRepository<Category> categoryRepository;

        public ProductBLL(IRepository<Product> repository, IRepository<Category> categoryRepository)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
        }
        public IEnumerable<ProductViewModel> Get()
        {
            try
            {
                IEnumerable<Product> products = repository.Get();
                List<ProductViewModel> productViewModels = new List<ProductViewModel>();
                if (products != null)
                {
                    foreach (Product product in products)
                    {
                        ProductViewModel productViewModel = new ProductViewModel
                        {
                            CategoryId = product.CategoryId,
                            Id = product.Id,
                            Name = product.Name,
                            CreatedDate = product.CreatedDate
                        };
                        productViewModels.Add(productViewModel);
                    }
                    return productViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> GetByIdAsync(long id)
        {
            try
            {
                Product product = await repository.GetAsync(id);
                if (product != null)
                {
                    ProductViewModel productViewModel = new ProductViewModel
                    {
                        CategoryId = product.CategoryId,
                        Id = product.Id,
                        Name = product.Name,
                        CreatedDate = product.CreatedDate
                    };
                    return productViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> AddAsync(ProductViewModel model)
        {
            try
            {
                Product product = new Product
                {
                    CategoryId = model.CategoryId,
                    CreatedDate = DateTime.UtcNow,
                    Name = model.Name
                };
                Product result = await repository.AddAsync(product);
                if(result != null)
                {
                    return AssignDataToProductViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> UpdateAsync(ProductViewModel model)
        {
            try
            {
                Product product = await repository.GetAsync((long)model.Id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.CategoryId = model.CategoryId;

                    Product result = await repository.UpdateAsync(product);
                    if (result != null)
                    {
                        return AssignDataToProductViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> DeleteAsync(long id)
        {
            try
            {
                Product product = await repository.GetAsync(id);
                if (product != null)
                {
                    Product result = await repository.RemoveAsync(product);
                    if (result != null)
                    {
                        return AssignDataToProductViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ProductViewModel AssignDataToProductViewModel(Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                CreatedDate = product.CreatedDate,
                Id = product.Id
            };
            return productViewModel;
        }
        public async Task<ProductDetailsViewModel> GetDetails(long id)
        {
            try
            {
                Product product = await repository.GetAsync(id);
                if (product != null)
                {
                    ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel
                    {
                        Id = product.Id,
                        CategoryName = categoryRepository.GetAsync(product.CategoryId).Result.Name,
                        CreatedDate = product.CreatedDate,
                        Name = product.Name
                    };
                    return productDetailsViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public List<ProductDetailsViewModel> GetTableData()
        {
            try
            {
                IEnumerable<Product> products = repository.Get();
                if (products != null)
                {
                    List<ProductDetailsViewModel> productDetailsViewModels = new List<ProductDetailsViewModel>();
                    foreach (Product product in products)
                    {
                        ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel
                        {
                            Id = product.Id,
                            CategoryName = categoryRepository.GetAsync(product.CategoryId).Result.Name,
                            CreatedDate = product.CreatedDate,
                            Name = product.Name
                        };
                        productDetailsViewModels.Add(productDetailsViewModel);
                    }
                    return productDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}
