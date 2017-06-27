using System;

namespace Heroes.DraftViewer.Core
{
    public interface IPlayableHero
    {
        string Name { get; }
    }

    public class Hero : IPlayableHero, IEquatable<IPlayableHero>
    {
        public Hero(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            
            Name = name;
        }

        public bool Equals(IPlayableHero other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            return Equals((IPlayableHero) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StringComparer.OrdinalIgnoreCase.GetHashCode(Name) * 397);
            }
        }

        public static bool operator ==(Hero left, Hero right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Hero left, Hero right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}