using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FKCErrorDemoEFCoreExtensions
{
    public class MyContext : DbContext
    {
        private string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public MyContext()
        {

        }

        public MyContext(string path)
        {
            FilePath = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite($"Data Source={FilePath};Foreign Keys=False");
            optionsBuilder.UseSqlite($"Data Source={FilePath};");
        }

        public DbSet<ChildClass> ChildClasses { get; set; }
        public DbSet<ParentClass> ParentClasses { get; set; }
    }
}
