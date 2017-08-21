using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Algorithm
{
    /*
     * 聚类算法.
     */ 
    public class A04
    {
        public void TestMethod1()
        {
            Console.WriteLine("\nBegin k-means clustering demo\n");

            var rawData = new double[10][];
            rawData[0] = new double[] { 73, 72.6 };
            rawData[1] = new double[] { 61, 54.4 };
            rawData[2] = new double[] { 67, 99.9 };
            rawData[3] = new double[] { 68, 97.3 };
            rawData[4] = new double[] { 62, 59.0 };
            rawData[5] = new double[] { 75, 81.6 };
            rawData[6] = new double[] { 74, 77.1 };
            rawData[7] = new double[] { 66, 97.3 };
            rawData[8] = new double[] { 68, 93.3 };
            rawData[9] = new double[] { 61, 59.0 };

            Console.WriteLine("Raw unclustered height (in.) weight (kg.) data:\n");
            Console.WriteLine(" ID Height Weight");
            Console.WriteLine("---------------------");
            ShowData(rawData, 1, true, true);

            var numClusters = 3;
            Console.WriteLine("\nSetting numClusters to " + numClusters);

            Console.WriteLine("Starting clustering using k-means algorithm");
            var c = new Clusterer(numClusters);
            var clustering = c.Cluster(rawData);
            Console.WriteLine("Clustering complete\n");

            Console.WriteLine("Final clustering in internal form:\n");
            ShowVector(clustering, true);

            Console.WriteLine("Raw data by cluster:\n");
            Console.WriteLine(" ID Height Weight");
            ShowClustered(rawData, clustering, numClusters, 1);

            Console.WriteLine("\nEnd k-means clustering demo\n");
            Console.ReadLine();
        }


        private static void ShowData(double[][] data, int decimals,bool indices, bool newLine)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            for (var i = 0; i < data.Length; ++i)
            {
                if (indices == true)
                    Console.Write(i.ToString().PadLeft(3) + " ");

                for (var j = 0; j < data[i].Length; ++j)
                {
                    var v = data[i][j];
                    Console.Write(v.ToString("F" + decimals) + "   ");
                }

                Console.WriteLine("");
            }

            if (newLine == true)
                Console.WriteLine("");
        }


        private static void ShowVector(int[] vector, bool newLine)
        {
            if (vector == null) throw new ArgumentNullException(nameof(vector));

            for (var i = 0; i < vector.Length; ++i)
                Console.Write(vector[i] + " ");

            if (newLine == true)
                Console.WriteLine("\n");
        }

        private static void ShowClustered(double[][] data, int[] clustering,int numClusters, int decimals)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (clustering == null) throw new ArgumentNullException(nameof(clustering));

            for (var k = 0; k < numClusters; ++k)
            {
                Console.WriteLine("===================");
                for (var i = 0; i < data.Length; ++i)
                {
                    var clusterId = clustering[i];
                    if (clusterId != k) continue;
                    Console.Write(i.ToString().PadLeft(3) + " ");
                    for (var j = 0; j < data[i].Length; ++j)
                    {
                        var v = data[i][j];
                        Console.Write(v.ToString("F" + decimals) + "   ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("===================");
            }
        }
    }



    public class Clusterer
    {
        private readonly int _numClusters; // number of clusters 
        private int[] _clustering;         // index = a tuple, value = cluster ID 
        private readonly double[][] _centroids; // mean (vector) of each cluster 
        private readonly Random _rnd;           // for initialization 

        public Clusterer(int numClusters)
        {
            this._numClusters = numClusters;
            this._centroids = new double[numClusters][];
            this._rnd = new Random(0); // arbitrary seed 
        }

        public int[] Cluster(double[][] data)
        {
            var numTuples = data.Length;
            var numValues = data[0].Length;
            this._clustering = new int[numTuples];

            for (var k = 0; k < _numClusters; ++k) // allocate each centroid 
                this._centroids[k] = new double[numValues];

            InitRandom(data);

            Console.WriteLine("\nInitial random clustering:");
            for (var i = 0; i < _clustering.Length; ++i)
                Console.Write(_clustering[i] + " ");
            Console.WriteLine("\n");

            var changed = true;            // change in clustering? 
            var maxCount = numTuples * 10; // sanity check 
            var ct = 0;
            while (changed == true && ct <= maxCount)
            {
                ++ct; // k-means typically converges very quickly 
                UpdateCentroids(data); // no effect if fail 
                changed = UpdateClustering(data); // no effect if fail 
            }

            var result = new int[numTuples];
            Array.Copy(this._clustering, result, _clustering.Length);
            return result;
        }

        private void InitRandom(double[][] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var numTuples = data.Length;

            var clusterId = 0;
            for (var i = 0; i < numTuples; ++i)
            {
                _clustering[i] = clusterId++;
                if (clusterId == _numClusters)
                    clusterId = 0;
            }

            for (var i = 0; i < numTuples; ++i)
            {
                var r = _rnd.Next(i, _clustering.Length);
                var tmp = _clustering[r];
                _clustering[r] = _clustering[i];
                _clustering[i] = tmp;
            }
        }

        private void UpdateCentroids(double[][] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var clusterCounts = new int[_numClusters];
            for (var i = 0; i < data.Length; ++i)
            {
                var clusterId = _clustering[i];
                ++clusterCounts[clusterId];
            }

            // zero-out this.centroids so it can be used as scratch 
            for (var k = 0; k < _centroids.Length; ++k)
                for (var j = 0; j < _centroids[k].Length; ++j)
                    _centroids[k][j] = 0.0;

            for (var i = 0; i < data.Length; ++i)
            {
                var clusterId = _clustering[i];
                for (var j = 0; j < data[i].Length; ++j)
                    _centroids[clusterId][j] += data[i][j]; // accumulate sum 
            }

            for (var k = 0; k < _centroids.Length; ++k)
                for (var j = 0; j < _centroids[k].Length; ++j)
                    _centroids[k][j] /= clusterCounts[k]; // danger? 
        }

        private bool UpdateClustering(double[][] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            // (re)assign each tuple to a cluster (closest centroid) 
            // returns false if no tuple assignments change OR 
            // if the reassignment would result in a clustering where 
            // one or more clusters have no tuples. 

            var changed = false; // did any tuple change cluster? 

            var newClustering = new int[_clustering.Length]; // proposed result 
            Array.Copy(_clustering, newClustering, _clustering.Length);

            var distances = new double[_numClusters]; // from tuple to centroids

            for (var i = 0; i < data.Length; ++i) // walk through each tuple 
            {
                for (var k = 0; k < _numClusters; ++k)
                    distances[k] = Distance(data[i], _centroids[k]);

                var newClusterId = MinIndex(distances); // find closest centroid 
                if (newClusterId != newClustering[i])
                {
                    changed = true; // note a new clustering 
                    newClustering[i] = newClusterId; // accept update 
                }
            }

            if (changed == false)
                return false; // no change so bail 

            // check proposed clustering cluster counts 
            var clusterCounts = new int[_numClusters];
            for (var i = 0; i < data.Length; ++i)
            {
                var clusterId = newClustering[i];
                ++clusterCounts[clusterId];
            }

            for (var k = 0; k < _numClusters; ++k)
                if (clusterCounts[k] == 0)
                    return false; // bad clustering 

            Array.Copy(newClustering, _clustering, newClustering.Length); // update 
            return true; // good clustering and at least one change 
        }

        // Euclidean distance between two vectors for UpdateClustering() 
        private static double Distance(double[] tuple, double[] centroid)
        {
            if (tuple == null) throw new ArgumentNullException(nameof(tuple));
            if (centroid == null) throw new ArgumentNullException(nameof(centroid));

            var sumSquaredDiffs = NewMethod();
            for (var j = 0; j < tuple.Length; ++j)
                sumSquaredDiffs += (tuple[j] - centroid[j]) * (tuple[j] - centroid[j]);
            return Math.Sqrt(sumSquaredDiffs);
        }

        private static double NewMethod()
        {
            return 0.0;
        }

        // helper for UpdateClustering() to find closest centroid 
        private static int MinIndex(double[] distances)
        {
            if (distances == null) throw new ArgumentNullException(nameof(distances));

            var indexOfMin = 0;
            var smallDist = distances[0];
            for (var k = 1; k < distances.Length; ++k)
            {
                if (distances[k] < smallDist)
                {
                    smallDist = distances[k];
                    indexOfMin = k;
                }
            }
            return indexOfMin;
        }
    }

}
