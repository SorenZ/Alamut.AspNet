using System;

namespace Alamut.Extensions.Caching.Test.Helpers
{
    public class RefTypeObject : IEquatable<RefTypeObject>
    {
        public int foo { get; set; }
        public string bar { get; set; }
        public DateTime Created { get; set; }

        public bool Equals(RefTypeObject other) =>
            foo.Equals(other.foo) && 
                bar.Equals(other.bar) &&
                Created.Equals(other.Created);
    }
}