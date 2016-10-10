namespace INT.Service.DAL.Base
{
    using INT.Service.DAL.Model;
    using System;
    public class BaseContext : IDisposable
    {
        #region Attributes

        private IntellisoftEntities _Context;

        #endregion

        #region Methods

        public void LoadNewContext()
        {
            _Context = new IntellisoftEntities();
        }

        #endregion

        #region Properties

        public IntellisoftEntities Context
        {
            get
            {
                if (_Context == null)
                    _Context = new IntellisoftEntities();

                return _Context;
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _Context.Dispose();
        }

        #endregion
    }
}
