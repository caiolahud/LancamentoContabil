using LancamentoContabil.Model;
using LancamentoContabil.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoContabil.Data
{
    public class DataContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public DbSet<Lancamento> LancamentoContabil { get; set; }
        public DbSet<ContasContabeis> ContasContabeis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=SYS_TESTE;Password=1234;");
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lancamento>(p =>{
                p.ToTable("Lancamento");
                p.HasKey(p => p.Id);
                p.Property(p => p.Id).ValueGeneratedOnAdd();
                p.Property(p => p.CodEmpresa).HasColumnType("VARCHAR2(3)").IsRequired();
                p.Property(p => p.Lote).HasColumnType("VARCHAR2(6)").IsRequired();
                p.Property(p => p.Documento).HasColumnType("VARCHAR2(6)").IsRequired();
                p.Property(p => p.DataLancamento).HasColumnType("DATE").IsRequired();

                p.HasMany(p => p.ContasContabeis)
                    .WithOne(p => p.LancamentoContabil)
                    .HasForeignKey(p => p.LancamentoContabilId)
                    .OnDelete(DeleteBehavior.Cascade);  

            });


            modelBuilder.Entity<ContasContabeis>(p =>{
                p.ToTable("ContasContabeis");
                p.HasKey(p => p.Id);
                p.Property(p => p.Id).ValueGeneratedOnAdd();
                p.Property(p => p.ContaContabil).HasColumnType("VARCHAR2(15)").IsRequired();
                p.Property(p => p.TipoLancamento).HasColumnType("VARCHAR2(2)").IsRequired();
                p.Property(p => p.Valor).HasColumnType("NUMBER(19,2)").IsRequired();
                p.Property(p => p.Historico).HasColumnType("VARCHAR2(100)").IsRequired();
                p.Property(p => p.LancamentoContabilId).ValueGeneratedOnAdd();

            });
        
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Registro do contexto DataContext com a DI
            services.AddDbContext<DataContext>(options =>
                options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-4BO0V75)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=sys_teste;Password=1234;"));

            //injeção de DI
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            
            services.AddScoped<ILancamentoRepository,LancamentoRepository>();

        }




    }
}
