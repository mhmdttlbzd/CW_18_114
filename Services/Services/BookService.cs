using DataAccess.Interfaces;
using Domain.Enities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    internal class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BookService(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int id, string username, string password)
        {
            var user = _userRepository.GetBy(username, password);
            if (user != null)
            {
                var book = _bookRepository.GetById(id);
                if (book != null && book.OwnerId == user.Id)
                {
                    return book;
                }
            }
            return null;
        }
        public bool Edit(Book input, string userName, string Password)
        {
            var book = GetById(input.Id, userName, Password);
            if (book != null) {
                book.Name = input.Name;
                book.Genre = input.Genre;
                _bookRepository.Edit(book);
                return true;
            }
            return false;
        }



    }
}
