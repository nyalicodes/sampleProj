using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data
{
    public class SampleProjContext:DbContext
    {
        public SampleProjContext(DbContextOptions<SampleProjContext> options) : base(options)
        {
        }

        public DbSet<backend.Domain.Graduate> Graduates { get; set; }
        public DbSet<backend.Domain.AcademicHistory> History { get; set; }
    }
}
