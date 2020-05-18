using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Cw4
{
    public class TreningHandler
    {
        List<Flower> flowersContainer;
        int k;
        List<Group> groups;

        public TreningHandler(List<Flower> flowersContainer, int k) {
            this.flowersContainer = flowersContainer;
            this.k = k;
            createGroups();
            assignEmptyToGroups();
            shuffleGroups();
        }
        public void createGroups()
        {
            groups = new List<Group>();
            for (int i = 0; i < k; i++)
            {
                groups.Add(new Group(flowersContainer[i].vector, new List<Flower>()));
                
            }



        }

        public void assignEmptyToGroups()
        {
            int y = 0;

            foreach (var flower in flowersContainer)
            {

                groups[y].flowers.Add(flower);
                y++;

                if (y == groups.Count)
                {
                    y = 0;
                }
            }
        }

        private void shuffleGroups()
        {
            int iterations = 0;
            bool didCentroidChange = true;
            
            while (didCentroidChange)
            {
                List<Vector> oldCentroids = new List<Vector>();
                for (int i = 0; i < groups.Count; i++) {
                    oldCentroids.Add(groups[i].centroid);
                }
                calcCentroid();

                StringBuilder sbn = new StringBuilder().Append("NEW CENTROID: ");
                StringBuilder sbo = new StringBuilder().Append("OLD CENTROID: ");

                for (int i = 0; i < groups.Count; i++)
                {
                    sbo.Append(oldCentroids[i]).Append(" ");
                    sbn.Append(groups[i].centroid).Append(" ");
                   
                }
             //   Console.WriteLine(sbo);
              //  Console.WriteLine(sbn);
                Console.WriteLine();

                didCentroidChange = false;
                for (int i = 0; i < groups.Count; i++) {
                    for (int j = 0; j < oldCentroids[i].values.Count; j++)
                    {
                        if (oldCentroids[i].values[j] != groups[i].centroid.values[j])
                        {
                            didCentroidChange = true;
                        }
                    }
                }
                assignToGroups();

                for(int i = 0; i < groups.Count; i++) {
                    Console.WriteLine("GROUP ID: " + i + " SUMOFDDISTANCESQUARED: " + sumOfDistance2(groups[i]));
                }


                iterations++;
            }
            for (int i = 0; i < groups.Count; i++) {
                for (int j = 0; j < groups[i].flowers.Count; j++)
                {
                    Console.WriteLine(groups[i].flowers[j].name);
                }
                Console.WriteLine("ENTROPIA: " + calcEntropia(groups[i]));
              //  Console.WriteLine("SUMSQUARED: " + sumOfDistance2(groups[i]));
            }
            Console.WriteLine("ITERATIONS: " + iterations);
        }
        private void calcCentroid()
        {
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].centroid = average(groups[i]);
            }
        }

        private void assignToGroups()
        {
            List<Group> groupsTmp = groups;
            foreach (var list in groupsTmp)
            {
                list.flowers.Clear();
            }
            foreach (var flower in flowersContainer)
            {
                double distance = 0;
                int groupNum = 0;
                

                for (int i = 0; i < groups.Count; i++)
                {
                    if (i == 0)
                        distance = checkDistance(flower.vector, groups[i].centroid);

                    if (checkDistance(flower.vector, groups[i].centroid) < distance)
                    {
                        distance = checkDistance(flower.vector, groups[i].centroid);
                        groupNum = i;
                    }
                }
                
                groupsTmp[groupNum].flowers.Add(flower);
            }
            groups = groupsTmp;
        }

        private double checkDistance(Vector v1, Vector v2) {

            if (v1.values.Count != v2.values.Count) {
                throw new ArgumentException("Vectors must be the same size!");
            }

            double distance = 0;

            for (int i = 0; i < v1.values.Count; i++) {
                distance += Math.Pow(v2.values[i] - v1.values[i],2);
            }

            distance = Math.Sqrt(distance);

            return distance;
        }

        private Vector average(Group group){
            Vector vector = new Vector();
            if (group.flowers.Count > 0)
            {
                int vecLength = group.flowers[0].vector.values.Count;
                //int vecLength = groups[0].flowers[0].vector.values.Count;
                double[] values = new double[vecLength];
                for (int i = 0; i < group.flowers.Count; i++)
                {
                    for (int j = 0; j < vecLength; j++)
                    {
                        values[j] += group.flowers[i].vector.values[j];
                    }
                }

                for (int i = 0; i < values.Length; i++)
                {
                    vector.values.Add(values[i] / group.flowers.Count);
                }

                return vector;
            }

            return group.centroid;
        }

        private double sumOfDistance2(Group group) {
            double sum = 0;
            foreach (var flower in group.flowers) {
                sum += Math.Pow(checkDistance(flower.vector, group.centroid),2);
            }
            return sum;
        }
     
        private static double calcEntropia(Group group)
        {
            double firstType = 0;
            double secondType = 0;
            double thirdType = 0;
            double allTypes = 0;
            foreach (var flower in group.flowers)
            {
                if (flower.name == "Iris-setosa")
                {
                    firstType++;
                }
                else if (flower.name == "Iris-versicolor")
                {
                    secondType++;
                }
                else if (flower.name == "Iris-virginica")
                {
                    thirdType++;
                }
            }
            allTypes = group.flowers.Count;

            double p1 = firstType/allTypes, p2 = secondType/allTypes, p3 = thirdType/allTypes;


            double e = p1 * (p1 == 0 ? 0 : Math.Log2(p1)) +
                         p2 * (p2 == 0 ? 0 : Math.Log2(p2)) +
                      p3 * (p3 == 0 ? 0 : Math.Log2(p3));
            if (e != 0)
            {
                e = e * -1;
            }


            return e;
        }

        
    }
}
