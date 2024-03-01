using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(m => m.Name).IsRequired().HasColumnType("nvarchar(50)");
            entity.HasIndex(m => m.Name).HasDatabaseName("idx_projectname");

        }
    }
}
