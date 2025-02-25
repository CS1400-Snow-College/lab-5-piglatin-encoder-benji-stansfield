/*Benji Stansfield, 02-24-25, Lab 5 "Pig Latin + Encoder*/

Console.Clear();

/*Creating the greeting*/
Console.WriteLine("Let's manipulate your phrase into pig latin and encode it!");

/*Getting message from user*/
Console.Write("Please enter your message: ");

string userPhrase = Console.ReadLine();
string[] words = userPhrase.Split(" "); //splits the user's phrase into an array of words
