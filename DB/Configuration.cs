using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DB
{
    class ConfigurationVMPurse : IEntityTypeConfiguration<VMPurse>
    {
        public void Configure(EntityTypeBuilder<VMPurse> builder)
        {
            builder
                .HasKey(v => v.CoinID);
            builder
                .HasOne(c => c.CoinOf)
                .WithOne(v => v.VMPurse)
                .HasForeignKey<VMPurse>(c => c.CoinID);
        }
    }

    class ConfigurationUserPurse : IEntityTypeConfiguration<UserPurse>
    {
        public void Configure(EntityTypeBuilder<UserPurse> builder)
        {
            builder
                .HasKey(u => u.CoinID);
            builder
                .HasOne(c => c.CoinOf)
                .WithOne(u => u.UserPurse)
                .HasForeignKey<UserPurse>(c => c.CoinID);
        }
    }
}
