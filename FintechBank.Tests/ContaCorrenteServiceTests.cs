using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FintechBank.App;
using Xunit;

namespace FintechBank.Tests;

public class ContaCorrenteServiceTests
{
    private readonly ContaCorrenteService _service;

    public ContaCorrenteServiceTests()
    {
        _service = new ContaCorrenteService();
    }

    // Teste 1 (Taxa de Manutenção)
    [Theory]
    [InlineData(6000.00, false, 0.00)]  // Saldo alto -> Isento
    [InlineData(500.00, true, 0.00)]    // Cliente Especial -> Isento
    [InlineData(2500.00, false, 12.50)] // Saldo intermediário -> R$ 12,50
    [InlineData(300.00, false, 25.00)]  // Saldo baixo -> R$ 25,00
    public void CalcularTaxaManutencao_DeveRetornarValorCorreto(decimal saldo, bool clienteEspecial, decimal valorEsperado)
    {
        // Act
        decimal resultado = _service.CalcularTaxaManutencao(saldo, clienteEspecial);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    // Teste 2 (Validação de Saque)
    [Theory]
    [InlineData(1000.00, 500.00, 1200.00, true)]  // Dentro do limite total -> true
    [InlineData(1000.00, 500.00, 1600.00, false)] // Excede saldo + limite -> false
    public void PodeRealizarSaque_DeveRetornarSeEhPossivelOuNao(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque, bool resultadoEsperado)
    {
        // Act
        bool resultado = _service.PodeRealizarSaque(saldo, limiteChequeEspecial, valorSaque);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
}
