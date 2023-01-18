using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ChessProject.Repositories
{
    public abstract class Repository
    {
        private readonly ChessDbContext _context;

        protected IDbConnection Database => _context.Database.GetDbConnection();

        protected Repository(ChessDbContext context)
        {
            _context = context;
        }
    }
}
