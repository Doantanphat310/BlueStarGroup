using BSCommon.Models;
using BSServer._Core.Base;
using System.Data.Entity;

namespace BSServer._Core.Context
{
    public class BSContext : BaseDbContext
    {
        public BSContext() : base("name=BSContext")
        {
        }

        //public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        #region DbSet

        public DbSet<VouchersType> VoucherTypes { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<MasterInfo> MasterInfo { get; set; }

        public DbSet<Items> Items { get; set; }

        public DbSet<ItemType> ItemType { get; set; }

        public DbSet<AccountGroup> AccountGroup { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<AccountDetail> AccountDetail { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<MasterInfo>().HasKey(model => new { model.Key, model.Id });
        }

        #endregion DbSet
    }
}
