using Microsoft.EntityFrameworkCore;
using D1_Training.Models;
using D1_Training.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace D1_Training.Data
{
    // untuk implement dbcontextoption supaya bisa konek ke connection string
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {

        }
        public DbSet<Mahasiswa>? Mahasiswa { get; set; } // properties untuk konek ke kelas Category (kelas model)
        // public DbSet<Application> Application { get; set; } // prop unutk konek ke kelas Application
        public DbSet<MasterTA>? MasterTA { get; set; }
    }
}
