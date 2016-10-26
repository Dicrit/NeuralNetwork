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
            //FirstTest();
            ThirdTest();
            //SecondTest();
            Console.ReadLine();
        }
        static void SecondTest()
        {
            Dictionary<int, String> dictionary = new Dictionary<int, string>();
            dictionary.Add(0, "0");
            dictionary.Add(1, "1");
            NeuralNetworkChoise net = new NeuralNetworkChoise(2, dictionary, new int[]{2});
            getResults(net);
            for (int i = 0; i < 10000; i++)
            {
                train(net);
            }
            getResults(net);
        }
        static void train(NeuralNetworkChoise net)
        {
            net.train(new double[] { 0, 0 }, 0);
            net.train(new double[] {1, 0 }, 1);
            net.train(new double[] {0, 1 }, 1);
            net.train(new double[] { 1, 1 }, 0);
        }
        static void getResults(NeuralNetworkChoise net)
        {
            Console.WriteLine("{");
            Console.WriteLine(net.getResult(new double[] { 0, 0 }));
            Console.WriteLine(net.getResult(new double[] { 1, 0 }));
            Console.WriteLine(net.getResult(new double[] { 0, 1 }));
            Console.WriteLine(net.getResult(new double[] { 1, 1 }));
            Console.WriteLine("}");
        }

        static void FirstTest()
        {
            NeuralNetwork net = new NeuralNetwork(2, 1, new int[] { 3 });
            getResults(net);
            for (int i = 0; i < 10000; i++)
            {
                train(net);
            }
            getResults(net);

        }
        static void ThirdTest()
        {
            NeuralNetwork net = new NeuralNetwork(2, 2, new int[] {3});
            getResults3(net);
            for (int i = 0; i < 10000; i++)
            {
                train3(net);
            }
            getResults3(net);
        }

        private static void getResults3(NeuralNetwork net)
        {
            Console.WriteLine("{");
            Console.WriteLine(net.getResult(new double[] { 0, 0 })[0]
                + "-----" + net.getResult(new double[] { 0, 0 })[1]);
            Console.WriteLine(net.getResult(new double[] { 0, 1 })[0]
                + "-----" + net.getResult(new double[] { 0, 1 })[1]);
            Console.WriteLine(net.getResult(new double[] { 1, 0 })[0]
                + "-----" + net.getResult(new double[] { 1, 0 })[1]);
            Console.WriteLine(net.getResult(new double[] { 1, 1 })[0]
                + "-----" + net.getResult(new double[] { 1, 1 })[1]);
            Console.WriteLine("}");
        }
        static void train3(NeuralNetwork net)
        {
            net.train(new double[] { 0, 0 }, new double[] { 0,0 });
            net.train(new double[] { 0, 1 }, new double[] { 1,1 });
            net.train(new double[] { 1, 0 }, new double[] { 1,1 });
            net.train(new double[] { 1, 1 }, new double[] { 0,0 });
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
