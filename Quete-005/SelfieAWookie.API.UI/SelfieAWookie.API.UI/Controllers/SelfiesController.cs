using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        #region Fields
        private readonly SelfiesContext _context = null;
        #endregion

        #region Constructors
        public SelfiesController(SelfiesContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public methods
        //[HttpGet]
        //public IEnumerable<Selfie> TestAMoi()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}

        [HttpGet]
        public IActionResult TestAMoi()
        {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
            //return this.StatusCode(StatusCodes.Status204NoContent);

            var model = this._context.Selfies.Include(item => item.Wookie).Select(item => new { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = item.Wookie.Selfies.Count }).ToList();
            
            return this.Ok(model);
        }
        #endregion
    }
}
