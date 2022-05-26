using AutoMapper;
using VLTMTool.Model.Infractrusture;
using VLTMTool.Model.Model;

namespace VLTMTool.Model.Services
{
    public class ServiceBDBase
    {
        private VLTMModelConnection dbContext;

        protected IDbFactoryVLTM DbFactory
        {
            get;
            private set;
        }

        public VLTMModelConnection DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }

        protected VLTMModelConnection TemporaryDbContext
        {
            get { return DbFactory.NewTemporaryConnection(); }
        }

        public ServiceBDBase(IDbFactoryVLTM dbFactory)
        {
            DbFactory = dbFactory;
        }
    }
}
