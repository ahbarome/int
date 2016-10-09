using System;
using Common.Logging;

namespace INT.Service.Host
{
    public class Controller : BaseController
    {
        #region Properties
        private readonly ILog _log = null;
       
        #endregion Properties

        #region Methods
        public Controller()
        {
            _log = LogManager.GetLogger(this.GetType());
        }

        /// <summary>
        /// Start the service with TopShelf and load the Spring .NET context
        /// </summary>
        public override void Start()
        {
            try
            {
                base.Start();
            }
            catch (Exception exception)
            {
                _log.Fatal(exception.Message, exception);
            }
        }

        /// <summary>
        /// Stop the service with TopShelf and stop the Spring .NET context
        /// </summary>
        public override void Stop()
        {
            try
            {
                base.Stop();
            }
            catch (Exception exception)
            {
                _log.Fatal(exception.Message, exception);
                Environment.Exit(0);
            }
        }
        #endregion Methods
    }
}
