using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        private IClassScheduleUnitOfWork GetUnitOfWork()
        {
            //days teachers classes
            var dayRep = new Mock<IRepository<Day>>();
            dayRep.Setup(m => m.List(It.IsAny<QueryOptions<Day>>())).Returns(new List<Day>());

            var teacherRep = new Mock<IRepository<Teacher>>();
            teacherRep.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>())).Returns(new List<Teacher>());

            var classRep = new Mock<IRepository<Class>>();
            classRep.Setup(m => m.List(It.IsAny<QueryOptions<Class>>())).Returns(new List<Class>());

            var unit = new Mock<IClassScheduleUnitOfWork>();
            unit.Setup(m => m.Days).Returns(dayRep.Object);
            unit.Setup(m => m.Teachers).Returns(teacherRep.Object);
            unit.Setup(m => m.Classes).Returns(classRep.Object);
            return unit.Object;
        }
        
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var accessor = new Mock<IHttpContextAccessor>();
            var context = new DefaultHttpContext();

            accessor.Setup(m => m.HttpContext).Returns(context);
            accessor.Setup(m => m.HttpContext.Request).Returns(context.Request);
            accessor.Setup(m => m.HttpContext.Response).Returns(context.Response);
            accessor.Setup(m => m.HttpContext.Request.Cookies).Returns(context.Request.Cookies);
            accessor.Setup(m => m.HttpContext.Response.Cookies).Returns(context.Response.Cookies);

            var session = new Mock<ISession>();
            accessor.Setup(m => m.HttpContext.Session).Returns(session.Object);

            var unit = GetUnitOfWork();
            var controller = new HomeController(unit, accessor.Object);

            // act
            var result = controller.Index(1);

            // assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
