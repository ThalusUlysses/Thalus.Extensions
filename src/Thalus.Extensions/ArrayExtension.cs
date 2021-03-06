﻿using System.Collections;
using System.Collections.Generic;

namespace Thalus.Extensions
{
    public static class ArrayExtension
    {
        public static TType[] Selection<TType>(this TType[] item,int from , int to = -1)
        {
            if (to < 0)
            {
                to = item.Length;
            }
            int cnt = 0;
            TType[] selection = new TType[to - from];
            for (int i = from; i < item.Length; i++)
            {
                selection[cnt] = item[i];
                cnt++;
            }

            return selection;
        }

        public static IList<TType> Selection<TType>(this IList<TType> item, int from, int to = -1)
        {
            if (to < 0)
            {
                to = item.Count;
            }
            int cnt = 0;
            TType[] selection = new TType[to - from];
            for (int i = from; i < item.Count; i++)
            {
                selection[cnt] = item[i];
                cnt++;
            }

            return selection;
        }

        public static bool Equals<TType>(this IList<TType> l, IList<TType> compr)
        {
            if (l.Equals(compr))
            {
                return true;
            }

            if (l.Count != compr.Count)
            {
                return false;
            }

            for (int i = 0; i < l.Count; i++)
            {
                if (!l[i].Equals(compr[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
