using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace salaodebeleza.Data {
    public class AppDb : IdentityDbContext {
        public AppDb(DbContextOptions<AppDb> options)
            : base(options)
        {
        }
    }
}