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
string vowels = "aeiouyAEIOUY";

for (int i = 0; i < words.Length; i++)
{
    string pigLatin = words[i];

    if (vowels.Contains(pigLatin[0])) //checks if a word starts with a vowel
    {
        words[i] = pigLatin + "way";
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
Console.WriteLine(pigLatinPhrase);

/*Create a random number for an offset*/
Random rand = new Random();
int randomOffset = rand.Next(1,26);
