using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Gotrue;
using Orjeen_Stok_Takip.Models;

namespace Orjeen_Stok_Takip.Services
{
    public static class AuthService
    {
        public static Session? CurrentSession => SupabaseManager.Client.Auth.CurrentSession;
        public static User? CurrentUser => SupabaseManager.Client.Auth.CurrentUser;
        public static UserProfile? CurrentProfile { get; private set; }

        public static async Task<bool> SignInAsync(string email, string password)
        {
            try
            {
                var session = await SupabaseManager.Client.Auth.SignIn(email, password);
                if (session != null && session.User != null)
                {
                    await LoadProfileAsync(session.User.Id);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sign In error: {ex.Message}");
                throw;
            }
        }

        public static async Task<bool> SignUpAsync(string email, string password, string fullName)
        {
            try
            {
                var options = new SignUpOptions
                {
                    Data = new Dictionary<string, object>
                    {
                        { "full_name", fullName }
                    }
                };
                var session = await SupabaseManager.Client.Auth.SignUp(email, password, options);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sign Up error: {ex.Message}");
                throw;
            }
        }

        public static async Task SignOutAsync()
        {
            try
            {
                await SupabaseManager.Client.Auth.SignOut();
                CurrentProfile = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sign Out error: {ex.Message}");
            }
        }

        public static async Task LoadProfileAsync(string userId)
        {
            try
            {
                var result = await SupabaseManager.Client
                    .From<UserProfile>()
                    .Where(x => x.Id == userId)
                    .Single();
                
                CurrentProfile = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user profile: {ex.Message}");
                CurrentProfile = new UserProfile
                {
                    Id = userId,
                    Email = CurrentUser?.Email ?? string.Empty,
                    FullName = "Yeni Personel",
                    Role = "Staff"
                };
            }
        }
    }
}
