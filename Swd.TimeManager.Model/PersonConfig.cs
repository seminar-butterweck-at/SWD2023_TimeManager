using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(m => m.LastName).IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(m => m.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(m => m.DisplayName).HasComputedColumnSql("[LastName] + ' ' + [FirstName]",true);
            entity.HasIndex(m => m.LastName).HasDatabaseName("idx_lastname");

        }
    }
}
