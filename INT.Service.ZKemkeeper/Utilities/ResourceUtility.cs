using System.Reflection;
using System.Resources;

namespace INT.Service.ZKemkeeper.Utilities
{
    internal static class ResourceUtility
    {
        #region Properties
        private static ResourceManager _resource = null;

        private const string RESOURCE_FILE = "INT.Service.ZKemkeeper.Resources.ErrorCodesResource";
        #endregion Properties

        #region Methods
        /// <summary>
        /// Get a value from the resource file
        /// </summary>
        /// <param name="key">Key for the resource</param>
        /// <returns>Value of the resource</returns>
        private static string GetValueFromResource(string key)
        {
            if (_resource == null)
                LoadResourceManager();

            return _resource.GetString(key);
        }

        /// <summary>
        /// Load the resource file ErrorCodesResource
        /// </summary>
        private static  void LoadResourceManager()
        {
            // Create the resource manager.
            Assembly assembly = typeof(ResourceUtility).Assembly;

            //ResFile.Strings -> <Namespace>.<ResourceFileName i.e. Strings.resx> 
            _resource = new ResourceManager(RESOURCE_FILE, assembly);
        }

        /// <summary>
        /// Get the error message description if the device has some kind of error
        /// </summary>
        /// <param name="errorCodId">Identification of the error</param>
        /// <returns>Empty if everything is ok or the message in error case</returns>
        public static string GetErrorMessage(int errorCodId)
        {
            if (errorCodId != 1)
                return GetValueFromResource(errorCodId.ToString());

            return string.Empty;
        }
        #endregion Methods
    }
}
