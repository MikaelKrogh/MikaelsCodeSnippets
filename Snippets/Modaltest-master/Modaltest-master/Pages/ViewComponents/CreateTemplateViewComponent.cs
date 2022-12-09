using Microsoft.AspNetCore.Mvc;

namespace SUE.GameManager.Pages.ViewComponents
{
    public class CreateTemplateViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CreateTemplateComponent");
        }
    }
}
