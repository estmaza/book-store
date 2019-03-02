using AutoMapper;
using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BL
{
    public abstract class BusinessBase<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected readonly IMapper _mapper;

        public BusinessBase(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
