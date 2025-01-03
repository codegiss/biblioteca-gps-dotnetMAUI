using Biblioteca.Models;
using Biblioteca.ViewModels;
using Biblioteca.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biblioteca
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Livro> _acervoLivros = new ObservableCollection<Livro>();
        public ObservableCollection<Livro> AcervoLivros
        {
            get => _acervoLivros;
            set
            {
                if (_acervoLivros != value)
                {
                    _acervoLivros = value;
                    OnPropertyChanged();
                }
            }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = LivrosViewModel.acervoLivros;
            CarregarLivros();
        }
        public void CarregarLivros()
        {
            LivrosViewModel.ListarLivros();
        }
        public void OnAppearing()
        {
            base.OnAppearing();
            CarregarLivros();
            acervo.SelectedItem = null;
        }
        public async void OnAdicionarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CriarLivro());
        }

        private async void OnBookSelected(object sender, SelectionChangedEventArgs e)
        {
            Livro selecionado = (Livro)acervo.SelectedItem;
            if(selecionado != null)
            {
                await Navigation.PushAsync(new VerLivro(selecionado));
                acervo.SelectedItem = null;
            }
        }
        public async void OnCoordinatesClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Mapa());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
