using SQLite;
using System.Globalization;

namespace MauiAppMinhasCompras.Models
{
    public class Product
    {
        string _descricao;
        double _preco = 0;
        double _quantidade = 0;

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao; set
            {
                if (value == null)
                {
                    throw new Exception("A descricao do produto e obrigatoria. Verifique!");
                }
                _descricao = value;
            }
        }
        public double Quantidade {
                get => _quantidade; set
            {
                    if (value <= 0)
                    {
                        throw new Exception("Produto nao pode ser inserido com quantidade zerada. Verifique!");
                    }
                    _quantidade = value;
                }
            }

        public double Preco
        {
            get => _preco; set
            {
                if (value <= 0)
                {
                    throw new Exception("Produto nao pode ser inserido com valor zero. Verifique!");
                }
                _preco = value;
            }
        }
        public double Total { get => Quantidade * Preco; }

    }
}
