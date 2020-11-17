using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.BLL;
using MyWesite.DAL.Models;
using MyWesite.DAL.Repository;
using MyWesite.DAL.ViewModels;

namespace MyWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryBLL categoryBLL;

        public CategoryController(IRepository<Category> repository)
        {
            this.categoryBLL = new CategoryBLL(repository);
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                IEnumerable<CategoryViewModel> category = categoryBLL.GetCategory();
                if (category != null)
                {
                    return Ok(new { status = 200, obj = category });
                }
                return BadRequest(new { status = 400, message = "Sorry! No Category is available." });
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again." });
        }
        [HttpPost]
        public async Task<ActionResult> Post(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryViewModel result = await categoryBLL.AddCategoryAsync(categoryViewModel);
                    if (result != null)
                    {
                        return Ok(new { status = 200, message = "Category added succesfull.", obj = result });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again." });
        }
        [HttpPut]
        public async Task<ActionResult> Put(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryViewModel result = await categoryBLL.UpdateCategoryAsync(categoryViewModel);
                    if (result != null)
                    {
                        return Ok(new { status = 200, message = "Category Updated succesfull.", obj = result });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again" });
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryViewModel result = await categoryBLL.DeleteCategoryAsync(categoryViewModel);
                    if (result != null)
                    {
                        return Ok(new { status = 200, message = "Category Deleted succesfull.", obj = result });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again" });
        }
    }
}