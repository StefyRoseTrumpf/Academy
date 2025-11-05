// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program prompts the user to guess the system generated number between 1 to 100.
// ------------------------------------------------------------------------------------------------
using static System.Console;

int num = new Random ().Next (1, 101);
bool found = false;
while (!found) {
   Write ("Guess a number between 1 to 100: ");
   if (!int.TryParse (ReadLine (), out int guess)) {
      WriteLine ("Invalid input. Please enter a valid number."); continue;
   }
   found = num == guess;
   WriteLine ($"Your guess is {(found ? "correct!" : (num > guess ? "low" : "high"))}");
}