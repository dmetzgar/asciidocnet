using System;
using System.Collections;
using System.Collections.Generic;

namespace AsciiDocNet.Tests.Unit
{
	public abstract class ClassDataBase<T> 
		where T : ReusableClassData, new()
	{
		public static IEnumerable<object[]> ClassData 
		{
			get 
			{
				return new T();
			}
		}
	}

    public abstract class ReusableClassData : IEnumerable<object[]>
	{
		protected abstract IEnumerable<object[]> Data { get; }

		public IEnumerator<object[]> GetEnumerator()
		{
			return Data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}