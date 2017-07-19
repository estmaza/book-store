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
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;

        public BusinessBase(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
