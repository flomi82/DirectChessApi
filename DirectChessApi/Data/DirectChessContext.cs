using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectChessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectChessApi.Data
{
    public class DirectChessContext : DbContext
    {
        public DirectChessContext(DbContextOptions<DirectChessContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasKey(g => g.GameId);
            modelBuilder.Entity<Game>()
                .ToTable("Games");

            modelBuilder.Entity<Move>()
                .HasKey(m => new { m.GameId, m.Number });

            modelBuilder.Entity<Move>()
                .ToTable("Moves");
        }
    }
}
