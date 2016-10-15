using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Console.WriteLine(net.weights[i].ToString());
            }
            getResults(net);
            for (int i = 0; i < 50; i++)
            {
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
