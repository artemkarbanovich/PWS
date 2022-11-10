using Microsoft.Samples.JsonFeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using WsKakModel;

namespace lab_7_feed
{
    public class Feed1 : IFeed1
    {
        public SyndicationFeedFormatter CreateFeed()
        {
            var feed = new SyndicationFeed("Student Notes Feed", "A WCF Syndication Student Notes Feed", null);
            var service = new WsKakEntities(new Uri("http://localhost:58061/StudentNotes.svc"));

            service.Students.AddQueryOption("$expand", "Notes");
            service.Notes.AddQueryOption("$expand", "Student");

            var students = service.Students.Execute().ToList();
            var notes = service.Notes.Execute().ToList();

            var syndicationItems = new List<SyndicationItem>();

            foreach (var student in students)
            {
                var studentNotes = string.Join(", ", notes
                    .Where(x => x.StudentId == student.Id)
                    .Select(x => $"{x.Subject} - {x.Note1}\t\n\n"));

                syndicationItems.Add(new SyndicationItem(student.Name, studentNotes, null));
            }

            feed.Items = syndicationItems;

            var query = WebOperationContext.Current?.IncomingRequest.UriTemplateMatch.QueryParameters["format"];

            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "*");

            if (query?.ToLower() == "atom")
                return new Atom10FeedFormatter(feed);
            else if (query?.ToLower() == "json")
                return new JsonFeedFormatter(feed);
            else
                return new Rss20FeedFormatter(feed);
        }

        public void GetOptions()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "*");
        }
    }
}
