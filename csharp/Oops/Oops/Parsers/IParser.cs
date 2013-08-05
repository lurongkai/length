using System;

namespace Oops
{
	public interface IParser
	{
		Convertion ParseConvertion(string convertionRaw);
		Expression ParseExpression(string expressionRaw);
	}
}

