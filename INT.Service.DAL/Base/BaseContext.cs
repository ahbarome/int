using INT.Service.DAL.Model;
using System;

namespace INT.Service.DAL.Base
{
    public class BaseContext : IDisposable
    {
        #region Attributes

        private QuartzEntities _Context;

        #endregion

        #region Methods

        public void LoadNewContext()
        {
            _Context = new QuartzEntities();
        }

        #endregion

        #region Properties

        public QuartzEntities Context
        {
            get
            {
                if (_Context == null)
                    _Context = new QuartzEntities();

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
