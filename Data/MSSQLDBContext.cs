using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreWebAPI.Data
{
    public class MSSQLDBContext : IdentityDbContext
    {
        public MSSQLDBContext(DbContextOptions<MSSQLDBContext> options)
            : base(options)
        {
        }
    }
}
