using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;

namespace VLTMTool.ViewModel
{
    public class Authentication
    {
        #region Property
        public bool IsAuthenticated { get; protected set; }
        public string Summary { get; protected set; }
        public Exception Exception { get; protected set; }
        private DirectoryEntry entry;
        #endregion
        public Authentication(string user, string password)
        {
            try
            {
                // Active Directory
                string ad = ConfigurationManager.AppSettings["AD"];
                // new instance
                entry = new DirectoryEntry(ad, user, password);
                // conection
                object nativeObject = entry.NativeObject;

                if (HasFunctionsGrants())
                {
                IsAuthenticated = true;
                Exception = null;
                Summary = "Correct Login";
                LoginInfo.UserName = user;
                }
                else
                {
                    IsAuthenticated = false;
                    Exception = null;
                    Summary = "Access denied";
                }
            }
            catch (DirectoryServicesCOMException ex)
            {
                IsAuthenticated = false;
                Exception = ex;
                Summary = ex.Message;
            }
            catch (Exception ex)
            {
                IsAuthenticated = false;
                Exception = ex;
                Summary = ex.Message;
            }
        }
        private bool HasFunctionsGrants()
        {
            string user = entry.Username;

            if (true)//TODO comprobar que el usuario que ha iniciado sesión existe en la bbdd
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
