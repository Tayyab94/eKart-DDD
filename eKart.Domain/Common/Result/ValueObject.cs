using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Domain.Common.Result
{
    public abstract record class ValueObject<T> where T: notnull
    {

        public T Value { get; }

        protected ValueObject(T value)
        {
            Value = value;
        }

        public override string ToString()=> Value.ToString();


        //public override bool Equals(object? obj)
        //{
        //    if (obj == null || obj.GetType() != this.GetType())
        //        return false;
        //    var valueObject = (ValueObject<T>)obj;
        //    return Value.Equals(valueObject.Value);
        //}
        //public override int GetHashCode() => Value.GetHashCode();
        //public override string ToString() => Value.ToString();
    }
}
