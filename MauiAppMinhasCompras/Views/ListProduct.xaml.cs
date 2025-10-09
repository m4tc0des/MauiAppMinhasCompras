using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListProduct : ContentPage
{
    ObservableCollection<Product> lista = new ObservableCollection<Product>();
    public ListProduct()
    {
        InitializeComponent();

        lst_produtos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();
            List<Product> tmp = await App.Db.GetAll();
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }

    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NewProduct());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e) //Manipulador de evento para procurar o produto
    {
        try
        {
            string q = e.NewTextValue;
            lst_produtos.IsRefreshing = true;
            lista.Clear();
            List<Product> tmp = await App.Db.Search(q);
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
        finally
        {
            lst_produtos.IsRefreshing = false;
        }
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e) //Manipulador de eventos para somar o total dos produtos
    {
        try
        {
            double soma = lista.Sum(i => i.Total);
            string msg = $"O total é de {soma:C} reais";
            DisplayAlert("Total dos produtos", msg, "Ok");
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private async void MenuItem_Clicked(object sender, EventArgs e) //Manipulador de eventos para remover o item
    {
        try
        {
            MenuItem selecionado = sender as MenuItem;
            Product p = selecionado.BindingContext as Product;

            bool confirm = await DisplayAlert("Deseja confirmar?", $"Remover {p.Descricao}?", "Sim", "Não");
            if (confirm)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Product p = e.SelectedItem as Product;
            Navigation.PushAsync(new Views.EditProduct
            {
                BindingContext = p
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private async void lst_produtos_Refreshing(object sender, EventArgs e)
    {
        try
        {
            lista.Clear();
            List<Product> tmp = await App.Db.GetAll();
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
        finally
        {
            lst_produtos.IsRefreshing = false;
        }

    }
}