using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC.Employee.Worker.Models;

namespace POC.Employee.Worker.Contexts.Configs
{
    public class EmployeeCTConfig : IEntityTypeConfiguration<EmployeeCT>
    {
        public void Configure(EntityTypeBuilder<EmployeeCT> builder)
        {
            builder.ToTable("dbo_Employees_CT", "cdc");
            builder.Property(x => x.Id).HasColumnName("EmployeeId");
            builder.Property(x => x.HiredDate).HasColumnName("Date");
            builder.Property(x => x.OperationType).HasColumnName("__$operation");
            builder.Property(x => x.Start_LSN).HasColumnName("__$start_lsn");
        }
    }
}
