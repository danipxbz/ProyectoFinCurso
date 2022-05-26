using VLTMTool.Model.Infractrusture;
using VLTMTool.Model.Infrastructure;
using VLTMTool.Model.Model;

namespace VLTMTool.Model.Services
{
    public class ServiceBase
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

        public ServiceBase(IDbFactoryVLTM dbFactory)
        {
            DbFactory = dbFactory;
        }
    }
}
