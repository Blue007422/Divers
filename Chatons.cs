using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
 * Read input from Console
 * Use: Console.WriteLine to output your result to STDOUT.
 * Use: Console.Error.WriteLine to output debugging information to STDERR;
 *       
 * ***/

namespace CSharpContestProject
{
	class Program
	{
	    
	    static int match = -1;
	    static List<char> team;
	    
		static void Main(string[] args)
		{   
		    List<char> chatons = new List<char>();

		    int teamSize = int.Parse(Console.ReadLine());
		    chatons.AddRange(Console.ReadLine());
		    int enemySize = int.Parse(Console.ReadLine());
		    char[] enemyChatons = Console.ReadLine().ToCharArray();
		    
            Try(chatons, enemyChatons, new List<char>());
            
            if(match == 0)
            {
                string s = new string(team.ToArray());
                Console.WriteLine("=" + s);
            }

            if(match == -1)
            {
                string s = new string(chatons.ToArray());
                Console.WriteLine("-" + s);
            }

            if(match == 1)
            {
                string s = new string(team.ToArray());
                Console.WriteLine("+" + s);
            }

		}


        static void Try(List<char> chatons, char[] enemyChatons, List<char> currentChatons)
        {
            
            if(chatons.Count > 0)
            {

                foreach(char c in chatons)
                {
                    List<char> newCurrentChatons = new List<char>(currentChatons);
                    List<char> newChatons = new List<char>(chatons);
                    
                    newCurrentChatons.Add(c);
                    newChatons.Remove(c);
                    Try(newChatons, enemyChatons, newCurrentChatons);
                    
                }

            }
            else
            {
                
                int a = Match(currentChatons, enemyChatons);
                
                if(a == 0 && match == -1)
                {
                    match = 0;
                    team = currentChatons;
                }
                else if(a == 1 && match <= 0)
                {
                    match = 1;
                    team = currentChatons;

                }                
            }
            
        }

        static int Match(List<char> chatons, char[] enemyChatons)
        {
            
            int i = 0;
            int j = 0;
            int maxI = chatons.Count;
            int maxJ = enemyChatons.Length;

            while(true)
            {
            
                if(i == maxI)
                {
                    if(j == maxJ)
                        return 0;
                        
                    return -1;
                }
                
                if(j == maxJ)
                {
                    return 1;
                }
     
                if(chatons[i] == enemyChatons[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    
                    if((chatons[i] == 'F' && enemyChatons[j] == 'E') || (chatons[i] == 'E' && enemyChatons[j] == 'P') || (chatons[i] == 'P' && enemyChatons[j] == 'F'))
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                    
                }
                
                
            }
            
            
            
        }

	}
	
}
