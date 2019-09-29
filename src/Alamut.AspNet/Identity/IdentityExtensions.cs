using System.Linq;

using Microsoft.AspNetCore.Identity;

using Alamut.Abstractions.Structure;

namespace Alamut.AspNet.Identity
{
    public static class IdentityExtensions
    {
        public static Result AsResult(this IdentityResult source)
        {
            return new Result
            {
                Succeed = source.Succeeded,
                Message = source.Succeeded
                    ? string.Empty
                    : source.Errors.Select(s => s.Description).Aggregate((a, b) => a + " " + b)
            };
        }

        public static Result<T> AsResult<T>(this IdentityResult source, T data)
        {
            return new Result<T>
            {
                Data = data,
                Succeed = source.Succeeded,
                Message = source.Succeeded
                    ? string.Empty
                    : source.Errors.Select(s => s.Description).Aggregate((a, b) => a + " " + b)
            };
        }
    }
}
