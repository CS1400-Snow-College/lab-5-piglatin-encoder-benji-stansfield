/*Benji Stansfield, 02-24-25, Lab 5 "Pig Latin + Encoder*/

using System.Globalization;

Console.Clear();

/*Creating the greeting*/
Console.WriteLine("Let's manipulate your phrase into pig latin and encode it!");

/*Getting message from user*/
Console.Write("Please enter your message: ");

string userPhrase = Console.ReadLine();
string[] words = userPhrase.Split(" "); //splits the user's phrase into an array of words

/*Convert to Pig Latin*/
string vowels = "aeiouAEIOU";

for (int i = 0; i < words.Length; i++)
{
    string pigLatin = words[i];

    if (vowels.Contains(pigLatin[0])) //checks if a word starts with a vowel
    {
        words[i] = pigLatin + "way"; //adds "way to the end of the word
    }
    else
    {
        int vowelIndex = -1; //basically means that no vowel has been found yet
        for (int j = 0; j < pigLatin.Length; j++)
        {
            if (vowels.Contains(pigLatin[j])) //loops through each word letter by letter
            {
                vowelIndex = j; //stores the index of the vowel into vowelIndex
                break;
            }
        }

        if (vowelIndex > 0) //if the vowel is found after the first letter
        {
            words[i] = pigLatin.Substring(vowelIndex) + pigLatin.Substring(0, vowelIndex).ToLower() + "ay"; //moves everything before the vowel to the end and adds "ay"
        }
        else
        {
            words[i] = pigLatin + "ay"; //add "ay" to word if no vowel is found
        }
    }
}

/*Join the words together and write the phrase*/
string pigLatinPhrase = string.Join(" ", words);
Console.WriteLine($"Pig Latin phrase: {pigLatinPhrase}");

/*Create a random number for an offset*/
Random rand = new Random();
int randomOffset = rand.Next(1,26);

/*Encoding the phrase with the offset number*/
string[] codedWords = userPhrase.Split(" ");

for (int i = 0; i < codedWords.Length; i++)
{
    char[] letters = codedWords[i].ToCharArray(); //turns the string into an array of chars

    for (int j = 0; j < letters.Length; j++)
    {
        char letter = letters[j]; //stores each letter in 'letter'

        if (char.IsLetter(letter)) //only encodes letters
        {
            char baseChar = char.IsUpper(letter) ? 'A' : 'a'; //looks to see if the character is upper or lowercase
            letters[j] = (char)(baseChar + (letter - baseChar + randomOffset) % 26); //offsets the letter, subtracts the original letter (I had help online with this because I could not figure it out)
        }
    }
    codedWords[i] = new string(letters); //puts the letters back into a string
}

/*Join the words together and write the encoded phrase*/
string encodedPhrase = string.Join(" ", codedWords);
Console.WriteLine($"Encoded message: {encodedPhrase}");
