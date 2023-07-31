using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MentorshipProgram.Session2;
using static MentorshipProgram.Session1.CustomHashMapProgram;
using static MentorshipProgram.Session2.MyCollections;

namespace MyBenchmarks
{
    [MemoryDiagnoser]
    public class MemoryBenchmarkerDemo
    {
        int NumberOfItems = 2;
        [Benchmark]
        public void MyDictionary()
        {
            var my_dictionary = new MyDictionary();
            for (int i = 0; i < NumberOfItems; i++)
            {
                my_dictionary.Add("key" + (char)(i + 65), "val1");
                Console.WriteLine(my_dictionary.GetValue("key" + (char)(i + 65)));
                my_dictionary.Remove("key" + (char)(i + 65));
                Console.WriteLine(my_dictionary.Size());
            }
        }
        [Benchmark]
        public void Dictionary()
        {
            var dictionary = new Dictionary<string, string>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                dictionary.Add("key" + (char)(i + 65), "val1");
                Console.WriteLine(dictionary["key" + (char)(i + 65)]);
                dictionary.Remove("key" + (char)(i + 65));
                Console.WriteLine(dictionary.Count());
            }
        }

        [Benchmark]
        public void MyArrayList()
        {
            var test = new MyArrayList();
            for (int i = 0; i < NumberOfItems; i++)
            {
                test.Add(i);
                test.Put(i,i);
                test.Remove(i);
                Console.WriteLine(test.Size());
            }
        }
        [Benchmark]
        public void ArrayList()
        {
            var test = new ArrayList();
            for (int i = 0; i < NumberOfItems; i++)
            {
                test.Add(i);
                test[i] = i;
                test.Remove(i);
                Console.WriteLine(test.Count);
            }
        }

        [Benchmark]
        public void MySet()
        {
            var test = new MySet();
            for (int i = 0; i < NumberOfItems; i++)
            {
                test.Add(i);
                test.Remove(i);
                Console.WriteLine(test.Size());
            }
        }
        [Benchmark]
        public void Set()
        {
            var test = new HashSet<int>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                test.Add(i);
                test.Remove(i);
                Console.WriteLine(test.Count);
            }
        }
    }

    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var summary = BenchmarkRunner.Run(typeof(MemoryBenchmarkerDemo).Assembly);
        //    Console.ReadKey();
        //}
    }
}