using Microsoft.Samples.JsonFeeds;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace lab_7_feed
{
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    [ServiceKnownType(typeof(JsonFeedFormatter))]
    public interface IFeed1
    {

        [OperationContract]
        [WebGet(UriTemplate = "*", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter CreateFeed();

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();
    }
}
