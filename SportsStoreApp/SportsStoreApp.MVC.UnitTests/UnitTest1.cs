using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Entities;
using Moq;
using System.Linq;
using System.Collections.Generic;
using SportsStoreApp.MVC.WebUI.Controllers;
using System.Web.Mvc;
using SportsStoreApp.MVC.WebUI.HtmlHelpers;
using SportsStoreApp.MVC.WebUI.Models;

namespace SportsStoreApp.MVC.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                 new Product {ProductId = 1, Name = "P1"},
                 new Product {ProductId = 2, Name = "P2"},
                 new Product {ProductId = 3, Name = "P3"},
                 new Product {ProductId = 4, Name = "P4"},
                 new Product {ProductId = 5, Name = "P5"}
              }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            //Act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(null,2).Model;
        
            //Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //Arrange
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo { CurrentPage = 2, TotalItems = 28, ItemPerPage = 10 };
            Func<int, string> pageUrlDelegate = i => "Page" + i.ToString();

            //Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>" + @"<a class=""selected"" href=""Page2"">2</a>" + @"<a href=""Page3"">3</a>");
        }
    }
}
