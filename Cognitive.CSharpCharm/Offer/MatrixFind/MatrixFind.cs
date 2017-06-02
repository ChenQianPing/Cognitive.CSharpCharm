using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Offer.MatrixFind
{
    public class MatrixFind
    {
        /// <summary>
        /// 二维数组matrix中，每一行都从左到右递增排序，每一列都从上到下递增排序.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool Find(int[,] matrix, int rows, int columns, int number)
        {
            var isFind = false;

            if (matrix == null || rows <= 0 || columns <= 0) return false;

            // 从第一行开始
            var row = 0;
            // 从最后一列开始
            var column = columns - 1;
            // 行：从上到下，列：从右到左
            while (row < rows && column >= 0)
            {
                if (matrix[row, column] == number)
                {
                    isFind = true;
                    break;
                }
                else if (matrix[row, column] > number)
                {
                    column--;
                }
                else
                {
                    row++;
                }
            }

            return isFind;
        }
    }
}


/*
 * 题目：在一个二维数组中，每一行都按照从左到右递增的顺序排序，
 * 每一列都按照从上到下递增的顺序排序。
 * 请完成一个函数，输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。　　
 * 
 * 解题思路：
 * 
 * 首先选取数组中右上角的数字。如果该数字等于要查找的数字，查找过程结束；
 * 如果该数字大于要查找的数字，剔除这个数字所在的列；
 * 如果该数字小于要查找的数字，剔除这个数字所在的行。
 * 也就是说如果要查找的数字不在数组的右上角，则每一次都在数组的查找范围中剔除一行或者一列，
 * 这样每一步都可以缩小查找的范围，直到找到要查找的数字，或者查找范围为空。
 */
