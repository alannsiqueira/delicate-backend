using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Delicate.Application.Interfaces;
using Delicate.Application.Response;
using Delicate.Application.ViewModels;
using Delicate.Domain.Commands.Product;
using Delicate.Domain.CommandsHandler;
using Delicate.Domain.Core.Bus;
using Delicate.Domain.Core.Enums;
using Delicate.Domain.Interfaces;

namespace Delicate.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IMediatorHandler _bus;

        public ProductAppService(
            IMapper mapper,
            IMediatorHandler bus,
            IProductRepository repository)
        {
            _bus = bus;
            _mapper = mapper;
            _repository = repository;
        }

        public void Register(ProductViewModel productViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(productViewModel);

            _bus.SendCommand(registerCommand);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _repository.GetAll( )
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_repository.GetById(id));
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            _bus.SendCommand(updateCommand);
        }


        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}