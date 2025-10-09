using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditProduct : ContentPage
{
    public EditProduct()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Product produto_anexado = BindingContext as Product;
            Product p = new Product
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };
            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "Ok");
            await Navigation.PopAsync();
        }
        catch (Exception ex)

        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}