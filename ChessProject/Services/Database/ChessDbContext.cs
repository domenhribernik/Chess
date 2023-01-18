using ChessProject.Data;
using Microsoft.EntityFrameworkCore;

public class ChessDbContext : DbContext
{
    public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options){}
    public DbSet<Player> Player { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<GameChat> Chat { get; set; }
    public DbSet<PlayerRating> Rating { get; set; }
}

