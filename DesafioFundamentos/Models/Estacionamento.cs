namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            while(true)
            {
                Console.WriteLine("Digite a placa do veículo sem hífen para estacionar (Ex: ABC1234):");
                string input = Console.ReadLine().Trim().ToUpper();

                if (PlacaValida(input))
                {
                    string placaFormatada = input.Insert(3, "-");
                    veiculos.Add(placaFormatada);
                    break;
                }
                else
                {
                    Console.WriteLine("Formato de placa inválido.");
                }
                
            }   
        }

        private bool PlacaValida(string placa)
        {
            if (placa.Length != 7) // Checar se o tamanho está correto
                return false;

            //  Chegar se os primeiros três digitos são letras
            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(placa[i]))
                    return false;
            }

            // Chegar se os últimos quatro digitos são números
            for (int i = 3; i < 7; i++)
            {
                if (!char.IsDigit(placa[i]))
                    return false;
            }

            return true;
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            
            string placa = "";
            Console.WriteLine("Digite a placa de seu carro: ");
            placa = Console.ReadLine().Insert(3,"-").ToUpper();
            int index = veiculos.FindIndex(x => x.ToUpper() == placa);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {

                //Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                //e remover a placa da lista "veiculos"
                int horas = 0;
                decimal valorTotal = 0; 
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                bool parseSuccess = int.TryParse(Console.ReadLine(), out horas);

                if (parseSuccess)
                {
                    valorTotal = precoInicial + precoPorHora * horas;
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    veiculos.RemoveAt(index);

                }
                else
                {
                Console.WriteLine("Opção inválida. Por favor insira um valor inteiro.");
                }
                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            //Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Exibir os veículos estacionados
            
                foreach (string carro in veiculos)
                {
                    Console.WriteLine(carro);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
