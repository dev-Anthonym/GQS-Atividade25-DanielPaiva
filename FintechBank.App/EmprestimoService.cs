using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FintechBank.App;

public class EmprestimoService
{
    // 1. CalcularValorParcela
    public decimal CalcularValorParcela(decimal valorTotal, int parcelas, int scoreCredito)
    {
        decimal valorComJuros;

        // Se scoreCredito >= 700: taxa de juros total de 5%
        if (scoreCredito >= 700)
        {
            valorComJuros = valorTotal * 1.05m;
        }
        // Se scoreCredito entre 500 e 699: taxa de juros total de 12%
        else if (scoreCredito >= 500 && scoreCredito <= 699)
        {
            valorComJuros = valorTotal * 1.12m;
        }
        // Se scoreCredito < 500: taxa de juros total de 20%
        else
        {
            valorComJuros = valorTotal * 1.20m;
        }

        // Retornar o valor da parcela individual
        return valorComJuros / parcelas;
    }

    // 2. AprovarEmprestimo
    public bool AprovarEmprestimo(decimal rendaMensal, decimal valorParcela)
    {
        // O empréstimo só é aprovado se o valor da parcela comprometer no máximo 30% da renda mensal
        return valorParcela <= (rendaMensal * 0.30m);
    }
}
