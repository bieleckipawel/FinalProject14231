using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using FinalProject14231.Application.Common.Interfaces;

namespace FinalProject14231.Infrastructure.Services
{
    public class UserService : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public string GetUserId()
        {
            var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                throw new InvalidOperationException("User ID not found");
            }
            return id;
        }

        public string GetUserName()
        {
            var name = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (name == null)
            {
                throw new InvalidOperationException("User name not found");
            }
            return name;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
