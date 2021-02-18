using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Domain
{
    public class Wookie
    {
        #region Properties
        public int Id { get; set; }

        public List<Selfie> Selfies { get; set; }
        #endregion
    }
}
