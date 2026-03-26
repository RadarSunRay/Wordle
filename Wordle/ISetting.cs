using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Wordle
{
    public interface ISetting
    {
        char[] board {  get; set; }
        string[] words { get; set; }
        string Answer { get; set; }
        string alphabet { get; set; }
        List<char> alphabet2 { get; set; }
        char[] answer { get; set; }
        string word { get; set; }
        ConsoleKeyInfo input { get; set; }
        public int count { get; set; }
        public int y { get; set; }
        bool gameOver { get; set; }
        public void SetCursorDraw(Point l, string c);
        public void CheckInput();
        public void Draw(int i);
        public bool GameOver()
        {
            if (Answer.ToUpper() == word.ToUpper())
            {
                Console.SetCursorPosition(0, 15);
                gameOver = true;
            }
            if (count > 6)
            {
                gameOver = true;
            }
            return gameOver;
        }
    }
}
