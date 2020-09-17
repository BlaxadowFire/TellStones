using System;
using System.Collections.Generic;

namespace Tellstones
{
    public class Game
    {
        //Variables
        #region Variables
        //Private variables
        private static readonly object padlock = new object();
        private static Game instance = null;
        private Board _board;

        //Public variables
        public int Player;
        public int Points; //First player to Maxpoints wins (+MaxPoints or -MaxPoints)
        public int MaxPoints;
        public List<Stone> stones;
        #endregion

        //SingletonInstanceCreation
        #region SingletonInstanceCreation
        private Game()
        {
            
        }
        public static Game Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new Game();
                    return instance;
                }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            Player = 1;
            Points = 0;
            MaxPoints = 3;
            InitializeStones();
            _board = new Board();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartGame()
        {
            GameLoop();            
        }

        /// <summary>
        /// 
        /// </summary>
        private void GameLoop()
        {
            while (Points != MaxPoints - 1 && Points != 0 - (MaxPoints - 1))
            {
                _board.Draw();
                ActionHandler.Handler();
                SwitchPlayer();
            }
            Console.Write("The winner is: Player ");
            if (Points == MaxPoints - 1)
                Console.WriteLine("1");
            else
                Console.WriteLine("2");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Initializes the different stones.
        /// </summary>
        private void InitializeStones()
        {
            stones = new List<Stone>();
            instance.stones.Add(new Stone("sword"));
            instance.stones.Add(new Stone("shield"));
            instance.stones.Add(new Stone("knight"));
            instance.stones.Add(new Stone("crown"));
            instance.stones.Add(new Stone("hammer"));
            instance.stones.Add(new Stone("scales"));
            instance.stones.Add(new Stone("flag"));
        }

        /// <summary>
        /// 
        /// </summary>
        private void SwitchPlayer()
        {
            if (Player == 1)
                Player = 2;
            else
                Player = 1;
        }
    }
}
