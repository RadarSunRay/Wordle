using System;
using System.Collections.Generic;
using System.Text;

namespace Wordle
{
    public class MyRandom : IRandom
    {
        public void RandomWord(ISetting setting)
        {
            var random = new Random();
            var randomWords = random.Next(setting.words.Length);
            setting.word = setting.words[randomWords];
        }
    }
}
