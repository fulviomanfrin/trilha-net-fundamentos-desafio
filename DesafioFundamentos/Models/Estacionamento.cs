namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<string> _veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this._precoInicial = precoInicial;
            this._precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();

            if (_veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("O veículo já se encontra estacionado.");
            }
            else
            {
                _veiculos.Add(placa);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (_veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                var consoleInput = Console.ReadLine();

                int.TryParse(consoleInput, out int horas);

                decimal valorTotal = _precoInicial + _precoPorHora * horas;
                
                if (horas > 0)
                {
                    Console.WriteLine("Tem certeza que deseja encerrar a estadia? (S/N)");

                    if (Console.ReadLine()?.ToUpper() == "S")
                    {
                        _veiculos.Remove(placa);
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C}");
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("A quantidade de horas deve ser informada!");
                    Console.WriteLine("Operação cancelada.");
                }
            }
            else
            {
                Console.WriteLine(
                    "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                var counter = 1;
                foreach (var veiculo in _veiculos)
                {
                    Console.WriteLine($"{counter} - {veiculo}");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}