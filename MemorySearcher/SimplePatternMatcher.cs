﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ReClassNET.MemorySearcher
{
	public partial class SimplePatternMatcher : IPatternMatcher
	{
		private readonly IMatchStrategy strategy;

		#region Construction

		public SimplePatternMatcher(byte[] pattern)
		{
			Contract.Requires(pattern != null);

			strategy = ChooseStrategy(pattern);
		}

		public SimplePatternMatcher(byte value)
			: this(new[] { value })
		{

		}

		public SimplePatternMatcher(short value)
			: this(BitConverter.GetBytes(value))
		{

		}

		public SimplePatternMatcher(ushort value)
			: this(BitConverter.GetBytes(value))
		{

		}

		public SimplePatternMatcher(int value)
			: this(BitConverter.GetBytes(value))
		{

		}

		public SimplePatternMatcher(uint value)
			: this(BitConverter.GetBytes(value))
		{

		}

		public SimplePatternMatcher(long value)
			: this(BitConverter.GetBytes(value))
		{

		}

		public SimplePatternMatcher(ulong value)
			: this(BitConverter.GetBytes(value))
		{

		}

		public SimplePatternMatcher(float value)
			: this(BitConverter.GetBytes(value))
		{

		}

		public SimplePatternMatcher(double value)
			: this(BitConverter.GetBytes(value))
		{

		}

		#endregion

		private static IMatchStrategy ChooseStrategy(byte[] pattern)
		{
			Contract.Requires(pattern != null);
			Contract.Ensures(Contract.Result<IMatchStrategy>() != null);

			if (pattern.Length <= 5)
			{
				return new NaiveMatchStrategy(pattern);
			}
			else
			{
				return new RabinKarpMatchStrategy(pattern);
			}
		}

		public IEnumerable<int> SearchMatches(IList<byte> data)
		{
			return SearchMatches(data, 0, data.Count);
		}

		public IEnumerable<int> SearchMatches(IList<byte> data, int index, int count)
		{
			return strategy.SearchMatches(data, index, count);
		}
	}
}
