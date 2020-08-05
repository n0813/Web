using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceRest.Models;

namespace ServiceRest.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext (DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceRest.Models.Todo> Todo { get; set; }
    }
}
