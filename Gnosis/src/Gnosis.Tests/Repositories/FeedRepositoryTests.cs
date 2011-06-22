﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using NUnit.Framework;
using System.Data.SQLite;

using Gnosis.Core;
using Gnosis.Core.Iso;
using Gnosis.Core.Queries;
using Gnosis.Alexandria.Models;
using Gnosis.Alexandria.Models.Feeds;
using Gnosis.Alexandria.Repositories.Feeds;

namespace Gnosis.Tests.Repositories
{
    [TestFixture]
    public class FeedRepositoryTests
    {
        private IContext context;
        private ILogger logger;
        private IFeedRepository repository;
        private IDbConnection connection;

        private readonly Uri feedLocation = new Uri("http://espn.go.com/espnradio/feeds/rss/podcast.xml?id=2864045");

        #region Helper Methods

        private int GetCount(string sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                return int.Parse(command.ExecuteScalar().ToString());
            }
        }

        private IFeed GetFeed()
        {
            var feed = new Feed();
            feed.Initialize(new EntityInitialState(context, logger));
            feed.Authors = "Bill Simmons";
            feed.Contributors = "Joe House, Marc Stein, John Hollinger";
            feed.Copyright = "c 2009-2011";
            feed.Description = "Sports etc.";
            feed.FeedIdentifier = "12345ABC";
            feed.Generator = "espn.go.com";
            feed.Language = Language.English;
            feed.Location = feedLocation;
            feed.MediaType = "application/xml+rss";
            feed.OriginalLocation = new Uri("http://espn.go.com/espnradio/feeds/rss/podcast.xml?id=2864045");
            feed.PublishedDate = new DateTime(2009, 2, 13);
            feed.UpdatedDate = new DateTime(2011, 6, 7);
            feed.Title = "BS Report";
            feed.IconPath = new Uri("http://assets.espn.go.com/i/espnradio/podcast/bsreport_subway_300.jpg");
            feed.ImagePath = new Uri("http://assets.espn.go.com/i/espnradio/podcast/bsreport_subway_300.jpg");
            feed.AddCategory(UriExtensions.EmptyUri, "Sports", "Sports");
            feed.AddCategory(UriExtensions.EmptyUri, "Comedy", "Comedy");
            feed.AddLink("self", new Uri("http://espn.go.com/espnradio/feeds/rss/podcast.xml?id=2864045"), "application/xml+rss", 0, "en-us");
            feed.AddLink("alt", new Uri("http://espn.go.com/espnradio"), "text/html", 0, "en-us");
            feed.AddLink("alt", new Uri("http://espn.go.com/epsnradio?lang=es-mx"), "text/html", 0, "es-mx");
            feed.AddMetadatum("text/plain", UriExtensions.EmptyUri, "tag", "Bill Simmons");
            feed.AddMetadatum("application/xml", UriExtensions.EmptyUri, "marquee", "<marquee><title>BS Report</title><subtitle>with Bill Simmons</subtitle></marquee>");

            var item = new FeedItem();
            item.Initialize(new EntityInitialState(context, logger, feed.Id, 0));
            item.Authors = "Bill Simmons";
            item.Contributors = "Joe House, Joe Mead";
            item.Copyright = "Copyright ESPN 2011";
            item.FeedItemIdentifier = "ZYZ235AMQ3792206";
            item.Summary = "Bill previews the NBA Finals with ESPN experts";
            item.PublishedDate = new DateTime(2011, 6, 5);
            item.UpdatedDate = new DateTime(2011, 6, 5);
            item.Title = "NBA Finals Preview (Part 1)";
            item.TitleMediaType = "text/plain";
            item.AddLink("self", new Uri("http://espn.go.com/espnradio/media/xyz1.mp3"), "audio/mpeg", 0, "en-us");
            item.AddMetadatum("text/plain", UriExtensions.EmptyUri, "rating", "4/5");
            item.AddMetadatum("application/xml", UriExtensions.EmptyUri, "rating", "<rating><score>4</score><max>5</max></rating>");
            feed.AddItem(item);

            var item2 = new FeedItem();
            item2.Initialize(new EntityInitialState(context, logger, feed.Id, 0));
            item2.Authors = "Bill Simmons";
            item2.Contributors = "Joe House, Joe Mead";
            item2.Copyright = "Copyright ESPN 2011";
            item2.FeedItemIdentifier = "ZYZ235AMQ38564587";
            item2.Summary = "Bill previews the NBA Finals with ESPN experts";
            item2.PublishedDate = new DateTime(2011, 6, 5);
            item2.UpdatedDate = new DateTime(2011, 6, 5);
            item2.Title = "NBA Finals Preview (Part 2)";
            item2.TitleMediaType = "text/plain";
            item2.AddCategory(UriExtensions.EmptyUri, "Basketball", "Basketball");
            item2.AddLink("self", new Uri("http://espn.go.com/espnradio/media/xyz2.mp3"), "audio/mpeg", 0, "en-us");
            item2.AddMetadatum("text/plain", UriExtensions.EmptyUri, "rating", "4/5");
            item2.AddMetadatum("application/xml", UriExtensions.EmptyUri, "rating", "<rating><score>4</score><max>5</max></rating>");
            feed.AddItem(item2);

            return feed;
        }

