using System;
using System.Linq;

namespace Oops
{
	public class ParseUtil
	{
		private readonly string[] tokenArray;
		private int index;
		public ParseUtil(string raw) {
            tokenArray = GetTokenArray(raw);
			index = 0;
		}

		public string ReadToken() {
			if (index < tokenArray.Length) {
				var token = tokenArray[index];
				index++;
				return token;
			} else {
				throw new InvalidOperationException("umm..wrong syntax..");
			}
		}

		public bool EndOfLine {
			get{
				return index == tokenArray.Length;
			}
		}

		// alright, it's not beautiful...
		public static bool IsConvertion(string raw) {
			return GetTokenArray(raw).Any(t => t == "=");
		}

		public static bool IsExpression(string raw){
			return !IsConvertion(raw);
		}

		private static string[] GetTokenArray(string raw){
			return raw.Trim().Split(' ');
		}
	}
}

