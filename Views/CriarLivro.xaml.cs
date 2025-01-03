using Biblioteca.Models;
using Biblioteca.ViewModels;

namespace Biblioteca.Views;

public partial class CriarLivro : ContentPage
{
	public CriarLivro()
	{
		InitializeComponent();
	}
    public async void OnAdicionarClicked(object sender, EventArgs e)
    {
        Livro novoLivro = new Livro(entryISBN.Text, entryNomeLivro.Text, entryNomeAutor.Text, entryEmailAutor.Text);
        int res = LivrosViewModel.AdicionarLivro(novoLivro);

        if (res > 0)
        {
            await DisplayAlert("Aviso", $"O livro {entryNomeLivro.Text} foi adicionado ao catálogo!", "OK");
        }
        else
        {
            await DisplayAlert("Aviso", $"ISBN repetido. O livro {entryNomeLivro.Text} não pode ser adicionado ao catálogo.", "OK");
        }
        await Navigation.PopAsync(true);
    }
    public void EntriesChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNomeAutor.Text) || string.IsNullOrWhiteSpace(entryNomeLivro.Text) || entryISBN.Text.Length < 13 || string.IsNullOrWhiteSpace(entryEmailAutor.Text))
        {
            btnAdicionar.IsEnabled = false;
        }
        else
        {
            btnAdicionar.IsEnabled = true;
        }
    }
    public void OnISBNChanged(object sender, EventArgs e)
    {
        var isbn = (Entry)sender;
        isbn.Text = new string(isbn.Text.Where(char.IsDigit).ToArray());
    }
}