        private IFeed GetFeed(Uri location, string title, string authors, string contributors, string description)
        {
            var feed = new Feed();
            feed.Initialize(new EntityInitialState(context, logger));
            feed.Location = location;
            feed.Title = title;
            feed.Authors = authors;
            feed.Contributors = contributors;
            feed.Description = description;
            return feed;
        }

        private IFeedItem GetFeedItem(IFeed parent, string title, string authors, string contributors, string summary)
        {
            var item = new FeedItem();
            item.Initialize(new EntityInitialState(context, logger, parent.Id));
            item.Title = title;
            item.Authors = authors;
            item.Contributors = contributors;
            item.Summary = summary;
            parent.AddItem(item);
            return item;
        }

        private void ModifyTestFeed(IFeed feed)
        {
            feed.Title = "Some other title";
            feed.FeedIdentifier = "NEW-ID-5634634636-NEW";
            feed.Generator = "other-generator";

            var firstCategory = feed.Categories.FirstOrDefault();
            feed.RemoveCategory(firstCategory);


            feed.RemoveItem(feed.Items.LastOrDefault());
            feed.Items.FirstOrDefault().RemoveMetadatum(feed.Items.FirstOrDefault().Metadata.FirstOrDefault());
            feed.Items.FirstOrDefault().AddCategory(new Uri("http://example.com/scheme"), "Misc.", "Misc.");
            feed.AddMetadatum("text/html", new Uri("http://other.com/1/different-scheme"), "review", "<html><body><p>This feed is awesome</p><p>I <b>love</b> it so much!</p></body></html>");
        }

        #endregion

