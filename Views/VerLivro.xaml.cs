using Biblioteca.Models;
using Biblioteca.ViewModels;

namespace Biblioteca.Views;

public partial class VerLivro : ContentPage
{
	public VerLivro(Livro selecionado)
	{
		InitializeComponent();
        BindingContext = selecionado;
	}
	public async void OnEditarClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EditarLivro((Livro)BindingContext));
	}

    private async void OnDeletarClicked(object sender, EventArgs e)
    {
        Livro livroSelecionado = (Livro)BindingContext;
        bool resp = await DisplayAlert("Aviso", "Tem certeza que deseja excluir o livro?", "Sim", "Não");

        if (resp)
        {
            int res = LivrosViewModel.ApagarLivro(livroSelecionado);

            if (res==1)
            {
                await DisplayAlert("Aviso", $"O livro {livroSelecionado.NomeLivro} foi apagado", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", $"Não foi possível apagar o livro {livroSelecionado.NomeLivro}.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Aviso", $"O livro {livroSelecionado.NomeLivro} permanece no acervo", "OK");
        }
        await Navigation.PopToRootAsync();
    }
}