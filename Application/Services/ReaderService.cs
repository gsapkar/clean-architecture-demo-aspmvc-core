using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.ViewModels.Reader;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ReaderService:IReaderService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IMapper _mapper;

        public ReaderService(IReaderRepository readerRepository, IMapper mapper)
        {
            _readerRepository = readerRepository;
            _mapper = mapper;
        }

        public ReaderListViewModel GetReaders()
        {
            var readersDto = _mapper.Map<IEnumerable<ReaderViewModel>>(_readerRepository.GetAll());
            return new ReaderListViewModel()
            {
                Readers = readersDto
            };
        }

        public ReaderViewModel GetReaderById(Guid id)
        {
            var readerVm = _mapper.Map<ReaderViewModel>(_readerRepository.GetById(id));

            return readerVm;
        }


        public ReaderViewModel AddReader(ReaderViewModel readerRequest)
        {
            var reader = _mapper.Map<Reader>(readerRequest);

            var addedReader = _readerRepository.Add(reader);

            return _mapper.Map<ReaderViewModel>(addedReader);
        }



        public void EditReader(ReaderViewModel readerRequest)
        {
            var Reader = _mapper.Map<Reader>(readerRequest);

            _readerRepository.Update(Reader);
        }

        public ReaderListViewModel SearchByFullName(string searchTerm)
        {
            var readersVm = new List<ReaderViewModel>();

            var readers = string.IsNullOrEmpty(searchTerm) ?
                _readerRepository.GetAll() : _readerRepository.SearchByFullName(searchTerm).ToList();
            if (readers != null && readers.Any())
            {
                readersVm = _mapper.Map<List<ReaderViewModel>>(readers);
            }

            return new ReaderListViewModel()
            {
                Readers = readersVm
            };
        }
    }
}
