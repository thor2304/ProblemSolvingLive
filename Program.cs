// Save secret word to guess
string secretWord = "viking";
int lives = 5;

char[] guessesChars = new char[secretWord.Length];
guessesChars = FillGuesses(guessesChars);

// Print secret word in secret form
PrintGuesses(guessesChars);

string unusedLetters = "abcdefghijklmnopqrstuvxyzæøå";
string wrongGuesses = "";


// Repeat
    // Until no lives left
    // Until entire word has been guessed
while (lives > 0 && WordHasNotBeenGuessed())
{
    RunRound();
}

// Tell the user if they won or lost
if (lives >0)
{
    Console.WriteLine("Congratulations you won!. The correct word was:");
    Console.WriteLine(secretWord);
}
else
{
    Console.WriteLine("You have no lives left. The correct word was:");
    Console.WriteLine(secretWord);
}

// Helpers
bool WordHasNotBeenGuessed()
{
    foreach (char guessChar in guessesChars)
    {
        if (guessChar == '_')
        {
            return true;
        }
    }

    return false;
}

void RunRound()
{
    Console.WriteLine();
    Console.WriteLine("Unused letters: " + unusedLetters);
    Console.WriteLine("Wrong guesses: " + wrongGuesses);
    Console.WriteLine("Remaining lives: " + lives);
    string userGuess = ReceiveGuess();

    unusedLetters = unusedLetters.Remove(unusedLetters.IndexOf(userGuess), 1);

    if (secretWord.Contains(userGuess))
    {
        // Correct guess
        char userGuessChar = userGuess[0];
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == userGuessChar)
            {
                guessesChars[i] = userGuessChar;
            }
        }
    }
    else
    {
        // Wrong guess
        wrongGuesses += userGuess;
        lives--;
    }
    
    PrintGuesses(guessesChars);
}

// Receive guess from user
string ReceiveGuess()
{
    // Print information to user
    Console.WriteLine("Place your guess: ");
    // Receive guess
    string userGuess = Console.ReadLine();
    // Check guess from user
        // Check length of guess
        if (userGuess.Length != 1)
    {
        Console.WriteLine("Your guess must only be 1 character");
        userGuess = ReceiveGuess();
    }

    // If the user typed an 'A' we want to treat it like 'a';
    userGuess = userGuess.ToLower();

    // Must not have already been used
    if (!unusedLetters.Contains(userGuess))
    {
        Console.WriteLine("You have already guessed that letter");
        userGuess = ReceiveGuess();
    }
    return userGuess;
}


void PrintGuesses(char[] guesses)
{
    for (int i = 0; i < guesses.Length; i++)
    {
        Console.Write(" " + guesses[i]);
    }
    Console.WriteLine();
}


char[] FillGuesses(char[] guesses)
{
    for (int i = 0; i < guesses.Length; i++)
    {
        guesses[i] = '_';
    }

    return guesses;
}