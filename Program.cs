using System;
using System.Collections.Generic;
using System.Text;
using HospedagemDeHotel.Models;

Console.OutputEncoding = Encoding.UTF8;

int capacidadeQuartos = 10;

Reserva[] quartos = new Reserva[capacidadeQuartos];

while (true)
{
    Console.Write("Digite o número do quarto desejado (1 a 10): ");
    if (!int.TryParse(Console.ReadLine(), out int numeroQuartoDesejado) || numeroQuartoDesejado < 1 || numeroQuartoDesejado > capacidadeQuartos)
    {
        Console.WriteLine("Número de quarto inválido. Digite um número entre 1 e 10.");
        continue;
    }

    int indiceQuarto = numeroQuartoDesejado - 1;
    if (quartos[indiceQuarto] != null)
    {
        Console.WriteLine($"O quarto {numeroQuartoDesejado} já está ocupado.");
        continue;
    }

    Console.Write("Digite o número de hóspedes: ");
    if (!int.TryParse(Console.ReadLine(), out int numeroHospedes) || numeroHospedes <= 0)
    {
        Console.WriteLine("Número de hóspedes inválido.");
        continue;
    }

    Console.WriteLine();
    List<Pessoa> hospedes = new List<Pessoa>();
    for (int i = 1; i <= numeroHospedes; i++)
    {
        Console.Write($"Digite o nome do hóspede {i}: ");
        string nomeHospede = Console.ReadLine();
        hospedes.Add(new Pessoa(nome: nomeHospede));
    }

    Console.Write("Digite o número de dias de reserva(*desconto de 10% para reservas acima de 10 dias): ");
    Console.Write("");
    if (!int.TryParse(Console.ReadLine(), out int diasReserva) || diasReserva <= 0)
    {
        Console.WriteLine("Número de dias de reserva inválido.");
        continue;
    }

    Console.WriteLine();
    Console.WriteLine("Escolha o tipo de suíte:");
    Console.WriteLine("1 - Comum (valor Diaria: R$30)");
    Console.WriteLine("2 - Premium (valor Diaria: R$50)");
    Console.WriteLine("3 - VIP (valor Diaria: R$80)");
    Console.Write("Digite o número correspondente ao tipo de suíte: ");
    if (!int.TryParse(Console.ReadLine(), out int tipoSuite) || tipoSuite < 1 || tipoSuite > 3)
    {
        Console.WriteLine("Tipo de suíte inválido.");
        continue;
    }

    // Cria a suíte com base na escolha do usuário
    string tipoSuiteEscolhido = "";
    decimal valorDiaria = 0;
    switch (tipoSuite)
    {
        case 1:
            tipoSuiteEscolhido = "Comum";
            valorDiaria = 30;
            break;
        case 2:
            tipoSuiteEscolhido = "Premium";
            valorDiaria = 50;
            break;
        case 3:
            tipoSuiteEscolhido = "VIP";
            valorDiaria = 80;
            break;
        default:
            Console.WriteLine("Escolha de suíte inválida.");
            continue;
    }

    Suite suite = new Suite(tipoSuite: tipoSuiteEscolhido, capacidade: numeroHospedes, valorDiaria: valorDiaria);

    Reserva reserva = new Reserva(diasReservados: diasReserva);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    // Registra o hóspede no quarto
    quartos[indiceQuarto] = reserva;

    Console.WriteLine();
    Console.WriteLine($"Hóspedes no quarto {numeroQuartoDesejado}: {reserva.ObterQuantidadeHospedes()} pessoa(s) | {reserva.ObterNomesHospedes()}");
    Console.WriteLine($"Valor da diária no quarto {numeroQuartoDesejado}: {reserva.CalcularValorDiaria()}");

    // Pergunta se deseja realizar um novo cadastro
    Console.Write("Deseja realizar um novo cadastro de hóspede (S/N)? ");
    string resposta = Console.ReadLine();
    if (resposta.ToUpper() != "S")
    {
        break;
    }
}
