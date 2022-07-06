using System.Security.Claims;

namespace CManagerAPI.Helpers.Users
{
    public static class UserIdFromContext
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Guid.TryParse(userId, out Guid id);

            return id;
        }
    }
}

