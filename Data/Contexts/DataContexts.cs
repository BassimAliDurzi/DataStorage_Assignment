using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    public virtual DbSet<CustomerEntity> Customers { get; set; } = null!;
    public virtual DbSet<ProductEntity> Products { get; set; } = null!;
    public virtual DbSet<StatusTypeEntity> StatusTypes { get; set; } = null!;
    public virtual DbSet<UserEntity> Users { get; set; } = null!;
    public virtual DbSet<ProjectEntity> Projects { get; set; } = null!;


}
