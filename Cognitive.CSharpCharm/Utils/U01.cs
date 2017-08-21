using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Utils
{
    public static class U01
    {
        /// <summary>
        /// 生成分数明细；
        /// </summary>
        /// <param name="score">总分</param>
        /// <param name="step">步长</param>
        /// <returns></returns>
        public static string GenerateScoreDetail(double score,double step)
        {
            var lstDetail1 = new List<double>();
            var lstDetail2 = new List<double>();

            for (double i = 0; i <= score; i = i + step)
            {
                lstDetail1.Add(i);
            }

            for (var j = 0; j <= score; j = j + 1)
            {
                lstDetail2.Add(j);
            }

            // 剔除重复项 
            var lstResult = lstDetail1.Union(lstDetail2).ToList<double>();

            // 排序
            lstResult = lstResult.OrderBy(u => u).ToList();

            var scoreDetail = ListToString(lstResult, ",");

            return scoreDetail;
        }


        private static string ListToString(List<double> list, string separator)
        {
            if (list == null)
            {
                return null;
            }

            var result = new StringBuilder();
            var first = true;

            // 第一个前面不拼接","
            foreach (var str in list)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    result.Append(separator);
                }
                result.Append(str);
            }

            return result.ToString();
        }


    }
}
