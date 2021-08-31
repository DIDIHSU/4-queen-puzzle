using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Queen
{
    class Program
    {
        //假設max為Q的數量
        static int max = 4;

        //定義陣列arr,儲存Q的位置
        static int[] _arr = new int[max];

        //解答次數統計
        static int _count = 0;

        static void Main(string[] args)
        {
            //從位置0開始
            QueenRowCheck(0);
            Console.Read();
        }
        //n為排列Q的次數=_arr陣列中的位置[0,1,2,3]
        private static void QueenRowCheck(int n)
        {
            //當n=max時，陣列已擺滿，計算結束，印出陣列結果
            if (n == max)
            {
                Print();
                return;
            }
            //依次放入Q，並判斷是否有衝突
            for (int i = 0; i < max; i++)
            {
                //先把當前這個Q的n,放到該行的第1列
                //陣列中n 的位置放入i這個數字
                _arr[n] = i;
                //判斷當放置第n個Q到i列時，是否衝突
                if (QueenColCheck(n))
                {
                    //如果不衝突，接著放n+1個Q，再重新跑一次QueenRowCheck
                    QueenRowCheck(n + 1);
                }
                //如果衝突，i會累加，繼續執行arr[n]=i
            }
        }

        //檢查規則
        //第n行
        private static bool QueenColCheck(int n)
        {
            for (int i = 0; i < n; i++)
            {
                //_arr[i] == _arr[n] =>檢查第n個Q，是否和前面的n-1個Q在同一列，同列即衝突，傳回false
                //Math.Abs(n - i) == Math.Abs(_arr[n] - _arr[i]) =>檢查與鄰近列中的Q是否在同一個斜線上，同斜線即衝突，傳回false
                if (_arr[i] == _arr[n] || Math.Abs(n - i) == Math.Abs(_arr[n] - _arr[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private static void Print()
        {
            //每計算出結果，count+1
            _count++;
            Console.WriteLine($"//Solution{ _count}");

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (_arr[i] != j)
                    {
                        Console.Write("\t.");
                    }
                    else
                    {
                        Console.Write("\tQ");
                    }
                }
                Console.WriteLine("");
            }
            System.Console.WriteLine();
        }
    }
}