        #region Setup

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            context = new SingleThreadedContext();
            logger = new DebugLogger();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
        }

        [SetUp]
        public void SetUp()
        {
            connection = new SQLiteConnection("Data Source=:memory:;Version=3;");
            connection.Open();

            repository = new FeedRepository(context, logger, connection);
            repository.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }

        #endregion

        #region Create

        [Test]
        public void CreateFeed()
        {
            var initialFeeds = repository.Search();
            Assert.AreEqual(0, initialFeeds.Count());

            var feed = GetFeed();

            Assert.IsTrue(feed.IsNew());

            repository.Save(new List<IFeed> { feed });

            Assert.IsFalse(feed.IsNew());

            var createdFeed = repository.LookupByLocation(feedLocation);

            Assert.IsNotNull(createdFeed);

            repository.Delete(new List<IFeed> { feed });

            var deletedFeed = repository.LookupByLocation(feedLocation);

            Assert.IsNull(deletedFeed);
        }

        #endregion

        #region Update

        [Test]
        public void UpdateFeed()
        {
            var feed = GetFeed();
            var id = feed.Id;

            Assert.AreEqual(6, feed.TitleHashCodes.Count());

            repository.Save(new List<IFeed> { feed });

            const string title = "New Title";
            const string description = "Updated Description";
            const string copyright = "Copyright 2000";
            const string authors = "Tweedle Dee and Tweedle Dumb, The Walrus and the Carpenter";
            const string contributors = "Larry, Moe and Curly";
            const string feedIdentifier = "1234WXYZ7890ABCD"; 
            const string generator = "some-generator-name-XYZ";
            const string iconPath = "http://example.com/icons/path.jpg";
            const string imagePath = "http://exmaple.com/images/path.jpg";
            ILanguage language = Language.Spanish;
            const string location = "http://example.com/feeds/rss/example.xml";
            const string mediaType = "application/xml";
            var publishedDate = new DateTime(2011, 2, 13);
            var updatedDate = new DateTime(2011, 4, 27);
            const string testCategoryName = "ABC Some Category";

            var titleNameHash = feed.TitleHashCodes.Where(x => x.Scheme == HashCode.SchemeNameHash).FirstOrDefault().Value;
            var titleDoubleMetaphone = feed.TitleHashCodes.Where(x => x.Scheme == HashCode.SchemeDoubleMetaphone).FirstOrDefault().Value;

            feed.Title = title;
            feed.Description = description;
            feed.Copyright = copyright;
            feed.Authors = authors;
            feed.Contributors = contributors;
            feed.FeedIdentifier = feedIdentifier;
            feed.Generator = generator;
            feed.IconPath = new Uri(iconPath);
            feed.ImagePath = new Uri(imagePath);
            feed.Language = language;
            feed.Location = new Uri(location);
            feed.MediaType = mediaType;
            feed.OriginalLocation = new Uri(location);
            feed.PublishedDate = publishedDate;
            feed.UpdatedDate = updatedDate;

            Assert.AreEqual(6, feed.TitleHashCodes.Count());
            Assert.AreEqual(18, feed.AuthorHashCodes.Count());
            Assert.AreEqual(2, feed.Categories.Count());
            Assert.IsTrue(feed.IsChanged());
            Assert.IsFalse(feed.IsNew());

            feed.AddCategory(new Uri("http://example.com/some-random-scheme/xyz"), testCategoryName, testCategoryName);
            Assert.IsNotNull(feed.Categories.Where(x => x.Name == testCategoryName).FirstOrDefault());
            Assert.IsTrue(feed.Categories.Where(x => x.Name == testCategoryName).FirstOrDefault().IsNew());

            var oldTimeStamp = feed.TimeStamp;
            repository.Save(new List<IFeed>{ feed });
            Assert.AreEqual(1, GetCount(string.Format("select count() from Feed where Id = '{0}';", id)));
            
            var newTimeStamp = feed.TimeStamp;
            Assert.IsFalse(feed.IsChanged());
            Assert.AreNotEqual(oldTimeStamp, newTimeStamp);
            
            var changedFeed = repository.Lookup(id);
            Assert.AreEqual(18, GetCount(string.Format("select count() from Feed_AuthorHashCodes where Parent = '{0}';", id)));
            Assert.AreEqual(6, changedFeed.TitleHashCodes.Count());
            Assert.AreEqual(18, changedFeed.AuthorHashCodes.Count());
            Assert.AreNotEqual(titleNameHash, changedFeed.TitleHashCodes.Where(x => x.Scheme == HashCode.SchemeNameHash).FirstOrDefault().Value);
            Assert.AreNotEqual(titleDoubleMetaphone, changedFeed.TitleHashCodes.Where(x => x.Scheme == HashCode.SchemeDoubleMetaphone).FirstOrDefault().Value);
            Assert.IsNotNull(changedFeed);
            Assert.AreEqual(title, changedFeed.Title);
            Assert.AreEqual(description, changedFeed.Description);
            Assert.AreEqual(copyright, changedFeed.Copyright);
            Assert.AreEqual(authors, changedFeed.Authors);
            Assert.AreEqual(contributors, changedFeed.Contributors);
            Assert.AreEqual(feedIdentifier, changedFeed.FeedIdentifier);
            Assert.AreEqual(generator, changedFeed.Generator);
            Assert.AreEqual(iconPath, changedFeed.IconPath.ToString());
            Assert.AreEqual(imagePath, changedFeed.ImagePath.ToString());
            Assert.AreEqual(language, changedFeed.Language);
            Assert.AreEqual(location, changedFeed.Location.ToString());
            Assert.AreEqual(mediaType, changedFeed.MediaType);
            Assert.AreEqual(publishedDate, changedFeed.PublishedDate);
            Assert.AreEqual(updatedDate, changedFeed.UpdatedDate);
            Assert.IsNotNull(changedFeed.Categories.Where(x => x.Name == testCategoryName).FirstOrDefault());
            Assert.IsFalse(changedFeed.Categories.Where(x => x.Name == testCategoryName).FirstOrDefault().IsNew());
            Assert.AreEqual(3, changedFeed.Categories.Count());
        }

        #endregion

        #region Delete

        [Test]
        public void DeleteFeed()
        {
            Assert.AreEqual(new Uri("http://example.com/index.html"), new Uri("http://example.com/index.html"));

            var feed = GetFeed();
            var id = feed.Id;
            var linkCountSql = string.Format("select count() from Feed_Links where Parent = '{0}';", id);
            var feedItemId = feed.Items.FirstOrDefault().Id;
            var feedItemMetadataCountSql = string.Format("select count() from FeedItem_Metadata where Parent = '{0}';", feedItemId);
            repository.Save(new List<IFeed> { feed });

            var feed2 = new Feed();
            feed2.Initialize(new EntityInitialState(context, logger));
            var id2 = feed2.Id;
            Assert.AreNotEqual(id, id2);
            var item2 = new FeedItem();
            item2.Initialize(new EntityInitialState(context, logger, feed2.Id));
            var feedItem2MetadataCountSql = string.Format("select count() from FeedItem_Metadata where Parent = '{0}';", item2.Id);
            item2.AddMetadatum("text/plain", UriExtensions.EmptyUri, "Read Me", "Here is the text content of the read me.");
            item2.AddMetadatum("text/rtf", new Uri("file:///C:/Users/Bob/Documents/readme.rtf"), "Read Me", string.Empty);
            item2.AddMetadatum("application/msword", new Uri("file:///C:/Users/Bob/Documents/readme.doc"), "Read Me", string.Empty);

            var link2CountSql = string.Format("select count() from Feed_Links where Parent = '{0}';", id2);
            var itemMetadata2CountSql = string.Format("select count() from FeedItem_Metadata where Parent = '{0}';", item2.Id);
            feed2.Location = new Uri("http://example.com/feeds/somepath/feed.xml");
            feed2.AddLink("self", new Uri("http://example.com/feeds/somepath/feed.xml"), "application/xml+rss", 0, "en-us");
            feed2.AddItem(item2);

            var entityInfo = new EntityInfo(typeof(IFeed));
            var values = feed2.GetValues(entityInfo.Values.Where(x => x.Name == "Feed_Links").FirstOrDefault());
            Assert.AreEqual(1, values.Count());
            Assert.IsNotNull(values.FirstOrDefault());
            Assert.AreEqual(id2, values.FirstOrDefault().Parent);
            Assert.IsTrue(values.FirstOrDefault().IsNew());

            Assert.AreEqual(1, feed2.Links.Count());
            repository.Save(new List<IFeed> { feed2 });

            Assert.AreEqual(1, GetCount(link2CountSql));
            Assert.AreEqual(3, GetCount(itemMetadata2CountSql));
            Assert.AreEqual(2, repository.Search().Count());

            Assert.AreEqual(3, GetCount(linkCountSql));
            Assert.AreEqual(2, GetCount(feedItemMetadataCountSql));
            Assert.IsNotNull(repository.Lookup(id));

            repository.Delete(new List<IFeed> { feed });

            Assert.IsNull(repository.Lookup(id));
            Assert.AreEqual(0, GetCount(linkCountSql));
            Assert.AreEqual(0, GetCount(feedItemMetadataCountSql));
            Assert.AreEqual(1, GetCount(link2CountSql));
            Assert.AreEqual(3, GetCount(itemMetadata2CountSql));
        }

        #endregion

        #region Search

        [Test]
        public void SearchByTitle()
        {
            var feed1 = GetFeed(new Uri("http://espn.go.com/feeds/4636346"), "The BS Report", "Bill Simmons", "Joe House, Marc Stein, John Hollinger", "Bill Simmons Podcast");
            var feed2 = GetFeed(new Uri("http://cnn.com//other-path/rss?id=43645734625"), "CNN Feed", "A Bunch of Talking Heads", "More Jackasses", "Blah Blah Blah");
            var feed3 = GetFeed(new Uri("http://cnn.com//some-path/rss?id=9957457"), "CNN Feed #2", "Some Other Talking Heads", "Still More Jackasses", "Yadda Yadda Yadda");
            var feed4 = GetFeed(new Uri("http://comedycentral.com/feeds/colbert.xml"), "The Colbert Report and Other Nonsense", "Stephen Colbert", "Various", "Stephen Colbert, the great American Patriot, with his musings on politics and culture");
            var feed5 = GetFeed(new Uri("http://www.nerdist.com/category/podcast/"), "The Nerdist Podcast", "Chris Hardwick", "Uncredited", "Chris Hardwich being a NERD!");
            repository.Save(new List<IFeed> { feed1, feed2, feed3, feed4, feed5 });

            Assert.AreEqual(5, repository.Search().Count());

            var results = repository.SearchByTitle("Report");
            Assert.AreEqual(2, results.Count());
        }

        [Test]
        public void SearchByAuthor()
        {
            var feed1 = GetFeed(new Uri("http://espn.go.com/feeds/4636346"), "The BS Report", "Bill Simmons", "Joe House, Marc Stein, John Hollinger", "Bill Simmons Podcast");
            var feed2 = GetFeed(new Uri("http://cnn.com//other-path/rss?id=43645734625"), "CNN Feed", "A Bunch of Talking Heads", "More Jackasses", "Blah Blah Blah");
            var feed3 = GetFeed(new Uri("http://cnn.com//some-path/rss?id=9957457"), "CNN Feed #2", "Some Other Talking Heads", "Still More Jackasses", "Yadda Yadda Yadda");
            var feed4 = GetFeed(new Uri("http://comedycentral.com/feeds/colbert.xml"), "The Colbert Report and Other Nonsense", "Stephen Colbert", "Various", "Stephen Colbert, the great American Patriot, with his musings on politics and culture");
            var feed5 = GetFeed(new Uri("http://www.nerdist.com/category/podcast/"), "The Nerdist Podcast", "Chris Hardwick", "Uncredited", "Chris Hardwich being a NERD!");
            repository.Save(new List<IFeed> { feed1, feed2, feed3, feed4, feed5 });

            var results1 = repository.SearchByAuthors("Stephen Colbert");
            Assert.AreEqual(1, results1.Count());

            var results2 = repository.SearchByAuthors("Talking Heads");
            Assert.AreEqual(2, results2.Count());
        }

        [Test]
        public void SearchFeedsByKeyword()
        {
            var feedA = GetFeed(new Uri("http://espn.go.com/feeds/4636346"), "The BS Report", "Bill Simmons", "Joe House, Marc Stein, John Hollinger", "Bill Simmons Podcast");
            var feedB = GetFeed(new Uri("http://cnn.com//other-path/rss?id=43645734625"), "CNN Feed", "A Bunch of Talking Heads", "More Jackasses", "Blah Blah Blah");
            var feedC = GetFeed(new Uri("http://cnn.com//some-path/rss?id=9957457"), "CNN Feed #2", "Some Other Talking Heads", "Still More Jackasses", "Yadda Yadda Yadda");
            var feedD = GetFeed(new Uri("http://comedycentral.com/feeds/colbert.xml"), "The Colbert Report and Other Nonsense", "Stephen Colbert", "Various", "Stephen Colbert, the great American Patriot, with his musings on politics and culture");
            var feedE = GetFeed(new Uri("http://www.nerdist.com/category/podcast/"), "The Nerdist Podcast", "Chris Hardwick", "Uncredited", "Chris Hardwich being a NERD!");

            var itemE1 = GetFeedItem(feedE, "Apples", "Chris Hardwick", "Aaron Abramson", "Discussions about Apples");
            var itemE2 = GetFeedItem(feedE, "Bananas", "Chris Hardwick", "Bonny Brown", "Haggling for Bananas in the market");
            var itemE3 = GetFeedItem(feedE, "Cantaloupes", "Chris Hardwick", "Carl Castle", "In depth look at Cantaloupes");
            var itemE4 = GetFeedItem(feedE, "Durians", "Chris Hardwick", "Daria Doyle", "Arguments about the best ways to prepare Durians for delicious desserts");
            var itemA1 = GetFeedItem(feedA, "NBA Finals Preview Pt. 1", "Bill Simmons", "John Hollinger, Ric Bucher", "Discussing the 2011 NBA Finals");
            var itemA2 = GetFeedItem(feedA, "NBA Finals Preview Pt. 2", "Bill Simmons", "John Hollinger, Ric Bucher", "Discussing the 2011 NBA Finals");

            itemA2.AddMetadatum("text/plain", new Uri("http://example.com/schemes/random"), "RandomCode", "Octopus-Squid-Whale");
            itemA1.AddMetadatum("text/plain", new Uri("http://example.com/schemes/random"), "RandomCode", "W.X.Y-Z");

            repository.Save(new List<IFeed> { feedA, feedB, feedC, feedD, feedE });

            const string keyword1 = "WXYZ";
            var factory = new FeedFactory(context, logger);
            var search = new SearchByKeyword();
            var query = new Query<IFeed>(connection, logger, factory, search.GetFilter(keyword1));

            //const string format = "select {0}.* from {0} {1} where {2} order by Feed.Authors ASC, Feed.PublishedDate ASC, Feed.Title ASC;\r\n";
            //var text0 = string.Format(format, "Feed", SearchByKeyword.GetJoinClause(), SearchByKeyword.GetWhereClause());

            //var texts = query.GetCommandTexts();
            //Assert.IsNotNull(texts);
            //Assert.AreEqual(16, texts.Count());
            //Assert.AreEqual(text0, texts[0]);
            
            //var results = repository.SearchByKeyword("WXYZ");
            //Assert.AreEqual(1, results.Count());
        }

        #endregion
    }
}
