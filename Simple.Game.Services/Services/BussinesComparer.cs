using Simple.Game.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple.Game.Services.Services
{
    public class BussinesComparer<T>: IBussinesComparer<T> where T :class, IComparable<T>
    {
        public int Compare(List<T> randomsList)
        {
            var compare = randomsList.First().CompareTo(randomsList.Last());
            switch (compare)
            {
                case -1: return 1;
                case 1: return 0;
                default: return -1;
            };
        }
    }
}
