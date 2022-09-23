using System.Security.Claims;
using CManagerApplication.Exceptions;

namespace CManagerAPI.Helpers.Users
{
    public static class UserIdFromContext
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var success = Guid.TryParse(userId, out Guid id);

            if (!success)
                throw new InvalidIdException("Invalid id");

            return id;
        }
    }
}

