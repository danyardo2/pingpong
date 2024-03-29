﻿using Common.IO.Abstractions;

namespace Common.IO.Input
{
    public class NumberConsoleInput : IInput<string>
    {
        public string GetInput()
        {
            int parsedInt;
            string numberInput = Console.ReadLine();
            while (!int.TryParse(numberInput, out parsedInt))
            {
                numberInput = Console.ReadLine();
            }
            return numberInput;
        }
    }
}
