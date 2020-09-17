using System;
using System.Collections.Generic;
using System.Linq;

namespace Tellstones
{
    public class Stone
    {
        public Stone(string name)
        {
            Id = Game.Instance.stones.Count;
            Name = name;
            BoardPosition = 0;
            FaceUp = true;
        }
        public int Id { get; private set; }
        public string Name {get; private set;}
        public int BoardPosition {get; set;}
        public bool FaceUp { get; set; }

        public static Stone PickFromPool()
        {
            DrawStones(GetStonesFromPool());
            return GetStoneFromList(GetStonesFromPool());
        }

        //TODO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static Stone GetStoneFromList(IList<Stone> stones)
        {
            var input = Console.ReadKey();
            Console.WriteLine();
            if (!char.IsDigit(input.KeyChar))
                throw new Exception("Input is not a digit.");
            if (int.Parse(input.KeyChar.ToString()) < 1 || int.Parse(input.KeyChar.ToString()) > stones.Count)
                throw new Exception("Input is out of range.");
            return stones[int.Parse(input.KeyChar.ToString())-1];
        }

        //TODO
        public static void DrawStones(IList<Stone> stones)
        {
            IList<Stone> orderedStones = stones.OrderBy(stone => stone.BoardPosition).ToList();
            foreach (Stone stone in orderedStones)
            {
                if (stone.FaceUp)
                    Console.WriteLine($"{orderedStones.IndexOf(stone) + 1}: {stone.Name}");
                else
                    Console.WriteLine($"{orderedStones.IndexOf(stone) + 1}: ?");

            }
        }

        public static IList<Stone> GetStonesFromPool()
        {
            List<Stone> stones = new List<Stone>();
            foreach (Stone stone in Game.Instance.stones.Where(stone => stone.BoardPosition == 0))
                stones.Add(stone);
            return stones;
        }
    }
}
