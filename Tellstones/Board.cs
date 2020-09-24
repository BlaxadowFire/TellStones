using System;
using System.Linq;

namespace Tellstones
{
    public class Board
    {
        public Board()
        {
            InitializeBoard();
        }

        /// <summary>
        /// Draws the entire playingfield to the sreen.
        /// </summary>
        public void Draw()
        {
            Console.Clear();
            DrawPlayerPoints(GetPlayerPoints());
            DrawCurrentPlayer();
            DrawLine(GenerateLine());
            DrawPool();
        }

        /// <summary>
        /// Sets a random stone in the center of the board.
        /// </summary>
        private void InitializeBoard()
        {
            Random random = new Random();
            var r = random.Next(0, Game.Instance.stones.Count);
            Stone stone = Game.Instance.stones.First(stone => stone.Id == r);
            stone.BoardPosition = (int)Math.Ceiling((decimal)Game.Instance.stones.Count/2);
        }

        /// <summary>
        /// Generates the formatted Line.
        /// </summary>
        /// <returns>A string containing the Line</returns>
        private string GenerateLine()
        {
            string bar = "";
            string top = "╔";
            string s1 = "║";
            string s2 = "║";
            string s3 = "║";
            string bottom = "╚";

            //stones.Count+1 because you're skipping i = 0, this is because 0 is reserved for the pool.
            for (int i = 1; i < Game.Instance.stones.Count + 1; i++)
            {
                Stone stone = Game.Instance.stones.FirstOrDefault(stone => stone.BoardPosition == i);
                if (stone == null)
                {
                    s1 += "    ";
                    s2 += "    ";
                    s3 += "    ";
                }
                else if (stone.FaceUp)
                {
                    bar = "";
                    foreach (var character in stone.Name)
                        bar += "═";

                    s1 += $"╔{bar}╗";
                    s2 += $"║{stone.Name}║";
                    s3 += $"╚{bar}╝";
                }
                else
                {
                    s1 += "╔═╗";
                    s2 += "║ ║";
                    s3 += "╚═╝";
                }
            }

            bar = "";
            foreach (var character in s2)
                bar += "═";
            top += bar;
            bottom += bar;
            top = top.Remove(top.Length - 1);
            bottom = bottom.Remove(bottom.Length - 1);

            top += "╗";
            s1 += "║";
            s2 += "║";
            s3 += "║";
            bottom += "╝";
            return($"{top}\n{s1}\n{s2}\n{s3}\n{bottom}");
        }


        /// <summary>
        /// Writes the Line to the screen.
        /// </summary>
        private void DrawLine(string Line)
        {
            Console.WriteLine(Line);
        }

        //TODO
        /// <summary>
        /// Writes the Pool to the screen.
        /// </summary>
        private void DrawPool()
        {
            Console.WriteLine("\nPool:");
            foreach (Stone stone in Stone.GetStonesFromPool())
                Console.WriteLine(stone.Name);
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DrawCurrentPlayer()
        {
            Console.WriteLine($"Current player: {Game.Instance.Player}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        private void DrawPlayerPoints(int[] points)
        {
            Console.WriteLine($"Player 1: {points[0]}");
            Console.WriteLine($"Player 2: {points[1]}");
        }

        /// <summary>
        /// Gets the point of both players based on the value of the Point variable in Game.
        /// </summary>
        /// <returns>An array of points for player 1 and player 2.</returns>
        private int[] GetPlayerPoints()
        {
            int[] points = new int[2];

            if (Game.Instance.Points == 0)
            {
                points[0] = (Game.Instance.MaxPoints - 1) / 2;
                points[1] = (Game.Instance.MaxPoints - 1) / 2;
            }
            else if (Game.Instance.Points > 0)
            {
                points[0] = (Game.Instance.MaxPoints - 1) / 2 + Game.Instance.Points;
                points[1] = (Game.Instance.MaxPoints - 1) - ((Game.Instance.MaxPoints - 1) / 2 + Game.Instance.Points);
            }
            else
            {
                points[0] = (Game.Instance.MaxPoints - 1) - ((Game.Instance.MaxPoints - 1) / 2 - Game.Instance.Points);
                points[1] = (Game.Instance.MaxPoints - 1) / 2 - Game.Instance.Points;
            }
            return points;
        }
    }
}
