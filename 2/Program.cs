using System;
namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista(100);
            int op = 0;
            string nome; int quant; double preco;
            do
            {
                Console.WriteLine("Op:");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        nome = Console.ReadLine();
                        quant = int.Parse(Console.ReadLine());
                        preco = double.Parse(Console.ReadLine());
                        Produto a = new Produto(nome, quant, preco);
                        lista.InserirFim(a);
                        break;
                    case 2:
                        Produto b = lista.RemoverItem(Console.ReadLine());
                        if (b == null)
                            Console.WriteLine("produto não encontrado");
                        else
                            Console.WriteLine(b);
                        break;
                    case 3:
                        lista.Mostrar();
                        break;
                    case 4:
                        if (lista.Pesquisa(Console.ReadLine()))
                            Console.WriteLine("produto cadastrado");
                        else
                            Console.WriteLine("produto não cadastrado");
                        break;
                    case 5:
                        break;
                }
            } while (op != 5);

        }
    }
    class Lista
    {
        private Produto[] vet;
        private int n;

        public Lista(int tam)
        {
            vet = new Produto[tam];
            n = 0;
        }

        public void InserirFim(Produto x)
        {
            if (n >= vet.Length)
                throw new Exception("Erro!");

            vet[n] = x;
            n++;
        }

        public Produto RemoverItem(string x)
        {
            if (n == 0)
                throw new Exception("Erro!");
            int pos = 0;
            Produto a = null;
            for (int i = 0; i < n; i++)
            {
                if (vet[i].Nome == x)
                {
                    a = vet[i];
                    pos = i;
                    for (int j = pos; j < n-1; j++)
                    {
                        vet[j] = vet[j + 1];
                    }
                    n--;
                    break;
                }
            }
            return a;
        }

        public bool Pesquisa(string x)
        {
            if (n == 0)
                throw new Exception("Erro!");
            for (int i = 0; i < n; i++)
            {
                if (vet[i].Nome == x)
                    return true;
            }
            return false;
        }

        public void Mostrar()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(vet[i]);
            }
        }
    }

    class Produto
    {
        private string nome;
        private int quant;
        private double preco;

        public Produto(string nome, int quant, double preco)
        {
            this.nome = nome;
            this.quant = quant;
            this.preco = preco;
        }

        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }

        public int Quant
        {
            get { return quant; }
            set { this.quant = value; }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public override string ToString()
        {
            return nome + " " + quant + " " + preco;
        }

    }
}
