using Microsoft.EntityFrameworkCore;

namespace DCA.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}

