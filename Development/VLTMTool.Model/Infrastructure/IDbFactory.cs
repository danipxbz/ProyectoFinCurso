using System;
using VLTMTool.Model.Model;

namespace VLTMTool.Model.Infractrusture
{
    public interface IDbFactoryVLTM : IDisposable
    {
        VLTMModelConnection Init();
        VLTMModelConnection NewTemporaryConnection();
    }
}
