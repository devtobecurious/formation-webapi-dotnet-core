using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookies.Core.Selfies.Domain;
using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestWebApi
{
    public class SelfieControllerUnitTest
    {
        #region Public methods
        [Fact]
        public void ShouldAddOneSelfie()
        {
            // ARRANGE
            SelfieDto selfie = new SelfieDto();
            var repositoryMock = new Mock<ISelfieRepository>();
            var unit = new Mock<IUnitOfWork>();

            repositoryMock.Setup(item => item.UnitOfWork).Returns(unit.Object);
            repositoryMock.Setup(item => item.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() { Id = 4 });

            // ACT
            var controller = new SelfiesController(repositoryMock.Object);
            var result = controller.AddOne(selfie);

            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var addedSelfie = (result as OkObjectResult).Value as SelfieDto;
            Assert.NotNull(addedSelfie);
            Assert.True(addedSelfie.Id > 0);
        }

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

            repositoryMock.Setup(item => item.GetAll(It.IsAny<int>())).Returns(expectedList);

            var controller = new SelfiesController(repositoryMock.Object);

            // ACT
            var result = controller.GetAll();

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
