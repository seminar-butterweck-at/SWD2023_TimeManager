using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class TaskConfig : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            //entity.Property(m => m.Id).IsRequired().ValueGeneratedNever();
            entity.Property(m => m.Id).IsRequired();
            entity.Property(m => m.Name).IsRequired().HasColumnType("nvarchar(50)");
            entity.HasIndex(m => m.Name).HasDatabaseName("idx_taskname");

        }
    }
}
