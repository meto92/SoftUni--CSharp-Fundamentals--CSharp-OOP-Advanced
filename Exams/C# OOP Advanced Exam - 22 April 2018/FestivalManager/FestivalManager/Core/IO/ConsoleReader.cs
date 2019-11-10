using System;

namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;

	public class ConsoleReader : IReader
	{
        public string ReadLine() => Console.ReadLine();
	}
}