using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class TimeRecordConfig : IEntityTypeConfiguration<TimeRecord>
    {
        public void Configure(EntityTypeBuilder<TimeRecord> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(m => m.Date).IsRequired();
            entity.Property(m => m.Duration).IsRequired().HasDefaultValue(0);
            entity.HasIndex(m => m.Date).HasDatabaseName("idx_timerecorddate");

        }
    }
}
