using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognitive.CSharpCharm.Algorithm;
using Cognitive.CSharpCharm.Patterns.FactoryPattern.Factory02;
using Cognitive.CSharpCharm.Utils;

namespace Cognitive.CSharpCharm
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = U01.GenerateScoreDetail(10, 0.4);
            Console.WriteLine(result);

            Console.ReadLine();
        }




    }
}
