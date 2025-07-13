public enum TamanioVaso { Pequeno, Mediano, Grande }

public class MaquinaCafe
{
    private Cafetera _cafetera;
    private Azucarero _azucarero;
    private InventarioVasos _vasos;

    public MaquinaCafe(Cafetera cafetera, Azucarero azucarero, InventarioVasos vasos)
    {
        _cafetera = cafetera;
        _azucarero = azucarero;
        _vasos = vasos;
    }

    public string ServirCafe(TamanioVaso tamanio, int cucharadasAzucar)
    {
        int cantidadCafe = tamanio switch
        {
            TamanioVaso.Pequeno => 3,
            TamanioVaso.Mediano => 5,
            TamanioVaso.Grande => 7,
            _ => 0
        };

        if (!_vasos.HayVaso(tamanio))
            return "No hay vasos disponibles";

        if (!_cafetera.HayCafeSuficiente(cantidadCafe))
            return "No hay café suficiente";

        if (!_azucarero.HayAzucarSuficiente(cucharadasAzucar))
            return "No hay azúcar suficiente";

        _vasos.ConsumirVaso(tamanio);
        _cafetera.ConsumirCafe(cantidadCafe);
        _azucarero.ConsumirAzucar(cucharadasAzucar);

        return "Café servido correctamente";
    }
}

public class Cafetera
{
    private int _cantidadCafe;
    public Cafetera(int cantidadInicial) => _cantidadCafe = cantidadInicial;
    public bool HayCafeSuficiente(int cantidad) => _cantidadCafe >= cantidad;
    public void ConsumirCafe(int cantidad) => _cantidadCafe -= cantidad;
}

public class Azucarero
{
    private int _cantidadAzucar;
    public Azucarero(int cantidadInicial) => _cantidadAzucar = cantidadInicial;
    public bool HayAzucarSuficiente(int cucharadas) => _cantidadAzucar >= cucharadas;
    public void ConsumirAzucar(int cucharadas) => _cantidadAzucar -= cucharadas;
}

public class InventarioVasos
{
    private int _pequenos, _medianos, _grandes;
    public InventarioVasos(int p, int m, int g)
    {
        _pequenos = p;
        _medianos = m;
        _grandes = g;
    }

    public bool HayVaso(TamanioVaso t) => t switch
    {
        TamanioVaso.Pequeno => _pequenos > 0,
        TamanioVaso.Mediano => _medianos > 0,
        TamanioVaso.Grande => _grandes > 0,
        _ => false
    };

    public void ConsumirVaso(TamanioVaso t)
    {
        switch (t)
        {
            case TamanioVaso.Pequeno: _pequenos--; break;
            case TamanioVaso.Mediano: _medianos--; break;
            case TamanioVaso.Grande: _grandes--; break;
        }
    }
}