# longestWordFromShortWordsInAFile
This project has C# code to find the longest word, concatenated from short words from the input file.
Environment Used: Visual Studio 2017
Concepts Used: C# .NET( LINQ, TRIE, NODE)
For example, if the file contained:

       cat
       cats
       catsdogcats
       catxdogcatsrat
       dog
       dogcatsdog
       hippopotamuses
       rat
       ratcatdogcat

The answer would be 'ratcatdogcat' - at 12 letters, it is the longest word made up of other words in the list.The program should then go on to report how many of the words in the list can be constructed of other words in the list.

How to run?
1) Include LongestWord.cs, Trie.cs, Node.cs in your project
2)Include text files New Test 00.txt , Nettest.txt files by right clicking on the project-> Add Existing item and select the input text files 
4)Build it.
3)By clicking the start we can see the output(Run it).

Output will give the details of total number of words in a file, Longestword found in a file that can be constructed by concatenation of short words which are also in the same file and length of the word, the second largest word found in a file with its length.


Decisions made:
1) Problem can be solved using a "Trie data structure"
2) Read the input file, add those words to newly created list, apply LINQ sort in descending order.
3) Start with the first string and loop over sorted strings
4) Check if it can be made of other words by dividing strings into all possible combinations and doing same thing for each splits.
5) Return true if it is made of other strings and Save that string onto an array list.
6) Return the top string because that would be the longest string.
7) The size of array list will give you the total number of words that can be made of other words.
