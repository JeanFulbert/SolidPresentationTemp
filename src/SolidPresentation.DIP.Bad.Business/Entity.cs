﻿namespace SolidPresentation.DIP.Bad.Business
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(compareTo, null))
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (!IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id)
                return true;

            return false;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (this.GetType().ToString() + this.Id).GetHashCode();
        }

        public virtual bool IsTransient()
        {
            return Id == 0;
        }
    }
}
