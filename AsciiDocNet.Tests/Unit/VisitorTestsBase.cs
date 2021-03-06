using System.IO;
using System.Text;

namespace AsciiDocNet.Tests.Unit
{
	public abstract class VisitorTestsBase
	{
		public VisitorTestsBase()
		{
			Builder = new StringBuilder();
			Visitor = new AsciiDocVisitor(new StringWriter(Builder));
		}

		public AsciiDocVisitor Visitor { get; private set; }

		public StringBuilder Builder { get; private set; }
	}
}