using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Wordle
{
    public class GameEngine
    {
        private readonly ISetting setting;
        private readonly IRandom random;

        public GameEngine(ISetting setting, IRandom random)
        {
            this.setting = setting;
            this.random = random;
        }
        public void Game()
        {
            random.RandomWord(this.setting);
            setting.y = 0;
            int i = 0;
            while (!setting.gameOver)
            {
                while (!Equals(i, 6))
                {
                    Console.SetCursorPosition(0, setting.y);
                    setting.Draw(i);
                    setting.input = Console.ReadKey(true);
                    if (setting.input.Key == ConsoleKey.Backspace)
                    {
                        if (i > 0)
                        { 
                            setting.board[i] = ' ';
                            setting.answer[i] = '\0';
                        }
                    }
                    else if (setting.input.Key == ConsoleKey.Enter)
                    {
                        if (!setting.board.Contains(' '))
                        {
                            setting.CheckInput();
                            setting.Answer = new string(setting.answer);
                            setting.GameOver();
                            setting.count++;
                            Console.WriteLine();
                            if (setting.count == 6 && !setting.gameOver)
                            {
                                setting.SetCursorDraw(new Point(58, 12), "You`ve lost");
                                var result = string.Concat(setting.word.Select(x => $"[ {char.ToUpper(x)} ]").ToArray());
                                setting.SetCursorDraw(new Point(58, 10), result);
                                Console.SetCursorPosition(0, 15);
                                setting.gameOver = true;
                            }
                            Array.Fill(setting.board, ' ');
                            setting.y++;
                            i = 0;
                            break;
                        }
                    }
                    else if (char.IsLetter(setting.input.KeyChar) && i < setting.board.Length)
                    {
                        setting.answer[i] = setting.input.KeyChar;
                        setting.board[i] = char.ToUpper(setting.answer[i]);
                        if (i < 4)
                            i++;
                    }
                    else if (setting.input.Key == ConsoleKey.LeftArrow)
                    {
                        if (i > 0)
                        {
                            i--;
                        }
                    }
                    else if (setting.input.Key == ConsoleKey.RightArrow)
                    {
                        if (i < setting.board.Length - 1)
                        {
                            i++;
                        }
                    }
                }
            }
        }
    }
}
