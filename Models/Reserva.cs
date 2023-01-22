namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hóspedes deve ser menor ou igual a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        private decimal ObterDescontoPorcento()
        {
            if (DiasReservados >= 10)
            {
                return 0.1m;
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Acredito que o metodo deveria ser "CalcularValorTotal" e não "CalcularValorDiaria"
            // Porem, seguimos o que foi pedido no desafio
            decimal valor = DiasReservados * Suite.ValorDiaria;
            valor -= valor * ObterDescontoPorcento();
            return valor;
        }
    }
}