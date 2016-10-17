using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static List<double> results = new List<double>();


        static void Main(string[] args)
        {
            NeuralNetwork net = new NeuralNetwork(2,1,new int[] {2});
            Console.WriteLine(net);
            for (int i = 0; i < net.weights.Length; i++)
            {
                Console.WriteLine("Layer {0}", i);
                for (int j = 0; j < net.layers[i].Length+1; j++)
                {
                    for (int k = 0; k < net.layers[i + 1].Length; k++)
                    {
                        Console.WriteLine("weight [{0},{1}] = {2}",j,k,net.weights[i][j,k]);
                    }
                }
            }
            getResults(net);
            for (int i = 0; i < 1000; i++)
            {
                //Console.WriteLine("Training "+i);
                //Thread.Sleep(10);
                train(net);
            }
            getResults(net);

            Console.ReadLine();
        }
        static void train(NeuralNetwork net)
        {
            net.train(new double[] { 0, 0 }, new double[] { 0 });
            net.train(new double[] { 0, 1 }, new double[] { 1 });
            net.train(new double[] { 1, 0 }, new double[] { 1 });
            net.train(new double[] { 1, 1 }, new double[] { 0 });
        }

        static void getResults(NeuralNetwork net)
        {
            results = new List<double>();
            results.Add(net.getResult(new double[] { 0, 0 })[0]);
            results.Add(net.getResult(new double[] { 0, 1 })[0]);
            results.Add(net.getResult(new double[] { 1, 0 })[0]);
            results.Add(net.getResult(new double[] { 1, 1 })[0]);
            showResults();
        }

        static void showResults()
        {
            Console.WriteLine("Showing results {");
            foreach (double d in results)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine("}");
        }
    }
}
