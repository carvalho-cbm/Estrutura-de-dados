using System;
namespace _5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila(100);
            int op = 0;
            do
            {
                Console.WriteLine("Op:");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        string nome = Console.ReadLine();
                        int pg = int.Parse(Console.ReadLine());
                        Arquivo a = new Arquivo(nome, pg);
                        fila.Inserir(a);
                        break;
                    case 2:
                        Console.WriteLine(fila.Remover());
                        break;
                    case 3:
                        fila.Mostrar();
                        break;
                    case 4:
                        break;
                }
            } while (op != 4);

        }
    }

    class Fila
    {
        private Arquivo[] vet;
        private int primeiro;
        private int ultimo;

        public Fila(int tam)
        {
            this.vet = new Arquivo[tam + 1];
            primeiro = ultimo = 0;
        }

        public void Inserir(Arquivo a)
        {
            if (((ultimo + 1) % vet.Length) == primeiro)
            {
                throw new Exception("Erro");
            }
            vet[ultimo] = a;
            ultimo = (ultimo + 1) % vet.Length;
        }

        public string Remover()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro");
            }
            string resp = vet[primeiro].Nome;
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

    }

    class Arquivo
    {
        private string nome;
        private int paginas;

        public Arquivo(string nome, int paginas)
        {
            this.nome = nome;
            this.paginas = paginas;
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public int Paginas
        {
            get { return this.paginas; }
            set { this.paginas = value; }
        }

        public override string ToString()
        {
            return nome + " " + paginas;
        }

    }

}
