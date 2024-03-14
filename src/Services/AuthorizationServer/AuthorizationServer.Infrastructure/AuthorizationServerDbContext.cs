using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationServer.Infrastructure;

public class AuthorizationServerDbContext : IdentityDbContext<IdentityUser>
{
    public AuthorizationServerDbContext(DbContextOptions<AuthorizationServerDbContext> options)
        : base(options)
    {
    }
}
