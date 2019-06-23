﻿using System;

namespace Alamut.Utilities.AspNet.Test.Helpers
{
    public class RefTypeObject : IEquatable<RefTypeObject>
    {
        public int foo { get; set; }
        public string bar { get; set; }

        public bool Equals(RefTypeObject other) => 
            this.foo.Equals(other.foo) && bar.Equals(other.bar);
    }
}