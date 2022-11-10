using System.ServiceModel;

namespace lab_6_odata
{
    [ServiceContract]
    public interface IStudentNotesModify
    {
        [OperationContract]
        void Insert(string name);

        [OperationContract]
        void Update(int id, string name);
    }
}
