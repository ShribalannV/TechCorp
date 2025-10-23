using Microsoft.EntityFrameworkCore;

public class Account
{
    public string AccountId { get; set; }      // PK, 10 chars, non-Unicode
    public string AccountType { get; set; }    // 2 chars, default "AA"
    public string BranchCode { get; set; }     // 10 chars, not null
}

public class MyDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=SHRIBALAN-LAP;Initial Catalog=TechCorpDB;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Accounts");

            // Primary key
            entity.HasKey(e => e.AccountId);

            // AccountId
            entity.Property(e => e.AccountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            // AccountType
            entity.Property(e => e.AccountType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("AA")
                .IsRequired();

            // BranchCode
            entity.Property(e => e.BranchCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            // Index on AccountType (ascending)
            entity.HasIndex(e => e.AccountType)
                .HasDatabaseName("IX_Account_AccountType");

            // Index on AccountId (ascending)
            entity.HasIndex(e => e.AccountId)
                .HasDatabaseName("IX_Account_AccountId_Asc");

#if NET8_0_OR_GREATER
            // Descending index for EF Core 8+
            entity.HasIndex(e => e.BranchCode)
                .HasDatabaseName("IX_Account_BranchCode_Desc")
                .IsDescending(true);
#else
            // EF Core 6/7 fallback (ascending index)
            entity.HasIndex(e => e.BranchCode)
                .HasDatabaseName("IX_Account_BranchCode_Desc");
#endif
        });
    }
}
