using SelfieAWookies.Core.Selfies.Domain;
using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfiesAWookies.Core.Framework;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Repositories
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        #region Fields
        private readonly SelfiesContext _context = null;
        #endregion

        #region Constructors
        public DefaultSelfieRepository(SelfiesContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public methods
        public ICollection<Selfie> GetAll(int wookieId)
        {
            var query = this._context.Selfies.Include(item => item.Wookie).AsQueryable();

            if(wookieId > 0)
            {
                query = query.Where(item => item.WookieId == wookieId);
            }

            return query.ToList();
        }

        public Selfie AddOne(Selfie item)
        {
            return this._context.Selfies.Add(item).Entity;
        }
        #endregion

        #region Properties
        public IUnitOfWork UnitOfWork => this._context;
        #endregion
    }
}
