using Microsoft.EntityFrameworkCore;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Connection
{
    public static class DataModelConfiguration
    {
        public static void ConfigureModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountUser>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired(false);
                entity.Property(a => a.Email).IsRequired(false);
                entity.Property(a => a.Password).IsRequired(false);
                entity.Property(a => a.CreateDate);
                entity.Property(a => a.ModificationDate);

                entity.HasOne(a => a.Balance)
                      .WithOne(b => b.AccountUsers)
                      .HasForeignKey<Balance>("AccountId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired(false);
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Value);
                entity.Property(d => d.CreateDate);
                entity.Property(d => d.ModificationDate);

                entity.HasOne(d => d.AccountUsers)
                      .WithMany(a => a.Deposits)
                      .HasForeignKey("AccountId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired(false);
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Value);
                entity.Property(b => b.CreateDate);
                entity.Property(b => b.ModificationDate);

                entity.HasOne(b => b.AccountUsers)
                      .WithOne(a => a.Balance)
                      .HasForeignKey<Balance>("AccountId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired(false);
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.HasKey(q => q.Id);

                entity.Property(q => q.BuyPrice)
                      .HasColumnType("decimal(18, 8)")
                      .IsRequired();

                entity.Property(q => q.SellPrice)
                      .HasColumnType("decimal(18, 8)")
                      .IsRequired();

                entity.Property(q => q.DateHourQuotation)
                      .IsRequired();
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.AmountInvested)
                      .HasColumnType("decimal(18, 8)")
                      .IsRequired();

                entity.Property(p => p.QuantityBTC)
                      .HasColumnType("decimal(18, 8)")
                      .IsRequired();

                entity.Property(p => p.BTCExchangeRate)
                      .HasColumnType("decimal(18, 8)")
                      .IsRequired();

                entity.Property(p => p.PurchaseDate)
                      .IsRequired();

                entity.HasOne(p => p.AccountUser)
                      .WithMany(a => a.Purchases)
                      .HasForeignKey(p => p.AccountId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
            });
        }
    }
}