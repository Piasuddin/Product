using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
    public class ProductController : ControllerBase
    {
        private readonly ProductBLL productBLL;
        private readonly IRepository<Product> repository;

        public ProductController(IRepository<Product> repository, IRepository<Category> categoryRepository)
        {
            this.productBLL = new ProductBLL(repository, categoryRepository);
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                IEnumerable<ProductViewModel> products = productBLL.Get();
                if (products != null)
                {
                    return Ok(new { status = 200, obj = products });
                }
                return BadRequest(new { status = 400, message = "Sorry! No product is available." });
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again." });
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                ProductViewModel products = await productBLL.GetByIdAsync(id);
                if (products != null)
                {
                    return Ok(new { status = 200, obj = products });
                }
                return BadRequest(new { status = 400, message = "Sorry! No product is available." });
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again." });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductViewModel result = await productBLL.AddAsync(model);
                    if (result != null)
                    {
                        return Ok(new { status = 200, message = "Product added succesfull.", obj = result });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again." });
        }
        [HttpPut]
        public async Task<ActionResult> Put(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductViewModel result = await productBLL.UpdateAsync(model);
                    if (result != null)
                    {
                        return Ok(new { status = 200, message = "Product Updated succesfull.", obj = result });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again" });
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductViewModel result = await productBLL.DeleteAsync(id);
                    if (result != null)
                    {
                        return Ok(new { status = 200, message = "Product Deleted succesfull.", obj = result });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again" });
        }
        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> Details(long id)
        {
            try
            {
                if (id > 0)
                {
                    ProductDetailsViewModel productDetailsViewModel = await productBLL.GetDetails(id);
                    if (productDetailsViewModel != null)
                    {
                        return Ok(new { status = 200, message = "Data retrieve succesfull.", obj = productDetailsViewModel });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again" });
        }
        [HttpGet]
        [Route("tableData")]
        public async Task<ActionResult> TableData()

        {
            try
            {
                List<ProductDetailsViewModel> productDetailsViewModel = productBLL.GetTableData();
                if (productDetailsViewModel != null)
                {
                    return Ok(new { status = 200, message = "Data retrieve succesfull.", obj = productDetailsViewModel });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 400, message = "Sorry! Something went wrong please try again" });
        }
    }
}