using SQLite;
using MauiAppMinhasCompras.Models;


namespace MauiAppMinhasCompras.Helpers
{
    public class SQliteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabseHelper(string path) 
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descrição = ?, Quantidade = ?, Preco = ? WHERE Id = ?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p. Quantidade,p.Preco, p.Id
                );
        }

        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => id == id); 
        }

        public Task<List<Produto>> GetAll() 
        { 
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<int> Search(string q) 
        {
            string sql = "SELECT * Produto SET  WHERE descricao LIKE '%"+q+"%";

            return _conn.QueryAsync<Produto>(sql);
        }

    }
}
