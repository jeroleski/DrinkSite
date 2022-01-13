namespace DrinkSite.Infrastructure;

public class DrinkContext : DbContext, IDrinkContext
{
    public DbSet<Cocktail> Cocktails => Set<Cocktail>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Use> Uses => Set<Use>();

    public DrinkContext(DbContextOptions<DrinkContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cocktail>()
                    .HasIndex(c => c.Name)
                    .IsUnique();
        
        modelBuilder.Entity<Cocktail>()
                    .Property(c => c.Method)
                    .HasMaxLength(50)
                    .HasConversion(new EnumToStringConverter<Method>());

        modelBuilder.Entity<Cocktail>()
                    .Property(c => c.Glass)
                    .HasMaxLength(50)
                    .HasConversion(new EnumToStringConverter<Glass>());

        modelBuilder.Entity<Ingredient>()
                    .HasIndex(i => i.Name)
                    .IsUnique();

        modelBuilder.Entity<Use>()
                    .Property(u => u.Messurement)
                    .HasMaxLength(50)
                    .HasConversion(new EnumToStringConverter<Messurement>());
    }
}