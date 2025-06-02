using AutoMapper;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper, ISubCategoryRepository subCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
        }

    }
}
