using System.Collections.Generic;
using System.Linq;

namespace SharedThings
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            return new[]
            {
                new Book{Id = 1, Title="Strategy Beyond the Hockey Stick",Price=12,  Author = "Chris Bradley", Description = "Beat the odds with a bold strategy from McKinsey & Company Every once in a while, a genuinely fresh approach to business strategy appears - legendary business professor from Canada and NHL "},
                new Book{Id = 2, Title="Total Hockey Training",Price=132,  Author = "Sean C Skahan", Description = "Achieve the best physical condition year-round with Total Hockey Training and be ready to dominate on the ice. In Total Hockey Training, Boston University"},
                new Book{Id = 3, Title="Hockey Anatomy",Price=11,  Author = "Michael Terry", Description = "Are you ready to see what it takes to lace up the skates? Hockey Anatomy will show you how to improve on-ice performance by increasing muscular strength "},
                new Book{Id = 4, Title="Physical preparation for Ice Hockey",Price=22,  Author = "Anthony Donskov", Description = "This book was written for both hockey player and coach. Hockey has been a passion of mine since early childhood. I was born and raised in Canada"},
                new Book{Id = 5, Title="Toronto Maple Leafs Hockey Club",Price=22,  Author = "Kevin Shea, Jason Wilson", Description = "Published in partnership with the Toronto Maple Leafs and officially licensed by the NHL, this is the one and only official Toronto Maple Leafs Centennial publicatio"},
                new Book{Id = 6, Title="2019 NHL Draft Black Book",Price=12,  Author = "HockeyProspect", Description = "Since 2012, our NHL Draft Black Book raised the standard for NHL Draft Publications, Canada. Our 2019 edition of the Black Book features more of the high end NHL Draft coverage you've come"},
            };
        }

        public Book Get(int id)
        {
            return GetAll().FirstOrDefault(r => r.Id == id);
        }
    }
}