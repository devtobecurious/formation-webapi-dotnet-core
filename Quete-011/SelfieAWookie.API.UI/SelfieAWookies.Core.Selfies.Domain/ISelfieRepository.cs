using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Domain
{
    /// <summary>
    /// Repository to manage selfies
    /// </summary>
    public interface ISelfieRepository : IRepository
    {
        /// <summary>
        /// Gets all selfies
        /// </summary>
        /// <returns></returns>
        ICollection<Selfie> GetAll(int wookieId);

        /// <summary>
        /// Adds one slefie in database 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Selfie AddOne(Selfie item);

        /// <summary>
        /// Creates a new picture
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Picture AddOnePicture(string url);
        // Picture AddOnePicture(int selfieId, string url);
    }
}
