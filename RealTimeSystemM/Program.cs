using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace RealTimeSystemM
{
	class Program
	{
		static void Main(string[] args)
		{
			long val = 95000000000;

			string name = "Maria";

			for (int i = 0; i < 10; i++)
			{
				int salt = 0;

				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();

				while (true)
				{
					var str = salt.ToString() + name;

					byte[] hash;
					using (SHA512 sHA512 = new SHA512Managed())
					{
						hash = sHA512.ComputeHash(Encoding.UTF8.GetBytes(str));
					}
					salt++;
					if (Math.Abs(BitConverter.ToInt64(hash)) < val)
						break;
				}

				stopwatch.Stop();
				Console.WriteLine($"{salt}{name} {stopwatch.ElapsedMilliseconds}");
			}
		}
	}
}
