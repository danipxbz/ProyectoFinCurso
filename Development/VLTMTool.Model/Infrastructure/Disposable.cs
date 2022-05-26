using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.Model.Infractrusture
{
    public class Disposable : IDisposable
    {
        #region Attributes

        private bool isDisposed;

        #endregion Attributes

        #region Destructors

        /// <summary>
        /// Libera los recursos consumidos
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        #endregion Destructors

        #region Public Methods

        /// <summary>
        /// Libera los recursos consumidos
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Override this to dispose custom objects
        /// </summary>
        protected virtual void DisposeCore()
        {
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Libera los recursos consumidos
        /// </summary>
        /// <param name="disposing">Indica si se realiza una liberación de los recusos consumidos</param>
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        #endregion Private Methods
    }
}
