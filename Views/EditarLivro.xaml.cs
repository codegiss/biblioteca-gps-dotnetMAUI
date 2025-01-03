using Biblioteca.Models;
using Biblioteca.ViewModels;

namespace Biblioteca.Views;

public partial class EditarLivro : ContentPage
{
	public EditarLivro(Livro selecionado)
	{
		InitializeComponent();
        BindingContext = selecionado;
	}
    public void EntriesChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNomeAutor.Text) || string.IsNullOrWhiteSpace(entryNomeLivro.Text) || string.IsNullOrWhiteSpace(entryEmailAutor.Text))
        {
            btnSalvar.IsEnabled = false;
        }
        else
        {
            btnSalvar.IsEnabled = true;
        }
    }
    public async void OnSalvarClicked(object sender, EventArgs e)
	{
        Livro livroEditado = new Livro(entryISBN.Text, entryNomeLivro.Text, entryNomeAutor.Text, entryEmailAutor.Text);
        int res = LivrosViewModel.AtualizarLivro(livroEditado);

        if (res > 0)
        {
		    await DisplayAlert("Aviso", $"Alterações no livro {livroEditado.NomeLivro} foram salvas", "OK");
        }
        else
        {
            await DisplayAlert("Atenção", "As informações sobre o livro não foram alteradas", "OK");
        }

		await Navigation.PopToRootAsync();
	}
}