using System.Collections.Concurrent;
using System.Threading;

namespace OnionPattern.Api.Configuration.Startup.Logging
{
    /// <summary>
    /// A cross the application call dictionary.
    /// </summary>
    /// <typeparam name="T">Stored Item Type</typeparam>
    public static class CallContext<T>
    {
        private static readonly ConcurrentDictionary<string, AsyncLocal<T>> state = new ConcurrentDictionary<string, AsyncLocal<T>>();
        
        /// <summary>
        /// Stores a given object and associates it with the specified name.
        /// </summary>
        /// <param name="name">The name with which to associate the new item in the call context.</param>
        /// <param name="data">The object to store in the call context.</param>
        public static void SetData(string name, T data) => state.GetOrAdd(name, _ => new AsyncLocal<T>()).Value = data;


        /// <summary>
        /// Retrieves an object with the specified name from the <see cref="CallContext{T}"/> >.
        /// </summary>
        /// The type of the data being retrieved. Must match the type used when the <paramref name="name"/> 
        /// was set via <see cref="SetData(string, T)"/>.
        /// <param name="name">The name of the item in the call context.</param>
        /// <returns>
        /// The object in the call context associated with the specified name, 
        /// or a default value for <typeparamref name="T"/> if none is found.
        /// </returns>
        public static T GetData(string name) => state.TryGetValue(name, out var data) ? data.Value : default(T);
    }
}