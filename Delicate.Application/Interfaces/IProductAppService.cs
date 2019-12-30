using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Delicate.Application.Response;
using Delicate.Application.ViewModels;

namespace Delicate.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Register(ProductViewModel productViewModel);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
        void Update(ProductViewModel productViewModel);
        void Remove(Guid id);
    }
}