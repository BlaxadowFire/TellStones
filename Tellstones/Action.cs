using System;
using System.Linq;

namespace Tellstones
{
    public class Action
    {
        //Variables
        #region Variables
        //Private variables
        private static readonly object padlock = new object();
        private static Action _instance = null;
        #endregion

        //SingletonInstanceCreation
        #region SingletonInstanceCreation
        private Action()
        {

        }
        public static Action Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new Action();
                    return _instance;
                }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stone"></param>
        /// <param name="position"></param>
        public void Place(Stone stone, int position)
        {
            stone.BoardPosition = position;
        }

        //TODO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stone"></param>
        public void Hide(Stone stone)
        {
            stone.FaceUp = false;
        }
        
        //TODO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stones"></param>
        public void Swap(Stone[] stones)
        {
            // Code to swap 'x' and 'y' 
            stones[0].BoardPosition = stones[0].BoardPosition + stones[1].BoardPosition; //x = x + y; // x now becomes 15 
            stones[1].BoardPosition = stones[0].BoardPosition - stones[1].BoardPosition; //y = x - y; // y becomes 10 
            stones[0].BoardPosition = stones[0].BoardPosition - stones[1].BoardPosition; //x = x - y; // x becomes 5 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stone"></param>
        public void Peek(Stone stone)
        {
            Console.WriteLine(stone.Name);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stone"></param>
        public void Challenge(Stone stone)
        {
            Console.WriteLine("Select the name of the selected stone.");
            Stone.DrawStones(Game.Instance.stones, false);
            var input = Console.ReadKey();

            //Gives or takes a point to the opposite player.
            if (stone.Name == Game.Instance.stones.First(stone => stone.Id == int.Parse(input.KeyChar.ToString())-1).Name)
            {
                Console.WriteLine("Correct");
                if (Game.Instance.Player == 1)
                    Game.Instance.Points -= 1;
                else
                    Game.Instance.Points += 1;
            }
            else
            {
                Console.WriteLine("Incorrect");
                if (Game.Instance.Player == 1)
                    Game.Instance.Points += 1;
                else
                    Game.Instance.Points -= 1;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        //TODO
        /// <summary>
        /// 
        /// </summary>
        public void Boast()
        {
            Game.Instance.stones.ForEach(stone => Console.WriteLine($"{stone.Id}: {stone.Name}"));
            foreach (Stone stone in Game.Instance.stones.Where(Stone => Stone.BoardPosition != 0).OrderBy(stone => stone.BoardPosition))
            {
                var input = Console.ReadKey();
                if (stone.Name == Game.Instance.stones.First(stone => stone.Id == int.Parse(input.KeyChar.ToString())).Name)
                    Console.WriteLine("Correct");
                else
                    Console.WriteLine("Incorrect");
            }
        }
    }
}
