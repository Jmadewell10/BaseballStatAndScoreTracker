using BaseballStatAndScoreTracker.Common.Models;
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
    }
}
