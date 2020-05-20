using System.Collections.Generic;

namespace SharedThings
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);

    }
}