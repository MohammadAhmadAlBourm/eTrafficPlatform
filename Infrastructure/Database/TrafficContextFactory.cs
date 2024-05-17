using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Database;

internal class TrafficContextFactory : IDesignTimeDbContextFactory<TrafficContext>
{
    public TrafficContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TrafficContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-JKTO23G;Initial Catalog=TrafficManagement;Integrated Security=True;Trust Server Certificate=True");

        return new TrafficContext(optionsBuilder.Options);
    }
}