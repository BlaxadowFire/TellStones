using System;

namespace Tellstones
{
    public static class CustomConsole
    {

        /// <summary>
        /// Clears the console from the current position of the cursor.
        /// </summary>
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

        /// <summary>
        /// Sets the cursor to a new position and clears the screan after that position.
        /// </summary>
        /// <param name="cursorLeft">The horizontal value of the cursor.</param>
        /// <param name="cursorTop">The vertical value of the cursor.</param>
        public static void SetCursorPositionAndClearAfter(int cursorLeft, int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            ClearConsoleFromCursorPosition();
        }
    }
}
