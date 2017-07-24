﻿using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BL
{
    public interface IBookService : IEntityService<BookViewModel>
    {
    }
}
