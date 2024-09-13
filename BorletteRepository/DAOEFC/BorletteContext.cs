using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorletteRepository.DAOEFC.EFC;

    public partial class BorletteContext : DbContext
    {
        private string _connectionString;
        public BorletteContext(string connstr)
        {
            _connectionString = connstr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_connectionString); //to verify dependancies base on framework 4.6 in the core
                                                      // .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                                                      //QueryClientEvaluationWarning
            }
        }
    }

