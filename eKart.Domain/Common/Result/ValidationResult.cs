using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Domain.Common.Result
{
    public class ValidationResult<T>
    {
        public bool IsValid { get; }
        public List<string> Errors { get; } 

        public T? Value { get; }

        public ValidationResult(bool isValid, List<string>errors, T? value)
        {
            this.IsValid = isValid;
            this.Errors = errors;
            this.Value = value;
        }

        public static ValidationResult<T> Success(T value) => new ValidationResult<T>(true, new List<string>(), value);
        public static ValidationResult<T>Failure(List<string> errors) => new ValidationResult<T>(false, errors, default);

        public override string ToString() => IsValid ? $"Valid : {IsValid}" : $"Invalid: {string.Join(", ", Errors)}";
    }
}
