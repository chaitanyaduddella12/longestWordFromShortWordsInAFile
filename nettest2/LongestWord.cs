using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trie = trieADT.Trie;


public class LongestWord
{

	private static Trie trieforlongestword = new Trie();

	public static void Main(string[] args)
	{
		System.IO.StreamReader br = null;
		try
		{
            IList<string> wordsarray = new List<string>();
            using (StreamReader sr = new StreamReader(@"C: \Users\Chaitanya Duddella\Documents\Visual Studio 2017\Projects\nettest2\nettest2\NET Test 00.txt"))
                
            //using (StreamReader sr = new StreamReader(@"C:\Users\Chaitanya Duddella\Documents\Visual Studio 2017\Projects\nettest2\nettest2\Nettest.txt"))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    wordsarray.Add(line);
                }
                Console.WriteLine("Total number of words in line :"+ wordsarray.Count());
            }
            string[] sortedwordsarray = null;
			string[] longestwordsinarray = null;
			// Convert array list to an array of string
			sortedwordsarray = wordsarray.ToArray();

            // Sort the words based on length
            sortedwordsarray = sortedwordsarray.OrderByDescending(a => a.Length).ToArray();
            //Array.Sort(sortedWords, (s1, s2) => s1.Length.CompareTo(s2.Length));

			// Populate trie ADT that we created
			foreach (string word in sortedwordsarray)
			{
				trieforlongestword.Insertword(word);
			}	

			// Find all the words made of other words
			longestwordsinarray = LongestWordsContainingOtherShortWords(sortedwordsarray);

			//Print the longest word and the number of words made of other words
			Console.WriteLine("Longest Word made of other words:   " + longestwordsinarray[0]);
            Console.WriteLine("Length of the Longest word that can be made:  " + longestwordsinarray[0].Length);
            Console.WriteLine("2nd Longest word found is:  " + longestwordsinarray[1]);
            Console.WriteLine("Length of 2nd longest word is:  " + longestwordsinarray[1].Length);
			Console.WriteLine("Total number of words that can be made of other words :   " + longestwordsinarray.Length);
            Console.ReadLine();
			
		}
		catch (FileNotFoundException)
		{
			// TODO Auto-generated catch block
			Console.WriteLine("Please enter a correct filename!");
		}
		catch (IOException e)
		{
			// TODO Auto-generated catch block
			Console.WriteLine(e.ToString());
			Console.Write(e.StackTrace);
		}
		finally
		{
			try
			{
				if (br != null)
				{
					br.Close();
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}
	}

	public static string[] LongestWordsContainingOtherShortWords(string[] list)
	{
		IList<string> List = new List<string>();
		foreach (string word in list)
		{
			if (Required(word,true))
			{
				List.Add(word);
			}
		}		
		 return List.ToArray();
	}

	public static bool Required(string word, bool fullword)
	{
		// Remove the word so that the word is not matched to itself to find the longest word
		if (fullword)
		{
			trieforlongestword.deleteword(word);
		}
		// Loop over the length of the word
		for (int i = 0;i < word.Length;i++)
		{
			
			if (trieforlongestword.searchword(word.Substring(0, i + 1)))
			{
				if (i + 1 == word.Length || Required(word.Substring(i + 1, word.Length - (i + 1)),false))
				{
					return true;
				}
			}
		}
		
		if (fullword)
		{
			trieforlongestword.Insertword(word);
		}
		return false;
	}
}
