using MauiAppMinhasCompras.Models;
using SQLite;


namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;
        public SQLiteDatabaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Product>().Wait();
        }
        public Task<int> Insert(Product p)
        {
            return _connection.InsertAsync(p);
        }
        public Task<List<Product>> Update(Product p)
        {
            string sql = "UPDATE Product SET Description=?, Quantidade=?, Preco=?, WHERE Id=?";
            return _connection.QueryAsync<Product>(sql
                , p.Description, p.Quantity, p.Price, p.Id);
        }
        public Task<int> Delete(int id)
        {
            return _connection.Table<Product>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Product>> GetAll() 
        {
            return _connection.Table<Product>().ToListAsync();
        }
        public Task<List<Product>> Search (string q) 
        {
            string sql = "SELECT * Product WHERE Descrption LIKE '%" + q + "%'";
        return _connection.QueryAsync<Product>(sql);
        }
    }
}
