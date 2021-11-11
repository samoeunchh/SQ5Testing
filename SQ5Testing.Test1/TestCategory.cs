using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sq5Testing.apipro.Controllers;
using Sq5Testing.apipro.Models;
using Sq5Testing.apipro.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQ5Testing.Test1
{
    [TestClass]
    public class TestCategory
    {
        [TestMethod]
        public void GetAllCategory_ShouldReturnAllCategory()
        {
            var testProducts = GetTestCategory();
            var controller = new CategoryController(testProducts);

            var result = controller.GetAllCategory() as List<Category>;
            Assert.AreEqual(testProducts.Count, result.Count);

        }
        private List<Category> GetTestCategory()
        {
            var testProducts = new List<Category>();
            testProducts.Add(new Category { CategoryId =Guid.NewGuid() , CategoryName = "Cate1"});
            testProducts.Add(new Category { CategoryId = Guid.NewGuid(), CategoryName = "Cate2" });
            return testProducts;
        }
    }
}
