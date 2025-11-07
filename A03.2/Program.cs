// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program returns possible number of words formed from the given seven letters and it's score.
// ------------------------------------------------------------------------------------------------
using static System.Console;

string[] words = File.ReadAllLines ("C:\\Users\\regisam\\Downloads\\words.txt");
char[] letters = GetInput ();
var sortedWords = WordFinder (words, letters)
   .Select (w => new { Word = w, Score = ScoreFinder (w, letters) })
   .OrderByDescending (w => w.Score)
   .ThenBy (w => w.Word);
int totalScore = sortedWords.Sum (w => w.Score);
foreach (var word in sortedWords) {
   bool isPangram = letters.All (word.Word.Contains);
   if (isPangram) ForegroundColor = ConsoleColor.Green;
   WriteLine ($"{word.Score,2}. {word.Word}");
   ResetColor ();
}
WriteLine ($"----\n{totalScore} total");

//Get user input
static char[] GetInput () {
   while (true) {
      Write ("Enter 7 letters: ");
      var input = (ReadLine () ?? "").Trim ().ToUpper ();
      WriteLine ();
      if (input.Length != 7 || input.Any (c => !char.IsLetter (c))) {
         WriteLine ("Invalid Input. Enter exactly 7 letters.");
         continue;
      }
      return input.ToCharArray ();
   }
}

// Allocating scores to the words
static int ScoreFinder (string word, char[] letters) {
   int score = word.Length == 4 ? 1 : word.Length;
   bool hasAll = true;
   foreach (char c in letters) {
      if (!word.Contains (c)) {
         hasAll = false;
         break;
      }
   }
   if (hasAll) score += 7;
   return score;
}

//Find all valid words formed using given letters from the word list
static string[] WordFinder (string[] words, char[] letters) {
   List<string> result = [];
   foreach (string word in words) {
      if ((word.Length < 4) || (!word.Contains (letters[0]))) continue;
      bool valid = true;
      foreach (char c in word) {
         if (!letters.Contains (c)) {
            valid = false;
            break;
         }
      }
      if (valid) result.Add (word);
   }
   return [.. result];
}