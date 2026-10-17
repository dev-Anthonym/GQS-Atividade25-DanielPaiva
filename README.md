# FintechBank 🏦

Uma aplicação em .NET 10 desenvolvida para a disciplina de **Garantia da Qualidade de Software / Gestão e Qualidade de Software**. O projeto simula regras de negócio de um banco digital e valida sua integridade por meio de suítes de testes unitários parametrizados utilizando o framework xUnit.

## 🛠️ Requisitos Técnicos

- **Ambiente de Execução:** .NET 10.0 SDK
- **Framework de Testes:** xUnit v3

## 📊 Regras de Negócio Implementadas

### 1. ContaCorrenteService
- **CalcularTaxaManutencao:** Avalia o saldo e o status do cliente. Clientes especiais ou com saldo igual/superior a R\$ 5.000,00 são isentos (R\$ 0,00). Saldos intermediários (R\$ 1.000,00 a R\$ 4.999,99) pagam R\$ 12,50, e saldos inferiores a R\$ 1.000,00 pagam R\$ 25,00.
- **PodeRealizarSaque:** Valida se o valor solicitado para o saque é menor ou igual ao saldo disponível somado ao limite do cheque especial.

### 2. EmprestimoService
- **CalcularValorParcela:** Aplica taxas de juros baseadas no score de crédito do cliente (5% para score >= 700, 12% para score entre 500 e 699, e 20% para score inferior a 500) e divide o montante total corrigido pelo número de parcelas.
- **AprovarEmprestimo:** Garante que o empréstimo só seja concedido se o valor da parcela comprometer, no máximo, 30% da renda mensal informada pelo cliente.

## 🧪 Estrutura de Testes Unitários

Para garantir a cobertura e robustez do código, foram utilizados testes parametrizados com as anotações `[Theory]` e `[InlineData]` do xUnit. Isso permite testar múltiplos cenários de entrada e saídas esperadas em um único método de teste, cobrindo com precisão as faixas de valores e limites especificados nas regras de negócio.

----

## 🚀 Como Executar o Projeto Localmente

Siga as instruções abaixo dentro do seu terminal para clonar o código, compilar e testar a solução:

### 1. Clonar o Repositório
```bash
git clone https://github.com
cd fintech-bank-xunit
```

### 2. Compilar a Solução
```bash
dotnet build
```

### 3. Executar os Testes Unitários
Para rodar a suíte completa de testes e verificar os resultados, execute:
```bash
dotnet test
```
