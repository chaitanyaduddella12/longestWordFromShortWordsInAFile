namespace trieADT
{
	public class Trie
	{
		private Node _head;

		public Trie()
		{
			_head = new Node('#'); // Root indicated by Hash
		}

		// Function to insert the word in a Trie
		public virtual void Insertword(string str)
		{
			Node currentNode = _head;
			if (str.Length == 0) // For string which is empty
			{
				currentNode.endofword = true;
			}
			//Loop over the length of string
			for (int i = 0; i < str.Length; i++)
			{
				Node child = currentNode.substituteNode(str[i]);
				// if character already present just increment its prefix 
				if (child != null)
				{
					currentNode = child;
					currentNode.Prefix++;
				}
				else
				{ // if character not present add a new character node
					currentNode.Nodechild.Add(new Node(str[i]));
					currentNode = currentNode.substituteNode(str[i]);
				}
				// Set marker to indicate end of the word
				if (i == str.Length - 1)
				{
					currentNode.endofword = true;
				}
			}
		}

		public virtual bool searchword(string str)
		{
			Node currentNode = _head;
			while (currentNode != null)
			{
				//Loop over the length of string
				for (int i = 0; i < str.Length; i++)
				{
					if (currentNode.substituteNode(str[i]) == null)
					{
						return false;
					}
					else
					{
						currentNode = currentNode.substituteNode(str[i]);
					}
				}

				// It means that string is in the Trie but is it really a word?
				if (currentNode.endofword == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		public virtual bool deleteword(string str)
		{
			if (searchword(str)) // Check for string is already present, if not it cannot be deleted
			{
				Node currentNode = _head;
				Node temporary; // To keep track of parent
				while (currentNode != null)
				{
					//Loop over the length of string
					for (int i = 0; i < str.Length; i++)
					{
						temporary = currentNode;
						
						currentNode = currentNode.substituteNode(str[i]);
						
						currentNode.Prefix--;
						if (currentNode.Prefix == 0)
						{
							temporary.Nodechild.Remove(currentNode);
							break;
						}
					}
					// removes the endofword to indicate the word removal
					currentNode.endofword= false;
					return true;
				}
			}
			return false;
		}
	}

}