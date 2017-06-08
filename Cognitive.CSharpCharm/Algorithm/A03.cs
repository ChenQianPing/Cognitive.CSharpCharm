using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognitive.CSharpCharm.Algorithm
{
    public static class A03
    {
        /* 每瓶啤酒2元，2个空酒瓶或4个瓶盖可换1瓶啤酒。10元最多可喝多少瓶啤酒？ 
         * x+y+z=2；
         * 2y=2；
         * 4z=2；
         * 解得x=0.5，y=1，z=0.5，10/0.5=20，
         */
        public static int Beer = 50;
        public static int EmptyBottle;
        public static int Lid;

        public static void A0301()
        {
            Beer = Beer + Drink(50, 50);

            Console.WriteLine("总共能喝" + Beer);
            Console.WriteLine("剩下酒瓶个数" + EmptyBottle);
            Console.WriteLine("剩下盖子个数" + Lid);

            Console.ReadKey();

            /**
             * 15 Beer，1 EmptyBottle，3 Lid；
             */

        }

        public static int Drink(int remainderEmptyBottle, int remainderLid)
        {
            if (remainderEmptyBottle >= 2 || remainderLid >= 4)
            {
                EmptyBottle = (remainderEmptyBottle/2) + (remainderEmptyBottle%2) + (remainderLid/4);

                Lid = (remainderLid/4) + (remainderLid%4) + (remainderEmptyBottle/2);

                return (remainderEmptyBottle/2) + (remainderLid/4) + Drink(EmptyBottle, Lid);
            }
            return 0;
        }
    }
}


