using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using SharedThings;

namespace SearchIndexer
{
    class Program
    {

        public class SearchBook
        {
            [System.ComponentModel.DataAnnotations.Key]
            public string Id { get; set; }

            [IsSearchable, IsSortable]
            public string Title { get; set; }

            [IsSearchable, IsSortable]
            public string Author { get; set; }


            [IsSearchable, IsSortable]
            [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
            public string Description { get; set; }


        }

        static string adminApiKey = "0326AE26E6E353EF0E8C75B43E5F99FE";
        static string searchServiceName = "mvc2bank";
        static string indexName = "bookdev";

        static void Main(string[] args)
        {

            SearchServiceClient serviceClient = CreateSearchServiceClient();

            //DeleteIndexIfExists(serviceClient);
            //CreateIndex(serviceClient);
            ISearchIndexClient indexClient = serviceClient.Indexes.GetClient(indexName);

            while (true)
            {
                var searchWord = Console.ReadLine();
                var parameters = new SearchParameters
                {
                    Select = new[] { "Id" },
                    IncludeTotalResultCount = true,
                    Skip = 0,
                    Top = 10,
                    OrderBy = new[] { "Title desc" },

                };
                var results = indexClient.Documents.Search<SearchBook>(searchWord, parameters);
                var ids = results.Results.Select(r => Convert.ToInt32(r.Document.Id));
                //_context.Suppliers.Where(ids.Contains(r => r.Id));
                Console.WriteLine(results.Count.Value);
            }

            //var actions = new List<IndexAction<SearchBook>>();

            //var bookRepository = new BookRepository();
            //foreach (var book in bookRepository.GetAll())
            //{
            //    actions.Add(new IndexAction<SearchBook>
            //    {
            //        ActionType = IndexActionType.Upload,
            //        Document = new SearchBook
            //        {
            //            Id = book.Id.ToString(),
            //            Author = book.Author,
            //            Title = book.Title,
            //            Description = book.Description
            //        }
            //    });
            //}
            //var batch = IndexBatch.New(actions);
            //indexClient.Documents.Index(batch);

            //Thread.Sleep(2000);

            //sökning- console.readline

            Console.WriteLine("Hello World!");
        }

        private static void CreateIndex(SearchServiceClient serviceClient)
        {
            var definition = new Microsoft.Azure.Search.Models.Index
            {

                Name = indexName,
                Fields = FieldBuilder.BuildForType<SearchBook>()
            };

            serviceClient.Indexes.Create(definition);
        }

        private static bool DeleteIndexIfExists(SearchServiceClient serviceClient)
        {
            if (serviceClient.Indexes.Exists(indexName))
            {
                serviceClient.Indexes.Delete(indexName);
                return true;
            }

            return false;
        }

        private static SearchServiceClient CreateSearchServiceClient()
        {
            var serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }
    }
}
