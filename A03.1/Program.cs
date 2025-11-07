// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program guesses the number thought by the user by prompting seven questions.
// ------------------------------------------------------------------------------------------------
using static System.Console;

GetBinaryNum ("Think of a number between 1 to 127 and I will guess it.");

// Prompts the user with 7 Y/N questions and returns the number thought by the user
static int GetBinaryNum (string prompt) {
   WriteLine (prompt);
   int sum = 0, baseVal = 2, rem = 1;
   for (int i = 0; i < 7; i++) {
      ConsoleKeyInfo key;
      do {
         Write ($"If the number is divided by {baseVal}, is the remainder less than {rem}? (Y/N): ");
         key = ReadKey ();
         WriteLine ();
         if (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N)
            WriteLine ("Invalid Input.Enter 'Y' or 'N' only.");
      } while (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N);
      sum |= (key.Key == ConsoleKey.Y ? 0 : 1) << i;
      baseVal *= 2;
      rem *= 2;
   }
   WriteLine ($"The number you thought is {sum}");
   return sum;
}