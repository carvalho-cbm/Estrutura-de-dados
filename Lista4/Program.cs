using System;
namespace Lista4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista fila = new Lista(100);
            int op;
            double var;
            do
            {
                Console.WriteLine("Op:");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        var = double.Parse(Console.ReadLine());
                        fila.InserirInicio(var);
                        break;
                    case 2:
                        var = double.Parse(Console.ReadLine());
                        fila.InserirFim(var);
                        break;
                    case 3:
                        var = double.Parse(Console.ReadLine());
                        fila.Inserir(var, int.Parse(Console.ReadLine()));
                        break;
                    case 4:
                        var = fila.RemoverInicio();
                        Console.WriteLine(var);
                        break;
                    case 5:
                        var = fila.RemoverFim();
                        Console.WriteLine(var);
                        break;
                    case 6:
                        var = fila.Remover(int.Parse(Console.ReadLine()));
                        Console.WriteLine(var);
                        break;
                    case 7:
                        var = double.Parse(Console.ReadLine());
                        fila.RemoverItem(var);
                        break;
                    case 8:
                        var = double.Parse(Console.ReadLine());
                        Console.WriteLine(fila.Contar(var));
                        break;
                    case 9:
                        fila.Mostrar();
                        break;
                    case 10:
                        break;
                }
            } while (op != 10);

        }
    }

    class Lista
    {
        private double[] vet;
        private int n;

        public Lista(int tam)
        {
            vet = new double[tam];
            n = 0;
        }

        public void InserirInicio(double x)
        {
            if (n >= vet.Length)
                throw new Exception("Erro!");
            for (int i = n; i > 0; i--)
            {
                vet[i] = vet[i - 1];
            }
            vet[0] = x;
            n++;
        }

        public void InserirFim(double x)
        {
            if (n >= vet.Length)
                throw new Exception("Erro!");
            vet[n] = x;
            n++;
        }

        public void Inserir(double x, int pos)
        {
            if (n >= vet.Length || pos < 0 || pos > n)
                throw new Exception("Erro!");
            for (int i = n; i > pos; i--)
            {
                vet[i] = vet[i - 1];
            }
            vet[pos] = x;
            n++;
        }

        public void RemoverItem(double x)
        {
            if (n == 0)
                throw new Exception("Erro!");
            int pos = 0;
            for (int i = 0; i < n; i++)
            {
                if (vet[i] == x)
                {
                    pos = i;
                    for (int j = pos; j < n; j++)
                    {
                        vet[j] = vet[j + 1];
                    }
                    n--;
                    break;
                }
            }
        }

        public double RemoverInicio()
        {
            if (n == 0)
                throw new Exception("Erro!");
            double resp = vet[0];
            n--;
            for (int i = 0; i < n; i++)
            {
                vet[i] = vet[i + 1];
            }
            return resp;
        }

        public double RemoverFim()
        {
            if (n == 0)
                throw new Exception("Erro!");
            n--;
            return vet[n];
        }

        public double Remover(int pos)
        {
            if (n == 0 || pos < 0 || pos >= n)
                throw new Exception("Erro!");
            double resp = vet[pos];
            n--;
            for (int i = pos; i < n; i++)
            {
                vet[i] = vet[i + 1];
            }
            return resp;
        }

        public int Contar(double x)
        {
            if (n == 0)
                throw new Exception("Erro!");
            int cont = 0;
            for (int i = 0; i < n; i++)
            {
                if (vet[i] == x)
                    cont++;
            }
            return cont;
        }

        public void Mostrar()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(vet[i]);
            }
        }

    }
}
