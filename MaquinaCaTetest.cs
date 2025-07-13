using Xunit;

public class MaquinaCafeTests
{
    [Fact]
    public void ServirCafe_DeberiaServirCafeSiHayRecursosSuficientes()
    {
        // Arrange
        var maquina = new MaquinaCafe(
            new Cafetera(100),
            new Azucarero(20),
            new InventarioVasos(10, 10, 10)
        );

        // Act
        string resultado = maquina.ServirCafe(TamanioVaso.Mediano, 2);

        // Assert
        Assert.Equal("Café servido correctamente", resultado);
    }
}
