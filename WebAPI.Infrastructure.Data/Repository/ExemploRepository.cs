using static Dapper.SqlMapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Data.Repository
{
    public class ExemploRepository : BaseRepository, IExemploRepository
    {
        private readonly SqlConnection cnn;

        public ExemploRepository(IConfiguration configuration) : base(configuration)
        {
            cnn = DbConnection();
            cnn.Open();
        }

        public int Create(Exemplo entity)
        {
            var sql = @"INSERT INTO [Exemplo]([Id],[Descricao]) 
            VALUES(@Id,@Descricao);
            SELECT SCOPE_IDENTITY()";

            return cnn.ExecuteScalar<int>(sql, entity);
        }
        public Exemplo FindById(int id)
        {
            var sql = @"SELECT [Id],[Descricao] FROM [Exemplo] WHERE Id = @Id";

            return cnn.Query<Exemplo>(sql, new { id = id}).FirstOrDefault();
        }

        public List<Exemplo> FindAll()
        {
            var sql = @"SELECT [Id],[Descricao] FROM [Exemplo]";

            return cnn.Query<Exemplo>(sql).ToList();
        }

        public void Update(Exemplo entity)
        {
            cnn.Execute(
                   @"UPDATE [Exemplo] SET
                            [Descricao]=@Descricao
                        WHERE
                            Id=@Id
                ", entity);
        }

        public void Delete(int id)
        {
            cnn.Execute($"DELETE FROM Exemplo WHERE Id = @id", new { id = id });
        }

        public void Dispose()
        {
            cnn.Close();
            cnn.Dispose();
        }

    }
}
