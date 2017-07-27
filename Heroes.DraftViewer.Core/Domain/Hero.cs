using System;

namespace Heroes.DraftViewer.Core
{
    public interface IPlayableHero
    {
        int Id { get; }
        string Name { get; }
        HeroRole Role { get; }
    }

    public class Hero : IPlayableHero, IEquatable<IPlayableHero>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HeroRole Role { get; set; }
        public HeroPortrait Portrait { get; set; } = new HeroPortrait();

        #region equality

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IPlayableHero)obj);
        }

        public bool Equals(IPlayableHero other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name?.GetHashCode() ?? 0) * 397) ^ Id;
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

        #endregion
    }
}