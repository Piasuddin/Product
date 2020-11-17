using MyWesite.DAL.Models;
using MyWesite.DAL.Repository;
using MyWesite.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWebsite.BLL
{
    public class CategoryBLL
    {
        private readonly IRepository<Category> repository;

        public CategoryBLL(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<CategoryViewModel> GetCategory()
        {
            try
            {
                IEnumerable<Category> categories = repository.Get();
                List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
                if (categories != null)
                {
                    foreach(Category category in categories)
                    {
                        CategoryViewModel categoryViewModel = new CategoryViewModel
                        {
                            Id = category.Id,
                            Name = category.Name,
                            ParentCategoryId = category.ParentCategoryId
                        };
                        categoryViewModels.Add(categoryViewModel);
                    }
                    return categoryViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> GetCategoryByIdAsync(long id)
        {
            try
            {
                Category category = await repository.GetAsync(id);
                if (category != null)
                {
                    CategoryViewModel categoryViewModel = new CategoryViewModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        ParentCategoryId = category.ParentCategoryId
                    };
                    return categoryViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> AddCategoryAsync(CategoryViewModel categoryViewModel)
        {
            try
            {
                Category category = new Category
                {
                    Name = categoryViewModel.Name,
                    ParentCategoryId = categoryViewModel.ParentCategoryId
                };
                Category result = await repository.AddAsync(category);
                if (result != null)
                {
                    return AssignDataToCategoryViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> UpdateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            try
            {
                Category category = await repository.GetAsync((long)categoryViewModel.Id);
                if (category != null)
                {
                    category.Name = categoryViewModel.Name;
                    category.ParentCategoryId = (long)categoryViewModel.ParentCategoryId;

                    Category result = await repository.UpdateAsync(category);
                    if (result != null)
                    {
                        return AssignDataToCategoryViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> DeleteCategoryAsync(CategoryViewModel categoryViewModel)
        {
            try
            {
                Category category = await repository.GetAsync((long)categoryViewModel.Id);
                if (category != null)
                {
                    Category result = await repository.RemoveAsync(category);
                    if (result != null)
                    {
                        return AssignDataToCategoryViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        private CategoryViewModel AssignDataToCategoryViewModel(Category category)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
            return categoryViewModel;
        }
    }
}
