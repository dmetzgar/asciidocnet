﻿using System;
using System.Collections.Generic;

namespace AsciiDocNet
{
	public class RoleAttribute : NamedAttribute
	{
		public RoleAttribute(string value, bool singleQuoted) : base("role", value, singleQuoted)
		{
		}

		public RoleAttribute(IEnumerable<string> values, bool singleQuoted) : this(string.Join(",", values), singleQuoted)
		{
		}

		public string[] Values
		{
			get { return Value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
			set { Value = string.Join(",", value); }
		}
	}
}