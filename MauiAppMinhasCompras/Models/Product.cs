using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

    }
}
