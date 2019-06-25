using System.Threading.Tasks;

namespace ComicVibe.App.Helpers
{
    /// <summary>
    /// Represents a set of key/value application configuration properties.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>Gets or sets a configuration value.</summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        string this[string key] { get; set; }

        /// <summary>
        /// Gets a configuration sub-section with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" />.</returns>
        /// <remarks>
        ///     This method will never return <c>null</c>. If no matching sub-section is found with the specified key,
        ///     an empty <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" /> will be returned.
        /// </remarks>
        IConfigurationSection GetSection(string key);


        /// <summary>
        /// Loads the config file from disk
        /// </summary>
        /// <returns></returns>
        Task Init();
    }
}
