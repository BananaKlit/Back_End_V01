using BackEnd.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.DAL.DataAccess;


public class MyContext : DbContext
{
    public MyContext()
    {
    }

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {

    }
    public DbSet<Admin>? Admins { get; set; }
    public DbSet<Client>? Clients { get; set; }
    public DbSet<Recu>? Recus { get; set; }
    public DbSet<Reservation>? Reservations { get; set; }
    public DbSet<Voiture>? Voitures { get; set; }


}



