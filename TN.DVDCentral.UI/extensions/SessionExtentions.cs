using Newtonsoft.Json;

namespace TN.DVDCentral.UI.extensions
{
    public static class SessionExtentions
    {
        public static void SetObject(this ISession session, string key, object values)
        {
            session.SetString(key, JsonConvert.SerializeObject(values));
        }

         public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
