using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.ValueObjects
{
    [DebuggerDisplay("{Value}")]
    public class EmailAddress : IEquatable<EmailAddress>, IEquatable<string>
    {
        public string Value { get; }

        public EmailAddress(string value)
        {
            if (!value.Contains("@")) throw new Exception("Email is invalid");

            Value = value;
        }

        #region Conversion

        public static implicit operator string(EmailAddress value)
        {
            return value.Value;
        }

        public static implicit operator EmailAddress(string value)
        {
            return new EmailAddress(value);
        }

        #endregion

        #region Equality

        public override bool Equals(object obj)
        {
            var other = obj as EmailAddress;

            return other != null ? Equals(other) : Equals(obj as string);
        }

        public bool Equals(EmailAddress other) => other != null && Value == other.Value;

        public bool Equals(string other) => Value == other;

        public static bool operator ==(EmailAddress a, EmailAddress b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (((object)a == null) || ((object)b == null)) return false;

            return a.Value == b.Value;
        }

        public static bool operator !=(EmailAddress a, EmailAddress b) => !(a == b);

        #endregion

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}
