﻿using BSCommon.Models;
using BSServer._Core.Const;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BSServer._Core.Context
{
    public class BSContext : DbContext
    {
        public BSContext()
           : base("name=BSContext")
        {
        }

        //public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        #region DbSet

        public DbSet<VouchersType> VoucherTypes { get; set; }

        public DbSet<User> Users { get; set; }

        //public DbSet<Customer> Customers { get; set; }

        #endregion DbSet
    }
}
