using System;
using System.Collections.Generic;

namespace Thalus.Extensions
{
    public static class StringArrayExtension
    {
        public static bool EqualsIgnore(this IList<string> l, IList<string> compr)
        {
            return Equals(l, compr, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool EqualsInvariantIgnore(this IList<string> l, IList<string> compr)
        {
            return Equals(l, compr, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool Equals(this IList<string> l, IList<string> compr, StringComparison sComp)
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
                if (!l[i].Equals(compr[i],sComp))
                {
                    return false;
                }
            }

            return true;
        }
    }
}