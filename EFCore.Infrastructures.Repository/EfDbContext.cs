using EFCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Infrastructures.Repository
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> dbContext) : base(dbContext)
        {
            Database.EnsureCreated();
        }

        public DbSet<SysRoleEntity> SysRoles { get; set; }
        public DbSet<SysUserEntity> SysUsers { get; set; }
    }
}
