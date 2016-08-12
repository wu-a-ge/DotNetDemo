using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Cache;
using System.Diagnostics;

namespace ConsoleApplication1
{
	class Program
	{
		static readonly string Url_1 = "http://localhost:62162/Handler1.ashx?id={0}&aa={1}&bb={2}&cc={3}";
		static readonly string Url_2 = "http://localhost:62151/Home/hh/{0}/yy{1}/xx/{2}?aa={3}";
		static readonly string Url_3 = "http://localhost:62151/Page{0}/Test/{1}/p{2}/dd/{3}/tt{4}/cd{5}";

		static readonly Random Rand = new Random();

		static void Main(string[] args)
		{
			Prepare();

			int count = 10000;

			Test(1, count);
			Test(2, count);
			Test(3, count);
		}

		static string GetUrl(int index)
		{
			if( index == 1 )
				return string.Format(Url_1, Rand.Next(1, 100), Rand.Next(1, 10000), Rand.Next(1, 10000), Rand.Next(1, 10000));

			if( index == 2 )
				return string.Format(Url_2, Rand.Next(1, 100), Rand.Next(1, 10000), Rand.Next(1, 10000), Rand.Next(1, 10000));

			if( index == 3 )
				return string.Format(Url_3, Rand.Next(1, 100), Rand.Next(1, 10000), Rand.Next(1, 10000), Rand.Next(1, 10000), Rand.Next(1, 10000), Rand.Next(1, 10000));

			throw new NotImplementedException();
		}

		static void Prepare()
		{
			SendHttpRequest(GetUrl(1));
			SendHttpRequest(GetUrl(2));
			SendHttpRequest(GetUrl(3));
		}

		static void Test(int index, int count)
		{
			Stopwatch watch = Stopwatch.StartNew();

			for( int i = 0; i < count; i++ )
				SendHttpRequest(GetUrl(index));

			watch.Stop();

			Console.WriteLine();
			Console.WriteLine("Test " + index);

			string url = GetUrl(index);
			string result = SendHttpRequest(url);
			Console.WriteLine("{0} => {1}", url, result);

			Console.WriteLine(watch.Elapsed.ToString());
		}

		static string SendHttpRequest(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
			
			using( WebResponse response = request.GetResponse() ) {
				using( StreamReader reader = new StreamReader(response.GetResponseStream()) ) {
					return reader.ReadToEnd();
				}
			}
		}


	}
}
