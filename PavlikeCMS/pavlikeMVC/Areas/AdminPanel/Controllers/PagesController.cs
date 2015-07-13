using System.Web.Mvc;
using pavlikeLibrary;
using pavlikeMVC.Areas.AdminPanel.Models;
using PavlikeDATA.Models;
using PavlikeDATA.Repos;

namespace pavlikeMVC.Areas.AdminPanel.Controllers
{
    public class PagesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PageList()
        {
            return PartialView(new PageRepository().GetAll());
        }

        [HttpGet]
        public PartialViewResult _Create()
        {
            return PartialView(new Page());
        }

        [HttpPost]
        public ActionResult _Create(Page model)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol Ediniz", Enum.ToastrType.Warning);
                return PartialView(model);
            }
            model.Author = new AuthenticatedAuthor().Author;
            var res = new PageRepository().Create(model);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Sayfa oluşturulurken hata", Enum.ToastrType.Error);
                return PartialView(model);
            }

            this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            return RedirectToActionPermanent("Index");

        }

        [HttpGet]
        public PartialViewResult _Edit(int id)
        {
            return PartialView("_Create", new PageRepository().FindbyId(id));
        }

        [HttpPost]
        public ActionResult _Edit(Page modified)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol Ediniz", Enum.ToastrType.Warning);
                return PartialView("_Create", modified);
            }
            var res = new PageRepository().Update(modified);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Sayfa güncellenirken hata", Enum.ToastrType.Error);
                return PartialView("_Create", modified);
            }

            this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            return RedirectToActionPermanent("Index");
        }

        [HttpGet]
        public ActionResult Preview(int id)
        {
            return View(new PageRepository().FindbyId(id));
        }
    }
}
