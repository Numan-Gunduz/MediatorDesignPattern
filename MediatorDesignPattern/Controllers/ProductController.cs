using MediatorDesignPattern.MediatorPattern.Commands;
using MediatorDesignPattern.MediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDesignPattern.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
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
        public async Task<IActionResult>DeleteProduct(int id )
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id) 
        {
          var values = await _mediator.Send(new GetProductUpdateByIdQuery(id));
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
         return RedirectToAction("Index");  
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