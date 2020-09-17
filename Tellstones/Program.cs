using System;

namespace Tellstones
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = Game.Instance;
            while(true)
            {
                game.Initialize();
                game.StartGame();
            }
        }
        private static void ClearConsoleFromCursorPosition()
        {
            int top = Console.CursorTop;
            Console.SetCursorPosition(0, top);
            for (int i = top; i < Console.WindowHeight; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, top);
        }
        public static void SetCursorPositionAndClearAfter(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            ClearConsoleFromCursorPosition();
        }

        //TODO:
        // Stone.GetStoneFromList should be handled in InputHandler
        // Stone.DrawStones and Board.DrawPool are very similar
        // ActionHandler.DrawActions and ExecuteAction should work with an enum of the actions.
        // ActionHandler.GetPositionForPlaceAction() should use identifiers for arrow keys as well as use those, or use enums instead of input ==1 and input == 2.
        // ActionHandler should be singleton to avoid using many static functions.
        // If Stones.GetStonesFromPool().Count == 0, disable Action.Instance.Place().
        // Stone should get a function that returns all the stones that are in the Line (or not in the pool). (See InputHandler.ExecuteAction() case 2.
        // Action.Instance.Peek() should not show visible stones
        // All readkeys should allow Escape to return to the previous option.
        // All unavailable actions should not be shown in the menu.
        // Action.Instance.Hide() Should not show the already hidden stones.
        // Action.Instance.Swap() Should hide or highlight the already selected stone when selecting the second stone.
        // Action.Instance.Boast() Should give players maximum points.
        // Action.Instance.Boast() Should be tested.
    }
}
