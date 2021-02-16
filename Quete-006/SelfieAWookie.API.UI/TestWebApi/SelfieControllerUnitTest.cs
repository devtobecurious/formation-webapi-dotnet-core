using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookies.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestWebApi
{
    public class SelfieControllerUnitTest
    {
        #region Public methods
        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            // ARRANGE
            var expectedList = new List<Selfie>()
            {
                new Selfie() { Wookie = new Wookie() },
                new Selfie() { Wookie = new Wookie() }
            };
            var repositoryMock = new Mock<ISelfieRepository>();

            repositoryMock.Setup(item => item.GetAll()).Returns(expectedList);

            var controller = new SelfiesController(repositoryMock.Object);

            // ACT
            var result = controller.TestAMoi();

            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.IsType<List<SelfieResumeDto>>(okResult.Value);

            List<SelfieResumeDto> list = okResult.Value as List<SelfieResumeDto>;
            Assert.True(list.Count == expectedList.Count);
        }
        #endregion
    }
}
