using Sorting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SortingProgram
{
      class Sorting
      {
            static Stopwatch BinaryStopWatch = new Stopwatch();

            static Stopwatch LinearStopWatch = new Stopwatch();


            public static void Main(string[] args)
            {
                  FileHandler fileHandler = new FileHandler();

                  List<string> items = fileHandler.ReadFile(@"C:\Users\Dragan\Downloads\unsorted_numbers.csv");

                  List<int> newItems = new List<int>();

                  foreach (var item in items)
                  {
                        newItems.Add(Int32.Parse(item));
                  }

                 

                  var shellSortData = ShellSort(newItems);

                  //var insertionData = InsertionSort(newItems);

                  long biggestNumber = LinearSearch(shellSortData);
                  string linearWatchTime = LinearStopWatch.Elapsed.TotalSeconds.ToString();
                  Console.WriteLine($"Linear Times: " + linearWatchTime + " seconds");

                  Binary(biggestNumber, shellSortData, 0, 14999);
                  string binaryWatchTime = BinaryStopWatch.Elapsed.TotalSeconds.ToString();
                  Console.WriteLine($"Binary Time: " + binaryWatchTime + " seconds");
                  Console.ReadKey();
            }

            public static long LinearSearch(List<int> _data)
            {
                  LinearStopWatch.Start();
                  int biggest = _data[0];
                  int biggestIndex = 0;
                  for (int i = 1; i < _data.Count; i++)
                  {
                        if (_data[i] > biggest)
                        {
                              biggest = _data[i];
                              biggestIndex = i;
                        }
                  }
                  Console.WriteLine($"Linear Biggest Number: " + _data[biggestIndex]);
                  while (biggestIndex > -1)
                  {
                        Console.WriteLine($"Linear Recursive Count Down: " + _data[biggestIndex]);
                        biggestIndex -= 1500;
                  }
                  LinearStopWatch.Stop();
                  return biggest;
            }

            public static long Binary(long numberToFind, List<int> _data, int minIndex, int maxIndex)
            {
                  BinaryStopWatch.Start();
                  if (minIndex > maxIndex)
                  {
                        return -1;
                  }

                  int mid = ((maxIndex + minIndex) / 2);


                  if (numberToFind < _data[mid])
                  {
                        return Binary(numberToFind, _data, minIndex, mid - 1);
                  }

                  else if (numberToFind > _data[mid])

                  {
                        return Binary(numberToFind, _data, mid + 1, maxIndex);
                  }
                  else
                  {
                        Console.WriteLine($"Binary Biggest Index: " + _data[mid]);
                        while (mid > -1)
                        {
                              Console.WriteLine($"Binary Recursive Count Down: " + _data[mid]);
                              mid -= 1500;
                        }
                        BinaryStopWatch.Stop();
                        return 0;
                  }
            }


            //Insertion Sorting Method
            public static List<int> InsertionSort(List<int> array)
            {
                  int length = array.Count;

                  for (int i = 1; i < length; i++)
                  {
                        int j = i;

                        while ((j > 0) && (array[j] < array[j - 1]))
                        {
                              int k = j - 1;
                              int temp = array[k];
                              array[k] = array[j];
                              array[j] = temp;

                              j--;
                        }
                  }
                  return array;
            }


            //Shell Sorting Method
            public static List<int> ShellSort(List<int> array)
            {
                  int n = array.Count;
                  int gap = n / 2;
                  int temp;

                  while (gap > 0)
                  {
                        for (int i = 0; i + gap < n; i++)
                        {
                              int j = i + gap;
                              temp = array[j];

                              while (j - gap >= 0 && temp < array[j - gap])
                              {
                                    array[j] = array[j - gap];
                                    j = j - gap;
                              }

                              array[j] = temp;
                        }

                        gap = gap / 2;
                  }

                  return array;
            }
      }
}
