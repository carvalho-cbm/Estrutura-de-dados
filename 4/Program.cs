using System;
namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila(5);
            int op = 0;
            do
            {
                Console.WriteLine("Op:");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine(fila.ObterTamanho());
                        break;
                    case 2:
                        Console.WriteLine(fila.Remover());
                        break;
                    case 3:
                        fila.Inserir(Console.ReadLine());
                        break;
                    case 4:
                        fila.Mostrar();
                        break;
                    case 5:
                        if (fila.ObterPrimeiro() != null)
                            Console.WriteLine(fila.ObterPrimeiro());
                        else
                            Console.WriteLine("fila vazia");
                        break;
                    case 6:
                        break;
                }
            } while (op != 6);

        }
    }

    class Fila
    {
        private string[] vet;
        private int primeiro;
        private int ultimo;

        public Fila(int tam)
        {
            this.vet = new string[tam + 1];
            primeiro = ultimo = 0;
        }

        public void Inserir(string s)
        {
            if (((ultimo + 1) % vet.Length) == primeiro)
            {
                throw new Exception("Erro");
            }
            vet[ultimo] = s;
            ultimo = (ultimo + 1) % vet.Length;
        }

        public string Remover()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            string resp = vet[primeiro];
            primeiro = (primeiro + 1) % vet.Length;
            return resp;
        }

        public void Mostrar()
        {
            int i = primeiro;
            while (i != ultimo)
            {
                Console.WriteLine(vet[i]);
                i = (i + 1) % vet.Length;
            }
        }

        public bool Pesquisar(string s)
        {
            for (int i = primeiro; i != ultimo; i = ((i + 1) % vet.Length))
            {
                if (vet[i] == s)
                {
                    return true;
                }
            }
            return false;
        }

        public string ObterPrimeiro()
        {
            if (primeiro == ultimo)
                return null;
            return vet[primeiro];
        }

        public int ObterTamanho()
        {
            return (vet.Length + ultimo - primeiro) % vet.Length;
        }

    }

}
