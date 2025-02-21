using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void MergeSort(List<Worker> workers)
        {
            if (workers.Count <= 1)
                return;

            int mid = workers.Count / 2;
            List<Worker> left = workers.GetRange(0, mid);
            List<Worker> right = workers.GetRange(mid, workers.Count - mid);

            MergeSort(left);
            MergeSort(right);
            Merge(workers, left, right);
        }

        static void Merge(List<Worker> workers, List<Worker> left, List<Worker> right)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Count && j < right.Count)
            {
                if (left[i].Salary <= right[j].Salary)
                    workers[k++] = left[i++];
                else
                    workers[k++] = right[j++];
            }

            while (i < left.Count)
                workers[k++] = left[i++];

            while (j < right.Count)
                workers[k++] = right[j++];
        }

        static void Main()
        {
            List<Worker> workers = new List<Worker>
    {
        new Worker("Иван", 2000),
        new Worker("Петър", 1500),
        new Worker("Мария", 1800),
        new Worker("Анна", 2500),
        new Worker("Георги", 1700)
    };

            MergeSort(workers);

            Console.WriteLine("Сортирани работници по заплата:");
            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.Name}: {worker.Salary}");
            }
        }
    }
}
