using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator13Problema5
{
    class Program
    {
        static void Merge_Sort(int n, int[] X)//functia mergesort descrescator
        {
            if (n == 2)//mai intai verifica daca in vector au mai ramas doar doua elemente
            {
                if (X[0] < X[1])//daca nici acuma nu sunt in ordine le schimba pozitia (puteam folosi un int aux dar am preferat sa nu)
                {
                    X[0] = X[1] + X[0];
                    X[1] = X[0] - X[1];
                    X[0] = X[0] - X[1];
                }
            }
            else
            {
                //impartim vectorul original in doua
                int m = n / 2;
                int[] A = new int[m];
                //A-ul are prima jumatate din elemente
                for (int i = 0; i < m; i++)
                    A[i] = X[i];
                //iar B-ul a doua jumatate
                int[] B = new int[n-m];
                for (int i = m; i < n; i++)
                    B[i-m] = X[i];

                //recursiv reaplicam Merge_Sort functie pentru A si B (care la randul lor vor fi impartite in doua)
                Merge_Sort(m, A);
                Merge_Sort(n - m, B);

                //rezultatul il combinam prin functia de concatanare a vectorilor ordonati
                Merge(n, A, B, X);
            }
        }
        static void Merge(int n, int[] A, int[] B, int[] X)//functia de concatanare de O(n) viteza
        {
            //ia rand pe rand elementele din fiecare vector A si B (care sunt jumatatile lui X)
            //i este pentru indexul lui A si j pentru indexul lui B 
            int i = 0, j = 0;
            for(int k=0; k<n; k++)
            {
                //compara elementul curent A[i] cu B[j]
                //elementul mai mare este adaugat in X
                if (A[i] >= B[j])
                {
                    X[k] = A[i];
                    i++; //si se incrementeaza i-ul
                }
                else//in caz contrar se adauga elementul din B si se incrementeaza j-ul
                {
                    X[k] = B[j];
                    j++;
                }

            }
        }
        static void afisare_vector(int[] a)
        {
            for(int i=0; i<a.Length; i++)
                Console.Write("{0} ", a[i]);
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n= rnd.Next(5, 20);
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(1, 50);
            Console.WriteLine("Sirul considerat: ");
            afisare_vector(a);

            Merge_Sort(n,a);
            afisare_vector(a);
            Console.ReadLine();
        }
    }
}
