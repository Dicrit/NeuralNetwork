﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class NeuralNetwork
    {
        public double learnRate = 0.2;
        public double[][] layers; //PRIVATE!!!
        public double[][,] weights; //MAKE PRIVATE
        public NeuralNetwork(int inputs,int outputs, int[] LayersSize = null)
        {
            //this.inputs = new double[inputs];
            //this.outputs = new double[outputs];
            
            layers = new double[LayersSize.Length+2][];
            layers[0] = new double[inputs];
            if (LayersSize != null)
            {
                for (int i = 0; i < LayersSize.Length; i++)
                {
                    layers[i+1] = new double[LayersSize[i]];
                }
            }
            layers[LayersSize.Length + 1] = new double[outputs];
            InitializeWeights();
        }
        private void InitializeWeights()
        {
            Random rand = new Random();
            weights = new double[layers.Length - 1][,];
            for (int i = 0; i < layers.Length - 1; i++)
            {
                weights[i] = new double[layers[i].Length + 1, layers[i + 1].Length];
                for (int j = 0; j < layers[i].Length + 1; j++)
                {
                    for (int k = 0; k < layers[i + 1].Length; k++)
                    {
                        weights[i][j, k] = rand.NextDouble()-0.5d;
                    }
                }
            }
        }
        private void checkValues(double[] inps, double[] outps)
        {
            if (inps.Length != layers[0].Length || outps.Length != layers[layers.Length - 1].Length) throw new Exception("Wrong data format!");
            }
        public void train(double[] inps, double[] outps)
        {
            checkValues(inps, outps);
            double[] results = getResult(inps);
            double[][] err = new double[layers.Length][];
            err[layers.Length - 1] = new double[layers[layers.Length - 1].Length];
            for (int o = 0; o < layers[layers.Length - 1].Length; o++) //Ошибка выходного слоя
            {
                err[layers.Length - 1][o] = (outps[o] - layers[layers.Length - 1][o]) * sigmoidDerivative(layers[layers.Length - 1][o]);
            }
            for (int layer = layers.Length - 1; layer > 0; layer--)
            {
                err[layer-1] = new double[layers[layer-1].Length];
                for (int cur = 0; cur < layers[layer - 1].Length; cur++)
                {
                    err[layer-1][cur] = 0;
                    for (int next = 0; next < layers[layer].Length; next++)
                    {
                        err[layer - 1][cur] += err[layer][next];
                    }
                    err[layer-1][cur] *= sigmoidDerivative(layers[layer-1][cur]);
                }
                for (int cur = 0; cur < layers[layer].Length; cur++)
                {
                    for (int prev = 0; prev < layers[layer-1].Length; prev++)
                    {
                        weights[layer - 1][prev, cur] += learnRate * err[layer][cur] * layers[layer - 1][prev];
                    }
                    weights[layer - 1][layers[layer - 1].Length, cur] += learnRate * err[layer][cur];//обновить смещение
                }
            }
        }
        private double sigmoid(double val)
        {
            return (1 / (1.0 + Math.Exp(-val)));
        }
        private double sigmoidDerivative(double val)
        {
            return (val * (1.0 - val));
        }
        public double[] getResult(double[] inps)
        {
            layers[0] = inps;
            checkValues(inps, layers[layers.Length - 1]);
            for (int layer = 1; layer < layers.Length; layer++)
            {
                for (int cur = 0; cur < layers[layer].Length; cur++)
                {
                    double sum = 0;
                    for (int prev = 0; prev < layers[layer - 1].Length; prev++)
                    {
                        sum += layers[layer - 1][prev] * weights[layer-1][prev,cur];
                    }
                    sum += weights[layer - 1][layers[layer - 1].Length, cur];
                    layers[layer][cur] = sigmoid(sum);
                }
            }

            return layers[layers.Length - 1];
            //return new double[]{};
        }
        public override string ToString()
        {
            string a = "";
            for (int i = 0; i < layers.Length; i++) a += layers[i].Length.ToString()+":";
            a = a.Remove(a.Length-1);
            return  a;
        }
    }
}