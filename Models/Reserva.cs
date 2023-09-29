using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospedagemDeHotel.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set;}
        public Suite Suite { get; set;}
        public int DiasReservados { get; set;}

        public Reserva(){}

        public Reserva(int diasReservados){
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes){
            if(Suite.Capacidade <= hospedes.Count() ){
                Hospedes = hospedes;
            } else {
                Console.WriteLine("A quantidade de hospedes é maior que a quantidade suportada da suite");
            }
        }

        public void CadastrarSuite(Suite suite){
            Suite = suite;
        }

        public int ObterQuantidadeHospedes(){
           if (Hospedes != null)
                {
                    return Hospedes.Count;
                }
                else
                {
                    return 0; 
                }
            
        }

        public string ObterNomesHospedes()
        {
            if (Hospedes != null && Hospedes.Count > 0)
            {
                return string.Join(", ", Hospedes.Select(hospede => hospede.Nome));
            }
            else
            {
                return "Nenhum hóspede registrado";
            }
        }


        public decimal CalcularValorDiaria(){
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            if(DiasReservados >= 10){
                decimal desconto = valorTotal * 0.10M;
                valorTotal -= desconto;
            }

            return valorTotal;
        }
        
    }
}