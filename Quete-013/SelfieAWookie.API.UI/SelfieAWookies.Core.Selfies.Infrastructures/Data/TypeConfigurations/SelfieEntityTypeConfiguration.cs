using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookies.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Data.TypeConfigurations
{
    class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
    {
        #region Public methods
        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable("Selfie");

            builder.HasKey(item => item.Id);
            builder.HasOne(item => item.Wookie)
                   .WithMany(item => item.Selfies);
        }
        #endregion
    }
}
