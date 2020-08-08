using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RegionAPI.Controllers;
using RegionAPI.Models;
using RegionAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace RegionApiTest.Controllers
{
 public   class CountryControllerTest
    {
        protected CountryController GetController(Mock<IRepository<CountryModel>> repository, Mock<IMapper> imapper)
        {
            var user = new Mock<ClaimsPrincipal>();
            var claims = new Claim[]
            {
                new Claim("username", "unittestusername")
            };
            user.Setup(u => u.Claims).Returns(claims);


            CountryController controller = new CountryController(repository.Object, imapper.Object);
            controller.ControllerContext = new ControllerContext()
            {

                HttpContext = new DefaultHttpContext()
                {
                    User = user.Object,

                }
            };
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer unittesttoken";
            controller.ControllerContext.HttpContext.Request.Path = new PathString("/v1/unit-test");

            return controller;
        }
        protected int GetStatusCode(IActionResult response)
        {
            return (int)response.GetType().GetProperty("StatusCode").GetValue(response, null);
        }

        [Fact]
        public void Get_return_ok()
        {
            Mock<IRepository<CountryModel>> repositoryMock = new Mock<IRepository<CountryModel>>();
            repositoryMock.Setup(s => s.GetAll()).Returns(new List<CountryModel>() { new CountryModel() });

            Mock<IMapper> imapperMock = new Mock<IMapper>();

            IActionResult response = GetController(repositoryMock, imapperMock).Get();
            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }
    }
}
