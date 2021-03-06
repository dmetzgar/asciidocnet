using System.Linq;

namespace AsciiDocNet
{
	public class Mark : InlineContainer, IInlineElement, IAttributable
	{
		public Mark(string text, bool doubleDelimited = false)
		{
			Add(new TextLiteral(text));
			DoubleDelimited = doubleDelimited;
		}

		public Mark()
		{
		}

		public AttributeList Attributes { get; } = new AttributeList();

		public override InlineElementType ContainElementType { get; } =
			InlineElementType.Literal | InlineElementType.AttributeReference | InlineElementType.Emphasis | InlineElementType.EmphasisDouble |
			InlineElementType.ImplicitLink | InlineElementType.InlineAnchor | InlineElementType.InternalAnchor | InlineElementType.Monospace |
			InlineElementType.MonospaceDouble | InlineElementType.Strong |
			InlineElementType.StrongDouble | InlineElementType.Subscript | InlineElementType.Superscript;

		public bool DoubleDelimited { get; set; }

		public override TVisitor Accept<TVisitor>(TVisitor visitor)
		{
			visitor.Visit(this);
			return visitor;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != this.GetType())
			{
				return false;
			}
			return Equals((Mark)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Attributes.GetHashCode();
				hashCode = (hashCode * 397) ^ DoubleDelimited.GetHashCode();
				hashCode = (hashCode * 397) ^ Elements.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(Mark left, Mark right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Mark left, Mark right)
		{
			return !Equals(left, right);
		}

		protected bool Equals(Mark other)
		{
			return Equals(Attributes, other.Attributes) &&
			       DoubleDelimited == other.DoubleDelimited &&
			       Elements.SequenceEqual(other.Elements);
		}
	}
}