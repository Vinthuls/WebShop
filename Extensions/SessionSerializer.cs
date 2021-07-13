using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace WebShop.Extensions
{
    public static class SessionSerializer
    {
        public static void SerializeToJson(this ISession session,
            string key, object value )
        {
           
        }
    }
}
