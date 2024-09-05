using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        void Edit(Book input);


    }
}
