using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	class Program
	{
		static void Main(string[] args)
		{
			//Aoc1(@"..\..\..\..\inputs\day1.txt");
			Aoc2(@"..\..\..\..\inputs\day2.txt");
		}

		private static void Aoc2(string path)
		{
			int validPasses = 0;
			using (StreamReader file = new StreamReader(path))
			{

				while (!file.EndOfStream)
				{
					var line = file.ReadLine();
					var xplode = line.Split(' ', '-', ':');

					int min = int.Parse(xplode[0]);
					int max = int.Parse(xplode[1]);
					string key = xplode[2];
					string pass = xplode[4];
					//part 1

					//var count = pass.Count(c => c == key[0]);

					//if (min <= count && count <= max)
					//	validPasses++;

					//part 2
					bool first = pass[min-1] == key[0];
					bool second = pass[max-1] == key[0];

					if (first != second)
						validPasses++;
				}
			}

			Console.WriteLine(validPasses);
			Console.ReadKey();
		}

		private static void Aoc1(string path)
		{
			int product = 0;
			int min = 0;
			int second = 0;

			List<int> expenses = new List<int>();
			using (StreamReader file = new StreamReader(path))
			{
				while (!file.EndOfStream)
				{
					var line = file.ReadLine();
					expenses.Add(int.Parse(line));
				}
			}

			//part1
			//foreach( int expense in expenses)
			//{
			//	int remainder = 2020 - expense;
			//	if (expenses.Contains(remainder))
			//	{
			//		product = expense * remainder;
			//		break;
			//	}
			//}

			//part2
			min = expenses.Min();
			int max = 2020 - (min * 2);
			foreach (int expense in expenses)
			{
				if (expense < max)
				{
					for (int i = 0; i < expenses.Count; i++)
					{
						second = expenses[i];
						int remainder = 2020 - expense - second;
						if (expenses.Contains(remainder))
						{
							product = expense * second * remainder;
							break;
						}
					}
				}
			}

			Console.WriteLine(product);
			Console.ReadKey();
		}


	}
}
