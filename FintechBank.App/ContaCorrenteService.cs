using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FintechBank.App;

public class ContaCorrenteService
{
    // 1. CalcularTaxaManutencao
    public decimal CalcularTaxaManutencao(decimal saldo, bool clienteEspecial)
    {
        // Saldo maior ou igual a R$ 5.000,00 OU clienteEspecial == true: Isento
        if (saldo >= 5000.00m || clienteEspecial)
        {
            return 0.00m;
        }
        // Saldo entre R$ 1.000,00 e R$ 4.999,99 (e não especial)
        else if (saldo >= 1000.00m && saldo <= 4999.99m)
        {
            return 12.50m;
        }
        // Saldo menor que R$ 1.000,00 (e não especial)
        else
        {
            return 25.00m;
        }
    }

    // 2. PodeRealizarSaque
    public bool PodeRealizarSaque(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque)
    {
        // Retornar true apenas se o valorSaque for menor ou igual à soma de saldo + limiteChequeEspecial
        return valorSaque <= (saldo + limiteChequeEspecial);
    }
}