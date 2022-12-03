using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Create_and_save_a_blog()
        {
            var mockSet = new Mock<DbSet<Blog>>();

            var mockContext = new Mock<BloggingContext>();
            mockContext.Setup(m=>m.Blogs).Returns(mockSet.Object);

            var service = new BlogService(mockContext.Object);
            service.AddBlog("Test Blog", "www.blogs.com/testblog1");

            mockSet.Verify(m=>m.Add(It.IsAny<Blog>()));
            mockContext.Verify(m => m.SaveChanges());
        }

        [Fact]
        public void GetAllBlogs_orders_by_name()
        {
            var data = new List<Blog>
            {
                new Blog {Name="B"},
                new Blog {Name="C"},
                new Blog {Name="A"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Blog>>();

            mockSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Blog>>().Setup(m=>m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BloggingContext>();
            mockContext.Setup(m => m.Blogs).Returns(mockSet.Object);

            var service = new BlogService(mockContext.Object);
            var blogs = service.GetAllBlogs();

            Assert.Equal(3, blogs.Count);
            Assert.Equal("A", blogs[0].Name);
            Assert.Equal("B", blogs[1].Name);
            Assert.Equal("C", blogs[2].Name);

        }

    }
}
