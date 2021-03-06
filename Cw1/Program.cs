﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cw1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numOfParams = 0;

            Console.WriteLine("WRITE K:");

            int k = Convert.ToInt32(Console.ReadLine());

            bool isFirst = true;
            while (true)
            {
                var lines = File.ReadLines("..\\..\\..\\iris_training.txt");

                if (k == 0 || isFirst == false)
                {
                    Console.WriteLine("Podaj wartość K: ");
                    k = Convert.ToInt32(Console.ReadLine());
                    isFirst = false;
                    
                    
               
                    
                }
                
                
                

                

                bool isFirstIteration = true;

                Parameters parameters = new Parameters();
                char[] splits = new char[] { ' ', '\t' };
                foreach (var line in lines)
                {

                    var data = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);

                    if (isFirstIteration)
                    {
                        numOfParams = data.Length;
                        isFirstIteration = false;
                    }


                    XVector vector = new XVector();

                    for (int i = 0; i < numOfParams - 1; i++)
                    {

                        vector.xvector.Add(Double.Parse(data[i].Replace(",", ".")));
                        // Console.Write(data[i] + " ");
                    }
                    vector.expectedResult = data[numOfParams - 1];
                    //Console.WriteLine("");
                    parameters.parameters.Add(vector);
                }
                /*
                            foreach (var param in parameters) {
                                for (int i = 0; i < param.xvector.Count; i++) {
                                    Console.Write(param.xvector[i] + " ");
                                }
                                Console.Write(param.expectedResult);
                                Console.WriteLine("");
                            }*/


                var linestest = File.ReadLines("..\\..\\..\\iris_test.txt");
                var parameterstest = new Parameters();


                
                if (!isFirst) {
                    Console.WriteLine("Napisz N jako wartość jezeli nie chcesz podac kolejnej zmiennej");

                    Console.WriteLine("Podaj x1");
                    
                    double x1 = Convert.ToDouble(Console.ReadLine());

                  
                    Console.WriteLine("Podaj x2");
                    
                    double x2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Podaj x3");
                   
                    double x3 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Podaj x4");
                    
                    double x4 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Podaj x5");

                    Console.ReadLine();

                    using (File.Create("tmp.txt")) {
                        Console.WriteLine("FiLE CREATED");
                    } ;
                    File.WriteAllText("tmp.txt", x1 + "    	 " + x2 + "    	 " + x3 + "    	 " + x4 + "    	" + "???");
                    linestest = File.ReadLines("tmp.txt");
                }

                foreach (var line in linestest)
                {

                    var data = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);

                    XVector vector = new XVector();

                    for (int i = 0; i < numOfParams - 1; i++)
                    {

                        vector.xvector.Add(Double.Parse(data[i].Replace(",", ".")));
                        // Console.Write(data[i] + " ");
                    }
                    vector.expectedResult = data[numOfParams - 1];
                    //Console.WriteLine("");
                    parameterstest.parameters.Add(vector);
                }

                XVector[] tab = new XVector[k];

                double count = 0;
                double fullcount = 0;


                foreach (var xvectortest in parameterstest)
                {
                    List<XVector> list = new List<XVector>();

                    foreach (var xvector in parameters)
                    {

                        var distance = XVector.getDistance(xvector, xvectortest);

                        list.Add(xvector);


                    }

                    list = list.OrderBy(a => XVector.getDistance(a, xvectortest)).ToList();
                    //   list.Reverse();


                    for (int i = 0; i < k; i++)
                    {
                        tab[i] = list[i];

                    }

                    string expectedResult = xvectortest.expectedResult + " ";
                    for (int i = 0; i < numOfParams - 1; i++)
                    {


                        expectedResult += xvectortest.xvector[i] + " ";
                    }
                    Console.WriteLine("EXPECTED RESULTS: " + expectedResult);

                    for (int i = 0; i < k; i++)
                    {
                        string res = "";
                        for (int j = 0; j < numOfParams - 1; j++)
                        {
                            res += tab[i].xvector[j] + " ";
                        }

                        Console.WriteLine("CLOSEST: " + tab[i].expectedResult + " " + res + " dist:" + XVector.getDistance(tab[i], xvectortest));
                    }

                    List<Flower> flowers = new List<Flower>();
                    for (int i = 0; i < k; i++)
                    {
                        var index = flowers.FindIndex(a => a.name == tab[i].expectedResult);


                        if (index >= 0)
                        {
                            flowers[index].count += 1;
                        }
                        else if (index < 0)
                        {
                            flowers.Add(new Flower { name = tab[i].expectedResult, count = 1 });
                        }


                    }
                    Flower flow = new Flower { name = "" };
                    foreach (var flo in flowers)
                    {
                        if (flow.count < flo.count)
                        {
                            flow.name = flo.name;
                            flow.count = flo.count;
                        }
                    }

                    Console.WriteLine("PRZYPISANIE DO: " + flow.name + " " + flow.count);
                    Console.WriteLine("");

                    fullcount++;
                    if (flow.name == xvectortest.expectedResult)
                    {
                        count++;
                    }




                    tab = new XVector[k];

                }
                if (isFirst)
                {
                    Console.WriteLine("Łączna liczba dopasowań " + fullcount);
                    Console.WriteLine("LICZBA POPRAWNYCH DOPASOWAŃ " + count);

                    Console.WriteLine("PROCENT " + (count / fullcount) * 100 + "%");
                }
                else { 
                   
                }
                isFirst = false;
            }
        }
     
    }
}
