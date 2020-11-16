using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Const;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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

        public DbSet<UserInfo> Users { get; set; }

        public DbSet<MasterInfo> MasterInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<MasterInfo>().HasKey(model => new { model.MasterCd, model.DetailCd });
        }

        #endregion DbSet
    }
}
