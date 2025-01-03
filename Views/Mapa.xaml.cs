using Microsoft.Maui.Maps;

namespace Biblioteca.Views;

public partial class Mapa : ContentPage
{
    MapSpan mapSpan = new MapSpan(new Location(), 0.01, 0.01);
    public Mapa()
	{
		InitializeComponent();
        CarregarMapa();
    }
	public async Task CarregarMapa()
	{
		Location? localAtual = await Geolocation.GetLocationAsync();

        if (localAtual != null)
        {
            Mover(localAtual);
        }
        else
        {
	        await DisplayAlert("Aviso", "Não foi possível encontrar a localização atual. Verifique se o GPS está desabilitado no dispositivo.", "OK");
        }

    }
    public async void Mover(Location localAtual)
    {
        mapSpan = new MapSpan(localAtual, 0.01, 0.01);

        mapa.MoveToRegion(mapSpan);
        await DisplayAlert("Coordenadas", $"Latitude: {localAtual.Latitude}\nLongitude: {localAtual.Longitude}", "ok");
    }
}