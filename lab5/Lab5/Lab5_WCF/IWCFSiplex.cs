using Lab5_WCF.Models;
using System.ServiceModel;

namespace Lab5_WCF
{
    [ServiceContract]
    public interface IWCFSiplex
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        string Concat(string s, double d);

        [OperationContract]
        A Sum(A a1, A a2);
    }
}
