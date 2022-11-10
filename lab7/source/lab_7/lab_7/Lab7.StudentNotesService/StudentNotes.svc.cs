using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;

namespace lab_6_odata
{
    public class StudentNotes : EntityFrameworkDataService<WsKakEntities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
    }
}
