using AutoMapper;
using CoreWebAPIAngualarPOC.Controllers;
using CoreWebAPIAngualarPOC.Interfaces;
using CoreWebAPIAngualarPOC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private List<Department> deptList;
        [TestInitialize]
        public void TestInitialize()
        {
            deptList = new List<Department>
            {
                new Department{DepartmentId=1,DepartmentName="IT"},
                new Department{DepartmentId=2,DepartmentName="HR"}
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
            var mockRepository = new Mock<IGenericRepository<Department>>();
            var mockMapper = new Mock<IMapper>();
            mockRepository.Setup(p => p.GetAll()).Returns(deptList);
            DepartmentController home = new DepartmentController(mockMapper.Object, mockRepository.Object);
            var result = home.Get();
            Assert.IsNotNull(result);
        }
    }
}
