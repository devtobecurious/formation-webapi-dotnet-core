using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.API.UI.Application.DTOs;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using SelfieAWookie.API.UI.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MediatR;
using SelfieAWookie.API.UI.Application.Queries;
using SelfieAWookie.API.UI.Application.Commands;

namespace SelfieAWookie.API.UI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors(SecurityMethods.DEFAULT_POLICY_2)]
    public class SelfiesController : ControllerBase
    {
        #region Fields
        private readonly ISelfieRepository _repository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly IMediator _mediator = null;
        #endregion

        #region Constructors
        public SelfiesController(IMediator mediator, ISelfieRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this._repository = repository;
            this._webHostEnvironment = webHostEnvironment;
            this._mediator = mediator;
        }
        #endregion

        #region Public methods
        //[HttpGet]
        //public IEnumerable<Selfie> TestAMoi()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}


        [HttpGet]
        [DisableCors()]
        //[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
        public IActionResult GetAll([FromQuery] int wookieId = 0)
        {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
            //return this.StatusCode(StatusCodes.Status204NoContent);

            if (this.Request != null)
            {
                var param = this.Request.Query["wookieId"];
            }

            //var selfiesList = this._repository.GetAll(wookieId);
            //var model = selfiesList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();

            var model = this._mediator.Send(new SelectAllSelfiesQuery() { WookieId = wookieId });

            return this.Ok(model);
        }

        //[Route("photos")]
        //[HttpPost]
        //public async Task<IActionResult> AddPicture()
        //{
        //    using var stream = new StreamReader(this.Request.Body);

        //    var content = await stream.ReadToEndAsync();


        //    return this.Ok();
        //}

        [Route("photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            string filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, @"images\selfies");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = Path.Combine(filePath, picture.FileName);


            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await picture.CopyToAsync(stream);

            var itemFile = this._repository.AddOnePicture(filePath);

            try
            {
                this._repository.UnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


            return this.Ok(itemFile);
        }

        [HttpPost]
        //public IActionResult AddOne(UneClasseQuiSertARien toto)
        public async Task<IActionResult> AddOne(SelfieDto dto)
        {
            IActionResult result = this.BadRequest();

            var item = await this._mediator.Send(new AddSelfieCommand() { Item = dto });
            if (item != null)
            {
                result = this.Ok(item);
            }

            return result;
        }
        #endregion
    }
}
