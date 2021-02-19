using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Domain
{
    public class Picture
    {
        #region Properties
        public int Id { get; set; }

        public string Url { get; set; }

        public List<Selfie> Selfies { get; set; }
        #endregion
    }
}
