﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Genre { get; set; }
    }
}
