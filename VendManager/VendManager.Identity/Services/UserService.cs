using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendManager.Application.Contracts.Identity;
using VendManager.Application.Models.Identity;
using VendManager.Identity.DbContext;
using VendManager.Identity.Models;

namespace VendManager.Identity.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly VendManagerIdentityDbContext _context;

        public UserService(UserManager<ApplicationUser> userManager, VendManagerIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<User> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<Application.Models.Identity.UserDetails> GetUserDetails(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if(user != null)
            {
                var userDetails =  await _context.UserDetails.Where(u => u.AspNetUserId == userId).SingleAsync();
                return new Application.Models.Identity.UserDetails
                {
                    EmailNotificationIntervalMinutes = userDetails.EmailNotificationIntervalMinutes,
                    EmailNotificationOnlyOutStockPeriodMinutes = userDetails.EmailNotificationOnlyOutStockPeriodMinutes,
                    EmailNotificationLastProcessedAtDateTimeUTC = userDetails.EmailNotificationLastProcessedAtDateTimeUTC,
                    SMSNotificationIntervalMinutes = userDetails.SMSNotificationIntervalMinutes,
                    SMSlNotificationOnlyOutStockPeriodMinutes = userDetails.SMSlNotificationOnlyOutStockPeriodMinutes,
                    SMSlNotificationLastProcessedAtDateTimeUTC = userDetails.SMSlNotificationLastProcessedAtDateTimeUTC,
                    AspNetUserId = userDetails.AspNetUserId,
                    AspNetUser = new User
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    }
                };
            }

            return null;

        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            return users.Select(user => new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();
        }

        public async Task UpdateUserDetails(Application.Models.Identity.UserDetails userDetails)
        {
            var existingUserDetails = await _context.UserDetails.SingleOrDefaultAsync(u => u.AspNetUserId == userDetails.AspNetUserId);

            if (existingUserDetails != null)
            {
                existingUserDetails.EmailNotificationIntervalMinutes = userDetails.EmailNotificationIntervalMinutes;
                existingUserDetails.EmailNotificationOnlyOutStockPeriodMinutes = userDetails.EmailNotificationOnlyOutStockPeriodMinutes;
                existingUserDetails.EmailNotificationLastProcessedAtDateTimeUTC = userDetails.EmailNotificationLastProcessedAtDateTimeUTC;
                existingUserDetails.SMSNotificationIntervalMinutes = userDetails.SMSNotificationIntervalMinutes;
                existingUserDetails.SMSlNotificationOnlyOutStockPeriodMinutes = userDetails.SMSlNotificationOnlyOutStockPeriodMinutes;
                existingUserDetails.SMSlNotificationLastProcessedAtDateTimeUTC = userDetails.SMSlNotificationLastProcessedAtDateTimeUTC;

                _context.UserDetails.Update(existingUserDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}
