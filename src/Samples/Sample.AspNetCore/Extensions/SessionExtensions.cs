using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Sample.AspNetCore.Extensions;

public static class SessionExtensions
{
    public static T GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);
        return sessionData == null
            ? default
            : JsonSerializer.Deserialize<T>(sessionData);
    }


    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }
}