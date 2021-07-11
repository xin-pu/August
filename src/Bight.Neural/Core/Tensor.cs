using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace Bight.Neural.Core
{
    /// <summary>
    ///     Tensor is multi Matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Tensor<T> : MvxViewModel
        where T : struct
    {
        public int BatchSize { set; get; }

        public int AxisSize { set; get; }

        public IList<T> listData { set; get; }

        public virtual void Disrupt()
        {
            /*   Color[] temp;
               temp = new Color[colors.Length];
               for (int i = 0; i < temp.Length; i++)
               {
                   temp[i] = colors[i];
               }
   
               //打乱数组中元素顺序
               Random rand = new Random(DateTime.Now.Millisecond);
               for (int i = 0; i < temp.Length; i++)
               {
                   int x, y; Color t;
                   x = rand.Next(0, temp.Length);
                   do
                   {
                       y = rand.Next(0, temp.Length);
                   } while (y == x);
   
                   t = temp[x];
                   temp[x] = temp[y];
                   temp[y] = t;
               }
   
               return temp;*/
        }
    }
}