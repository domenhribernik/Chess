using ChessProject.Services.Database;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace ChessProject.Repositories
{
    public abstract class Repository
    {
        private readonly IOptions<ConnectionStrings> _connectionStrings;

        /// <summary>
        /// Vrne novo <see cref="SqlConnection"/> za povezavnje na NVAS.
        /// </summary>
        protected IDbConnection Database => new SqlConnection(_connectionStrings.Value.Database);

        protected Repository(IOptions<ConnectionStrings> connectionStrings)
        {
            if (connectionStrings is null)
                throw new ArgumentNullException("ConnectionStrings nastavitev je null.");
            if (string.IsNullOrEmpty(connectionStrings.Value?.Database))
                throw new ArgumentNullException("ConnectionString NVAS je null ali prazen.");
            _connectionStrings = connectionStrings;
        }
    }
}
