﻿namespace Sorschia.Community.Entities
{
    public class PoliticalArea
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static bool operator ==(PoliticalArea left, PoliticalArea right) => Equals(left, right);

        public static bool operator !=(PoliticalArea left, PoliticalArea right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is PoliticalArea value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}
