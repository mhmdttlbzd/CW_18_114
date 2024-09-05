using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookService
    {
        bool Edit(Book input, string userName, string Password);
        Book GetById(int id, string username, string password);
        List<Book> GetAll();
    }
}
