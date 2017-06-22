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
        /// <param name="score"></param>
        /// <returns></returns>
        public static string GenerateScoreDetail(double score)
        {
            var scoreDetail = "";

            for (double i = 0; i <= score; i = i + 0.5)
            {
                if (Math.Abs(i) <= 0)
                {
                    scoreDetail = scoreDetail + i.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    scoreDetail = scoreDetail + "," + i.ToString(CultureInfo.InvariantCulture);
                }
                
            }

            return scoreDetail;
        }
    }
}
