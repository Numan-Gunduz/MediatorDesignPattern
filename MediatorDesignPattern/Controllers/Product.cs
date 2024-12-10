﻿using MediatorDesignPattern.MediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDesignPattern.Controllers
{
    public class Product : Controller
    {
        private readonly IMediator _mediator;

        public Product(IMediator mediator)
        {
            _mediator = mediator;
        }

        public  async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllProductQuery());
            
            return View(values);
        }
        public  async Task<IActionResult>GetProduct(int id)
        {
            var values = await _mediator.Send(new GetProductByIdQuery(id));
            return View(values);
        }
    }
}
/*
 * Entity Framework Core'da, Change Tracker mekanizması vardır. Yani entity'ler ve property'ler
 * üzerinde uygulanan değişikliklerin veri tabanına, doğru bir şekilde uygulanıp uygulanmadığının
 * takibini/kontrolünü yapan mekanizmadır. Veritabanında yapılan sorgulama durumunda sonucun change tracker 
 * mekanizması tarafından izlenmesini kırıyor. Bu da belleğimizi gereksiz yüklerden kurtarıyor,
 * performans sağlıyor. Veri tabanında ekleme güncelleme silme işlemi yapmayacaksak 
 * yani veri üzerinde yalnızca okuma işlemi yapacaksak AsNoTracking metodu kullanımı önerilir.
 */