using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Safeon.Mysql.Context;

namespace Safeon.Mysql.Factories
{
    public class SafeonMysqlContextFactory : IDesignTimeDbContextFactory<SafeonMysqlContext>
    {
        public SafeonMysqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SafeonMysqlContext>();
            optionsBuilder.UseMySql("Server=safeon-mysql.cozpmviiu5ad.us-east-1.rds.amazonaws.com;user id=root;password=s4f30nd3v;persistsecurityinfo=True;database=safeon_dev;Convert Zero Datetime=True");

            return new SafeonMysqlContext(optionsBuilder.Options);
        }
    }
}