using BaseballStatAndScoreTracker.Common.Models;
using BaseballStatAndScoreTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStatAndScoreTracker.Services.Extensions
{
    public static class ValidationExtension
    {
        public static void ValidateLoginCred(this LoginCredentialsDto loginCredentials)
        {
            ArgumentNullException.ThrowIfNull(loginCredentials);
            ArgumentNullException.ThrowIfNull(loginCredentials.UserName);
            ArgumentNullException.ThrowIfNull(loginCredentials.Password);

        }

        public static void ValidateNewAccountDto(this NewAccountDto accountDto)
        {
            ArgumentNullException.ThrowIfNull(accountDto.Login);
            ArgumentNullException.ThrowIfNull(accountDto.Login.Password);
            ArgumentNullException.ThrowIfNull(accountDto.Login.UserName);

        }

        public static bool ValidateNewLoginCred(this LoginCredentialsDto loginCredentialsDto, IEnumerable<string> users)
        {
            ArgumentNullException.ThrowIfNull(loginCredentialsDto.Password);
            ArgumentNullException.ThrowIfNull(loginCredentialsDto.UserName);
            if (!loginCredentialsDto.Password.ValidateNewPassword())
            {
                return false;
            }

            if (!loginCredentialsDto.UserName.ValidateNewUserName(users))
            {
                return false;
            }
            return true;
        }


        private static bool ValidateNewPassword(this string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            if (!password.Any(Char.IsUpper))
            {
                return false;
            }

            if (!password.Any(Char.IsSymbol))
            {
                return false;
            }
            return true;
        }

        private static bool ValidateNewUserName(this string userName, IEnumerable<string> users)
        {
            string userNameNormalized = userName.ToLower();
            bool isUnique = !users.Any(u => u.ToLower() == userNameNormalized);
            return isUnique;
        }
    }
}
