using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Data.Repository
{
    public class BaseRepository
    {
        private protected static IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static SqlConnection DbConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("Base"));
        }
    }
}
