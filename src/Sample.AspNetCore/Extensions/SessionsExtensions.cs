namespace Sample.AspNetCore.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public static class SessionsExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            var jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            session.SetString(key, JsonConvert.SerializeObject(value, jsSettings));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            //JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            //jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }

    }
}