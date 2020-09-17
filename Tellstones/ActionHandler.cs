using System;
using System.Collections.Generic;
using System.Linq;

namespace Tellstones
{
    //TODO
    public class ActionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Handler()
        {
            DrawActions();
            do
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            while (!SelectAction());
        }

        //TODO
        /// <summary>
        /// 
        /// </summary>
        private static void DrawActions()
        {
            Console.WriteLine("Actions:\n1: Place\n2: Hide\n3: Swap\n4: Peek\n5: Challenge\n6: Boast\n");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool SelectAction()
        {
            var input = Console.ReadKey();
            Console.WriteLine();
            return ExecuteAction(input);
        }
        //TODO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cki"></param>
        /// <returns></returns>
        private static bool ExecuteAction(ConsoleKeyInfo cki)
        {
            if (!int.TryParse(cki.KeyChar.ToString(), out var input) || input < 1 || input > 6)
                return false;
            Stone stone = null;
            List<Stone> stones = Game.Instance.stones.Where(stone => stone.BoardPosition != 0).ToList().OrderBy(stone => stone.BoardPosition).ToList();
            CustomConsole.SetCursorPositionAndClearAfter(Console.CursorLeft, Console.CursorTop - 8);
            switch (input)
            {
                case 1:
                    Console.WriteLine("Action: Place");
                    stone = Stone.PickFromPool();
                    int position;
                    do
                    {
                        CustomConsole.SetCursorPositionAndClearAfter(Console.CursorLeft, Console.CursorTop - (Stone.GetStonesFromPool().Count + 1));
                        position = GetPositionForPlaceAction();
                        CustomConsole.SetCursorPositionAndClearAfter(Console.CursorLeft, Console.CursorTop - 4);
                    }
                    while (position == -1);
                    Action.Instance.Place(stone, position);
                    break;
                case 2:
                    Console.WriteLine("Action: Hide");
                    Stone.DrawStones(stones);
                    stone = Stone.GetStoneFromList(stones);
                    Action.Instance.Hide(stone);
                    break;
                case 3:
                    Console.WriteLine("Action: Swap");
                    Stone[] swapStones = new Stone[2];
                    for (int i = 0; i < swapStones.Length; i++)
                    {
                        Stone.DrawStones(stones);
                        swapStones[i] = Stone.GetStoneFromList(stones);
                        CustomConsole.SetCursorPositionAndClearAfter(Console.CursorLeft, Console.CursorTop - 4);
                    }
                    Action.Instance.Swap(swapStones);
                    break;
                case 4:
                    Console.WriteLine("Action: Peek");
                    Stone.DrawStones(stones);
                    stone = Stone.GetStoneFromList(stones);
                    Action.Instance.Peek(stone);
                    break;
                case 5:
                    Console.WriteLine("Action: Challenge");
                    Stone.DrawStones(stones);
                    stone = Stone.GetStoneFromList(stones);
                    Action.Instance.Challenge(stone);
                    break;
                case 6:
                    Console.WriteLine("Action: Boast");
                    Action.Instance.Boast();
                    break;
                default:
                    return false;
            }
            return true;
        }

        //TODO
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int GetPositionForPlaceAction()
        {
            IList<Stone> OrderedStones = Game.Instance.stones.Where(stone => stone.BoardPosition != 0).OrderBy(stone => stone.BoardPosition).ToList();

            if (OrderedStones.First().BoardPosition == 1)
                return OrderedStones.Last().BoardPosition + 1;
            else if (OrderedStones.Last().BoardPosition == Game.Instance.stones.Count)
                return OrderedStones.First().BoardPosition - 1;

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine("Left or right?\n1: Left\n2: Right");

            int.TryParse(Console.ReadKey().KeyChar.ToString(), out int input);
            Console.WriteLine();
            if (input == 1)
                return OrderedStones.First().BoardPosition - 1;
            else if (input == 2)
                return OrderedStones.Last().BoardPosition + 1;
            else
                return -1;
        }
    }
}
