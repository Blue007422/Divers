using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		int n = 10;
		
		float[,] array = new float[n,n];
		
		for(int i = 0; i < n; i++)
		{
			for(int j = 0; j< n; j++)
			{
				array[i,j] = float.MaxValue;
			}
		}
		
		/*
		0 => A
		1 => B
		2 => C
		3 => D
		4 => E
		5 => F
		6 => G
		7 => H
		8 => I
		9 => J*/
		array[0,1] = 85;	
		array[0,2] = 217;
		array[0,4] = 173;
		array[1,0] = 85;
		array[1,5] = 80;
		array[2,0] = 217;
		array[2,6] = 186;
		array[2,7] = 103;
		array[3,7] = 186;
		array[4,0] = 173;
		array[4,9] = 502;
		array[5,1] = 80;
		array[5,8] = 250;
		array[6,2] = 502;
		array[7,2] = 103;
		array[7,3] = 183;
		array[7,9] = 167;
		array[8,5] = 250;
		array[8,9] = 84;
		array[9,4] = 502;
		array[9,7] = 167;
		array[9,8] = 84;
		
		
		Djikstra(array, 0, 9);
	}
	
	private static float Djikstra(float[,] arr, int start, int end)
	{
		int n = arr.GetLength(0);
		float[] dij = new float[n];
		int[] fromDij = new int[n];
		List<int> dejaFait = new List<int>();
		float tempMin = float.MaxValue;
		int tempChoice = start;
		
		for(int i = 0; i < n; i++)
		{
			dij[i] = int.MaxValue;
		}
		
		dij[start] = 0;
		
		for(int i = 0; i < n; i++)
		{
			tempMin = float.MaxValue;
			
			// Search for the next Point
			foreach(int a in dejaFait)
			{
				for(int k = 0; k < n;k++)
				{
					if(!dejaFait.Contains(k) || arr[a,k] == int.MaxValue || dij[k] == int.MaxValue)
					{
						if(dij[a] + arr[a,k] < tempMin)
						{
							tempMin = dij[a] + arr[a,k];
							tempChoice = k;
						}	
					}
				}
				
			}
			
			dejaFait.Add(tempChoice);
			
			for(int j = 0; j < n; j++)
			{	
				if(tempChoice != j)
				{
					if(arr[tempChoice,j] + dij[tempChoice] < dij[j])
					{
						dij[j] = arr[tempChoice,j] + dij[tempChoice];
						fromDij[j] = tempChoice;
					}
				}
			}
			
			if(tempChoice == end)
			{
				break;
			}
			
		}
		
		
		/*
		If we need the origin
		for(int i =0; i<n;i++)
		{
			Console.WriteLine(fromDij[i]);
		}*/
		

		return dij[end];
	}


}
