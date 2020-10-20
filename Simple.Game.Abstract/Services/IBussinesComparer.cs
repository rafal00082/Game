using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Game.Abstract.Services
{
    public interface IBussinesComparer<T>
    {
        public int Compare(List<T> randomList);
    }
}
