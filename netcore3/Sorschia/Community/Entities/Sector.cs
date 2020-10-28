﻿namespace Sorschia.Community.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static bool operator ==(Sector left, Sector right) => Equals(left, right);

        public static bool operator !=(Sector left, Sector right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Sector value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}