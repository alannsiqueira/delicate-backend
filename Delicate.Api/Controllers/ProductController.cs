using System;
using System.Threading.Tasks;
using Delicate.Application.Interfaces;
using Delicate.Application.ViewModels;
using Delicate.Domain.Core.Bus;
using Delicate.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delicate.Api.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : ApiController
    {
        private readonly IProductAppService _service;

        public ProductController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IProductAppService service)
            : base(notifications, mediator)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Response(_service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_service.GetById(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductViewModel productViewModel)
        {
            _service.Update(productViewModel);
            return Response(productViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductViewModel productViewModel)
        {
            _service.Register(productViewModel);
            return Response(productViewModel);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            _service.Remove(id);
            return Response();
        }


    }
}