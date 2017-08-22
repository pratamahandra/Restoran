using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Restoran.Model
{
   public class DataContext : DbContext
    {
       public DataContext()
           : base("name = DBRestoranConnection")
       {
           Database.SetInitializer<DataContext>(null);
           //Database.SetInitializer(new DataContextInitializer());
       }

       public DbSet<MstPegawai> mstPegawai { get; set; }
       public DbSet<MstKeanggotaan> mstKeanggotaan { get; set; }
       public DbSet<MstTipeKeanggotaan> mstTipeKeanggotaan { get; set; }
       public DbSet<MstDaftarMenu> mstDaftarMenu { get; set; }
       public DbSet<MstKategoriMenu> mstKategoriMenu { get; set; }
       public DbSet<MstTipeRuangan> mstTipeRuangan { get; set; }
       public DbSet<MstMeja> mstMeja { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           //base.OnModelCreating(modelBuilder);
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
       }
    }
    
}
