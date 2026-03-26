using System.Drawing;

namespace Wordle
{
    public class Setting : ISetting
    {
        public int y { get; set; } = 0;
        public List<char> alphabet2 { get; set; } = new List<char>();
        public char[] board { get; set; } = new char[] { ' ', ' ', ' ', ' ', ' ' };
        public string alphabet { get; set; } = "abcdefghijklmnopqrstuvwxyz";
        public string[] words { get; set; } = { "Hello", "Eagle", "House", "Storm", "Louse", "Alien", "Avoid", "Alone", "Armor", "Agate", "Again", "Agree", "Acute", "Angle", "Basis", "Break", "Brain", "Cycle", "Crash", "Cross", "Death", "Draft", "Diner", "Earth", "Excel", "Enter", "Fruit", "Glass", "Greet", "Honor", "Harry", "Issue", "Irony", "Imago", "Joint", "Japan", "Kitty", "Karma" };
        public string Answer { get; set; } = string.Empty;
        public char[] answer { get; set; } = new char[5];
        public int count { get; set; }
        public bool gameOver { get; set; } = false;
        public ConsoleKeyInfo input { get; set; }
        public string word { get; set; } = string.Empty;
        public void CheckInput()
        {
            for (int i = 0; i < answer.Length; i++)
            {
                char currentAnswer = char.ToUpper(answer[i]);
                char currentWord = char.ToUpper(word[i]);
                int countW = word.Count(x => char.ToUpper(x) == char.ToUpper(word[i]));
                int countA = answer.Count(x => char.ToUpper(x) == currentAnswer);
                if (currentAnswer == currentWord && countW > countA)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (currentAnswer == currentWord)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (word.ToUpper().Contains(currentAnswer))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    alphabet2.Add(answer[i]);
                }
                Console.SetCursorPosition(i * 5, y);
                SetCursorDraw(new Point(d.X + 5 * i, d.Y + y), $"[ {char.ToUpper(answer[i])} ]");
                Console.ResetColor();
            }
        }
        public void Draw(int i)
        {
            d = new System.Drawing.Point(30, 5);
            DrawFrame(new System.Drawing.Point(28, 4), new System.Drawing.Size(28, 7));
            for (int j = 0; j < board.Length; j++)
            {
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                SetCursorDraw(new Point(d.X + 5 * j, d.Y + y), $"[ {board[j]} ]");
                Console.ResetColor();

            }
            h = new System.Drawing.Point(60, 5);
            int count = 0;
            int currentX = h.X;
            int currentY = 5;
            SetCursorDraw(new Point(58, 3), "History:");
            SetCursorDraw(new Point(29, 3), $"{DateTime.Now: hh:mm:ss}");
            DrawFrame(new Point(57, 2), new Size(26, 2));
            DrawFrame(new Point(28, 2), new Size(28, 2));
            DrawFrame(new System.Drawing.Point(57, 4), new System.Drawing.Size(26, 5)); // History
            DrawFrame(new System.Drawing.Point(57, 9), new Size(26, 2));
            SetCursorDraw(new Point(57, 4), FrameFrame); // History
            SetCursorDraw(new Point(83, 4), FrameFrame2); // History
            SetCursorDraw(new Point(57, 9), FrameFrame); 
            SetCursorDraw(new Point(83, 9), FrameFrame2);
            SetCursorDraw(new Point(28, 4), FrameFrame); // DateTime
            SetCursorDraw(new Point(56, 4), FrameFrame2); // DateTime
            for (int r = 0; r < alphabet.Length; r++)
            {
                if (count == 7)
                {
                    currentY++;
                    currentX = h.X;
                    count = 0;
                }
                if (alphabet2.Contains(alphabet[r]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                    Console.ForegroundColor = ConsoleColor.White;
                SetCursorDraw(new Point(currentX, currentY), $"{char.ToUpper(alphabet[r])}");
                currentX += 3;
                count++;
                Console.ResetColor();
            }
        }


        const string FrameTopLeft = "╔";
        const string FrameTopRight = "╗";
        const string FrameBottomLeft = "╚";
        const string FrameBottomRight = "╝";
        const string FrameFrame = "╠";
        const string FrameFrame2 = "╣";
        const string FrameRow = "═";
        const string FrameCol = "║";
        public Point d { get; set; } = new Point(0, 0);
        public Point h { get; set; } = new Point(0, 0);
        public void SetCursorDraw(Point l, string c)
        {
            try
            {
                int needWidth = l.X + c.Length;
                if (Console.BufferWidth < needWidth)
                    Console.SetBufferSize(Math.Max(Console.BufferWidth, needWidth), Console.BufferHeight);
                if (Console.BufferHeight < l.Y)
                    Console.SetBufferSize(Console.BufferWidth, Math.Max(Console.BufferHeight, l.Y + 1));
                Console.SetCursorPosition(l.X, l.Y);
                Console.Write(c);
            }
            catch { }
        }

        public void DrawFrame(Point l, Size s)
        {
            SetCursorDraw(l, FrameTopLeft);
            SetCursorDraw(new Point(l.X + s.Width, l.Y), FrameTopRight);
            SetCursorDraw(new Point(l.X, l.Y + s.Height), FrameBottomLeft);
            SetCursorDraw(new Point(l.X + s.Width, l.Y + s.Height), FrameBottomRight);

            string line = new(Convert.ToChar(FrameRow), s.Width - 1);
            SetCursorDraw(new Point(l.X + 1, l.Y), line);
            SetCursorDraw(new Point(l.X + 1, l.Y + s.Height), line);

            for (int i = l.Y + 1; i < l.Y + s.Height; i++)
            {
                SetCursorDraw(new Point(l.X, i), FrameCol);
                SetCursorDraw(new Point(l.X + s.Width, i), FrameCol);
            }
        }
    }
}
