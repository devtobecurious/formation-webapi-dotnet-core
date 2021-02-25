using MediatR;
using SelfieAWookie.API.UI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAWookie.API.UI.Application.Commands
{
    /// <summary>
    /// Command to add one selfie on database
    /// </summary>
    public class AddSelfieCommand : IRequest<SelfieDto>
    {
        #region Properties
        public SelfieDto Item { get; set; }
        #endregion
    }
}
