using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sq5Testing.apipro.Controllers;
using Sq5Testing.apipro.Models;
using Sq5Testing.apipro.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SQ5Testing.Test1
{
    [TestClass]
    public class TestCategory
    {
        private readonly CategoryController categoryController;
        private readonly Mock<ICategoryRepository> mock = new Mock<ICategoryRepository>();
        public TestCategory()
        {
            categoryController = new CategoryController(mock.Object);
        }
        [TestMethod]
        public async Task GetAllCategory_ShouldReturnAllCategory()
        {
            mock.Setup(x => x.GetCategory())
                .ReturnsAsync(GetCategories());
            var category = await categoryController.GetAllCategory();
            Assert.AreEqual(GetCategories().Count, category.Count);
        }
        [TestMethod]
        public async Task GetCategoryById_ShouldReturnOneCategory()
        {

            var categoryId = Guid.NewGuid();
            Category cate = new Category()
            {
                CategoryId = categoryId,
                CategoryName = "Food"
            };
            mock.Setup(x => x.GetCategoryById(categoryId))
                .ReturnsAsync(cate);
            var result = await categoryController.Get(categoryId);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [TestMethod]
        public async Task GetCategoryById_ShouldReturnNotFound()
        {

            var categoryId = Guid.NewGuid();
            Category cate = new Category()
            {
                CategoryId = categoryId,
                CategoryName = "Food"
            };
            mock.Setup(x => x.GetCategoryById(categoryId))
                .ReturnsAsync(cate);
            var result = await categoryController.Get(Guid.NewGuid());
            var okResult = result as NotFoundResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(404, okResult.StatusCode);
        }
        [TestMethod]
        public async Task PostCategory_ShouldReturnOk()
        {

            var categoryId = Guid.NewGuid();
            Category cate = new Category()
            {
                CategoryId = categoryId,
                CategoryName = "Food"
            };
            mock.Setup(x => x.SaveCategory(cate))
                .ReturnsAsync(true);
            var result = await categoryController.Post(cate);
            var okResult = result as OkResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [TestMethod]
        public async Task PostCategory_ShouldReturnBadRequest()
        {

            var categoryId = Guid.NewGuid();
            Category cate = new Category()
            {
                CategoryId = categoryId,
                CategoryName = ""
            };
            mock.Setup(x => x.SaveCategory(cate))
                .ReturnsAsync(false);
            var result = await categoryController.Post(cate);
            var okResult = result as BadRequestObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
        }
        [TestMethod]
        public async Task DeleteCategory_ShouldReturnBadRequest()
        {
            var categoryId = Guid.NewGuid();
            mock.Setup(x => x.DeleteCategory(categoryId))
                .ReturnsAsync(false);
            var result = await categoryController.Delete(Guid.NewGuid());
            var okResult = result as BadRequestObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
        }
        [TestMethod]
        public async Task DeleteCategory_ShouldReturnOk()
        {
            var categoryId = Guid.NewGuid();
            mock.Setup(x => x.DeleteCategory(categoryId))
                .ReturnsAsync(true);
            var result = await categoryController.Delete(categoryId);
            var okResult = result as OkResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
        public List<Category> GetCategories()
        {
            var cate = new List<Category>();
            cate.Add(new Category { CategoryId = Guid.NewGuid(), CategoryName = "Food" });
            cate.Add(new Category { CategoryId = Guid.NewGuid(), CategoryName = "Drink" });
            return cate;
        }
    }
}
