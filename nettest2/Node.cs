using System.Collections.Generic;

namespace trieADT
{

	public class Node
	{
		internal char charinnode; // the character contained in that node
		internal bool endofword; // which marks the end of the word
		internal int Prefix; // Number of words having prefix as this character
		internal ICollection<Node> Nodechild; //The child node of given node

		// Constructor which creates a node
		public Node(char c)
		{
			Nodechild = new LinkedList<Node>();
			endofword = false;
			charinnode = c;
			Prefix = 1;
		}

		// substituteNode function returns the child node of a given node having character c
		public virtual Node substituteNode(char ch)
		{
			if (Nodechild != null)
			{
				foreach (Node childnode in Nodechild)
				{
					if (childnode.charinnode == ch)
					{
						return childnode;
					}
				}
			}
			return null;
		}

	}
}