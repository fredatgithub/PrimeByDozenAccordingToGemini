using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrimeByDozenAccordingToGemini
{
  class Program
  {
    static void Main()
    {
      const int start = 2;
      const int range = 10000; // Utilisation d'une variable pour la plage

      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      List<int> primes = FindPrimesInRange(start, start + range);

      stopwatch.Stop();
      TimeSpan elapsedTime = stopwatch.Elapsed;

      Console.WriteLine($"Nombres premiers entre {start} et {start + range} :");
      //foreach (int prime in primes)
      //{
      //  Console.Write(prime + " ");
      //}

      Console.WriteLine();

      Console.WriteLine($"Temps d'exécution : {elapsedTime.TotalMilliseconds} ms");

      // Calcul du nombre de nombres premiers par dizaine
      Console.WriteLine("\nNombre de nombres premiers par dizaine :");
      for (int i = start; i < start + range; i += 10)
      {
        int count = primes.Count(p => p >= i && p < i + 10);
        Console.WriteLine($"[{i}-{i + 9}] : {count}");
      }

      // Calcul du nombre de nombres premiers par centaine
      Console.WriteLine("\nNombre de nombres premiers par centaine :");
      for (int i = start; i < start + range; i += 100)
      {
        int count = primes.Count(p => p >= i && p < i + 100);
        Console.WriteLine($"[{i}-{i + 99}] : {count}");
      }

      // Ajout du calcul par milliers
      Console.WriteLine("\nNombre de nombres premiers par millier :");
      int countMillier = primes.Count(p => p >= start && p <= start + range);
      Console.WriteLine($"[{start}-{start + range}] : {countMillier}");


      Console.WriteLine("Press any key to exit:");
      Console.ReadKey();
    }

    static List<int> FindPrimesInRange(int start, int end)
    {
      List<int> primes = new List<int>();

      if (start <= 2 && 2 <= end)
      {
        primes.Add(2);
      }

      int currentNumber = (start % 2 == 0) ? start + 1 : start;

      for (int number = currentNumber; number <= end; number += 2)
      {
        if (IsPrime(number))
        {
          primes.Add(number);
        }
      }

      return primes;
    }

    static bool IsPrime(int number)
    {
      if (number <= 1)
      {
        return false;
      }

      if (number <= 3)
      {
        return true;
      }

      if (number % 2 == 0 || number % 3 == 0)
      {
        return false;
      }

      for (int i = 5; i * i <= number; i = i + 6)
      {
        if (number % i == 0 || number % (i + 2) == 0)
        {
          return false;
        }
      }

      return true;
    }
  }
}
