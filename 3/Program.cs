using System;
namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha = new Pilha(100);
            string conjunto = Console.ReadLine();
            bool veri = true;
            foreach (char c in conjunto)
            {
                if (c == '(' || c == '[')
                    pilha.Inserir(c);
                else if (c == ')' || c == ']')
                {
                    if (pilha.ObterTamanho() == 0)
                    {
                        veri = false;
                        break;
                    }
                    char topo = pilha.Remover();
                    if (topo == 'C' && c != ')' || topo == '[' && c != ']')
                    {
                        veri = false;
                        break;
                    }
                }
            }
            if (veri && pilha.ObterTamanho() == 0)
                Console.WriteLine("correta");
            else
                Console.WriteLine("errada");

        }
    }

    class Pilha
    {

        private char[] vet;
        private int n;

        public Pilha(int tam)
        {
            vet = new char[tam];
            n = 0;
        }

        public void Inserir(char c)
        {
            if (n >= vet.Length)
                throw new Exception("Erro!");
            vet[n] = c;
            n++;
        }

        public char Remover()
        {
            if (n == 0)
                throw new Exception("Erro!");
            n--;
            return vet[n];
        }

        public int ObterTamanho()
        {
            return n;
        }

    }

}
