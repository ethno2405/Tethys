using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Tethys.Observer.Domain.Common
{
    public static class Extensions
    {
        public static string GetSHA512(this string value)
        {
            return Convert.ToBase64String(SHA512.Create("SHA512").ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}