using System.ComponentModel.DataAnnotations.Schema;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.Security.Domain.Models;
using CargaSinEstres.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Company = CargaSinEstres.API.Security.Domain.Models.Company;

namespace CargaSinEstres.API.Shared.Persistence.Contexts;

/// <summary>
/// Represents the Entity Framework Core DbContext for the application.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the DbSet for companies.
    /// </summary>
    public DbSet<Company> Companies { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for clients.
    /// </summary>
    public DbSet<Client> Clients { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for reviews.
    /// </summary>
    public DbSet<Review> Reviews { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for booking histories.
    /// </summary>
    public DbSet<BookingHistory> BookingHistories { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet for memberships.
    /// </summary>
    public DbSet<Membership> Memberships { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for chats.
    /// </summary>
    public DbSet<Chat> Chats { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for workers.
    /// </summary>
    public DbSet<Worker> Workers { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for comments.
    /// </summary>
    public DbSet<Comment> Comments { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options">The DbContext options.</param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Configures the DbContext entities and relationships.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Client>().ToTable("Clients");
        builder.Entity<Client>().HasKey(p => p.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.ApellidoMaterno).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.ApellidoPaterno).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.Celular).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.Password).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.Direccion).HasMaxLength(120);
        builder.Entity<Client>().Property(p => p.UserType).HasMaxLength(20);    
        
        builder.Entity<BookingHistory>().ToTable("BookingHistories");
        builder.Entity<BookingHistory>().HasKey(p => p.Id);
        builder.Entity<BookingHistory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BookingHistory>().Property(p => p.IdCompany).IsRequired();
        builder.Entity<BookingHistory>().Property(p => p.IdClient).IsRequired();
        builder.Entity<BookingHistory>().Property(p => p.BookingDate).IsRequired().HasMaxLength(50);
        builder.Entity<BookingHistory>().Property(p => p.PickupAddress).IsRequired().HasMaxLength(150);
        builder.Entity<BookingHistory>().Property(p => p.DestinationAddress).IsRequired().HasMaxLength(150);
        builder.Entity<BookingHistory>().Property(p => p.MovingDate).IsRequired().HasMaxLength(50);
        builder.Entity<BookingHistory>().Property(p => p.MovingTime).IsRequired().HasMaxLength(50);
        builder.Entity<BookingHistory>().Property(p => p.Services).IsRequired().HasMaxLength(50);
        builder.Entity<BookingHistory>().Property(p => p.Status).IsRequired().HasMaxLength(50);
        builder.Entity<BookingHistory>().Property(p => p.Payment).IsRequired();
        builder.Entity<BookingHistory>().Property(p => p.Weight).IsRequired();

        builder.Entity<Membership>().ToTable("Memberships");
        builder.Entity<Membership>().HasKey(p=>p.Id);
        builder.Entity<Membership>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Membership>().Property(p=>p.NombreEmpresa).IsRequired().HasMaxLength(50);
        builder.Entity<Membership>().Property(p=>p.Ruc).IsRequired();
        builder.Entity<Membership>().Property(p=>p.Direction).IsRequired().HasMaxLength(50);
        builder.Entity<Membership>().Property(p=>p.TipoMembresia).IsRequired().HasMaxLength(50);
        builder.Entity<Membership>().Property(p=>p.TipoTarjeta).IsRequired().HasMaxLength(50);
        builder.Entity<Membership>().Property(p=>p.IdCompany).IsRequired();
        
        // Constraints
        builder.Entity<Company>().ToTable("Companies");
        builder.Entity<Company>().HasKey(p => p.Id);
        builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(30); 
        builder.Entity<Company>().Property(p => p.Photo).IsRequired().HasMaxLength(350); 
        builder.Entity<Company>().Property(p => p.Email).IsRequired().HasMaxLength(120); 
        builder.Entity<Company>().Property(p => p.Direccion).IsRequired().HasMaxLength(150); 
        builder.Entity<Company>().Property(p => p.NumeroContacto).IsRequired().HasMaxLength(30); 
        builder.Entity<Company>().Property(p => p.Password).IsRequired().HasMaxLength(30); 
        builder.Entity<Company>().Property(p => p.ConfirmarPassword).IsRequired().HasMaxLength(30);
        builder.Entity<Company>().Property(p => p.Transporte).IsRequired();
        builder.Entity<Company>().Property(p => p.Carga).IsRequired();
        builder.Entity<Company>().Property(p => p.Embalaje).IsRequired();
        builder.Entity<Company>().Property(p => p.Montaje).IsRequired();
        builder.Entity<Company>().Property(p => p.Desmontaje).IsRequired();
        builder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(150); 
        builder.Entity<Company>().Property(p => p.UserType).IsRequired().HasMaxLength(50);
        

        //chat
        
        // Relationships
        builder.Entity<Company>()
             .HasMany(p => p.Reviews)
             .WithOne(p => p.Company)
             .HasForeignKey(p => p.CompanyId);
        
        builder.Entity<Review>().ToTable("Reviews");
        builder.Entity<Review>().HasKey(p => p.Id);
        builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(p => p.Rating).IsRequired().HasMaxLength(50);
        builder.Entity<Review>().Property(p => p.Comment).HasMaxLength(120);
        
        
        builder.Entity<Worker>().ToTable("Workers");
        builder.Entity<Worker>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Worker>().Property(p => p.FirstName).IsRequired().HasMaxLength(30); 
        builder.Entity<Worker>().Property(p => p.LastName).IsRequired().HasMaxLength(30); 
        
        // Relación uno a muchos entre Worker y Comment
        builder.Entity<Worker>()
            .HasMany(w => w.Comments)
            .WithOne(c => c.Worker)
            .HasForeignKey(c => c.WorkerId);
        
        builder.UseSnakeCaseNamingConvention();
        
    }
    
}