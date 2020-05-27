using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLA.Data
{
    public partial class ClaContext : DbContext
    {
        public ClaContext()
        {
        }

        public ClaContext(DbContextOptions<ClaContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }
    }
}
