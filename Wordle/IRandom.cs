using System;
using System.Collections.Generic;
using System.Text;

namespace Wordle
{
    public interface IRandom
    {
        public void RandomWord(ISetting setting);
    }
}
