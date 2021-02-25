using MediatR;
using SelfieAWookie.API.UI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAWookie.API.UI.Application.Queries
{
    /// <summary>
    /// Query to select all selfies (with dto class)
    /// </summary>
    public class SelectAllSelfiesQuery : IRequest<List<SelfieResumeDto>>
    {
        #region Properties
        public int WookieId { get; set; }
        #endregion
    }
}
