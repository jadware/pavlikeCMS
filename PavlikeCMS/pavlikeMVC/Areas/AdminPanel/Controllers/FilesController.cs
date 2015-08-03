using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pavlikeLibrary;
using pavlikeMVC.Areas.AdminPanel.Models;
using PavlikeDATA.Models;
using PavlikeDATA.Repos;
using static System.String;
using Enum = pavlikeLibrary.Enum;
using File = PavlikeDATA.Models.File;

namespace pavlikeMVC.Areas.AdminPanel.Controllers
{

    [Authorize]
    public class FilesController : Controller
    {
        readonly AlbumRepository _albumRepo = new AlbumRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GalleryIndex()
        {
            ViewBag.AlbumCount = new AlbumRepository().Count();
            ViewBag.MediaCount = new MediaRepository().Count();
            return View(new AlbumRepository().GetAll());
        }


        [HttpGet]
        public PartialViewResult _galleryCreate()
        {

            return PartialView(new Album());
        }

        [HttpPost]
        public int _galleryCreate(Album model)
        {

            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol Ediniz", Enum.ToastrType.Warning);

                return 0;
            }
            model.AuthorId = new AuthenticatedAuthor().Id;
            var res = new AlbumRepository().Create(model);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Album oluşturulurken hata", Enum.ToastrType.Error);
                return 0;
            }

            this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            return model.Id;

        }

        [HttpPost]
        public void AlbumMediaUpload(int albumId)
        {

            var file = Request.Files[0];

            if (!(file?.ContentLength > 0)) return;
            var res = FileSave(file, "Media", Enum.FileType.Media);
            if (res == null)
            {
                this.AddToastMessage("", "Dosya yüklenirken hata!");
                return;
            }
            var media = new Media
            {
                Active = true,
                AuthorId = new AuthenticatedAuthor().Id,
                CreateDateTime = DateTime.Now,
                FileId = res.Id,
                Title = res.Title

            };
            if (new MediaRepository().Create(media) == Enum.EntityResult.Success)
            {

                if (new AlbumMediaRepository().Create(new AlbumMedia { AlbumId = albumId, MediaId = media.Id }) !=
                    Enum.EntityResult.Success)
                {
                    this.AddToastMessage("", "Album kaydedilirken hata");
                }
            }
            else
            {
                this.AddToastMessage("", "Album kaydedilirken hata");
            }

        }

        [HttpGet]
        public PartialViewResult GalleryView(int id)
        {
            var item = new AlbumRepository().FindbyId(id);
            return PartialView(item);
        }

        [HttpPost]
        public void _galleryEdit(string baslik, int id)
        {
            var album = _albumRepo.FindbyId(id);
            album.Title = baslik;
            var res = _albumRepo.Update(album);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Album güncellenirken hata", Enum.ToastrType.Error);

            }
            else
            {
                this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            }



        }

        [HttpPost]
        public void _galleryDelete(int id)
        {
            var res = new AlbumRepository().FindbyIdandDisable(id);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Album silinirken hata", Enum.ToastrType.Error);

            }
            else
            {
                this.AddToastMessage("", "Album silme başarılı", Enum.ToastrType.Success);
            }
        }

        [HttpGet]
        public PartialViewResult _mediaEdit(int id)
        {
            return PartialView(new MediaRepository().FindbyId(id));
        }

        [HttpPost]
        public bool _mediaEdit(Media media)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol edniz", Enum.ToastrType.Warning);
                return false;
            }
            var res = new MediaRepository().Update(media);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Görsel kaydedilirken hata", Enum.ToastrType.Error);
                return false;
            }
            this.AddToastMessage("", "Görsel kaydedildi.", Enum.ToastrType.Success);
            return true;
        }
        [HttpPost]
        public bool _AlbumMediaDelete(int mediaId, int albumId)
        {
            var res = new AlbumMediaRepository().FindandDelete(mediaId, albumId);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Görsel silinirken hata", Enum.ToastrType.Error);
                return false;
            }
            this.AddToastMessage("", "Görsel silindi", Enum.ToastrType.Success);
            return true;
        }
        [HttpPost]
        public bool _AlbumMediaInsert(int[] medias, int albumId)
        {
            if (medias.Select(item => new AlbumMediaRepository().Create(new AlbumMedia {AlbumId = albumId, MediaId = item})).Any(res => res == Enum.EntityResult.Failed))
            {
                this.AddToastMessage("", "Görseller eklenirken hata!", Enum.ToastrType.Error);
                return false;
            }
            this.AddToastMessage("", "Görseller eklendi", Enum.ToastrType.Success);
            return true;
        }


        public ActionResult LibraryIndex()
        {
            return View();
        }


        public PartialViewResult _libraryList()
        {
            return PartialView(new AlbumRepository().GetAll());
        }

        [HttpGet]
        public PartialViewResult _libraryCreate()
        {

            return PartialView(new File());
        }

        [HttpPost]
        public bool _libraryCreate(File model)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol Ediniz", Enum.ToastrType.Warning);

                return false;
            }
            model.AuthorId = new AuthenticatedAuthor().Id;
            var res = new FileRepository().Create(model);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Dosya oluşturulurken hata", Enum.ToastrType.Error);
                return false;
            }

            this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            return true;

        }

        [HttpGet]
        public PartialViewResult _libraryEdit(int id)
        {
            var item = new FileRepository().FindbyId(id);
            return PartialView("_libraryCreate", item);
        }

        [HttpPost]
        public bool _libraryEdit(File modified)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol Ediniz", Enum.ToastrType.Warning);
                return false;
            }
            var res = new FileRepository().Update(modified);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Dosya güncellenirken hata", Enum.ToastrType.Error);
                return false;
            }

            this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            return true;
        }

        [HttpPost]
        public bool _libraryDelete(int id)
        {
            var res = new FileRepository().FindbyIdandDisable(id);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Dosya silinirken hata", Enum.ToastrType.Error);
                return false;
            }
            this.AddToastMessage("", "Dosya silme başarılı", Enum.ToastrType.Success);
            return true;
        }

        [HttpGet]
        public PartialViewResult _mediaList()
        {
            return PartialView(new MediaRepository().GetAll());
        }







        public ActionResult SliderIndex()
        {
            return View();
        }

        public PartialViewResult _sliderList()
        {
            return PartialView(new SliderRepository().GetAll());
        }

        [HttpGet]
        public PartialViewResult _sliderCreate()
        {

            return PartialView(new Slider());
        }

        [HttpPost]
        public bool _sliderCreate(Slider model)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol Ediniz", Enum.ToastrType.Warning);

                return false;
            }

            var res = new SliderRepository().Create(model);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Slider oluşturulurken hata", Enum.ToastrType.Error);
                return false;
            }

            this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            return true;

        }

        [HttpGet]
        public PartialViewResult _sliderEdit(int id)
        {
            var item = new SliderRepository().FindbyId(id);
            return PartialView("_sliderCreate", item);
        }

        [HttpPost]
        public bool _sliderEdit(Slider modified)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Alanları kontrol Ediniz", Enum.ToastrType.Warning);
                return false;
            }
            var res = new SliderRepository().Update(modified);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Slider güncellenirken hata", Enum.ToastrType.Error);
                return false;
            }

            this.AddToastMessage("", "Kayıt Başarılı", Enum.ToastrType.Success);
            return true;
        }

        [HttpPost]
        public bool _sliderDelete(int id)
        {
            var res = new SliderRepository().FindbyIdandDisable(id);
            if (res == Enum.EntityResult.Failed)
            {
                this.AddToastMessage("", "Slider silinirken hata", Enum.ToastrType.Error);
                return false;
            }
            this.AddToastMessage("", "Slider silme başarılı", Enum.ToastrType.Success);
            return true;
        }



        public File FileSave(HttpPostedFileBase file, string folder, Enum.FileType fileType)
        {
            string newFullPath = "";
            try
            {

                int count = 1;
                string fileNameOnly = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                var mappath = "~/Content/" + "Uploads/" + folder + "/";
                newFullPath = Path.Combine(mappath + fileNameOnly + extension);

                if (!Directory.Exists(Server.MapPath(mappath)))
                {
                    Directory.CreateDirectory(Server.MapPath(mappath));
                }

                while (System.IO.File.Exists(Server.MapPath(newFullPath)))
                {
                    string tempFileName = Format("{0}-{1}", fileNameOnly, count++);
                    newFullPath = Path.Combine(mappath, tempFileName + extension);
                }

                file.SaveAs(Server.MapPath(newFullPath));
                var uploadedFile = new File
                {
                    Active = true,
                    AuthorId = new AuthenticatedAuthor().Id,
                    Extension = extension,
                    FileType = fileType,
                    FileName = fileNameOnly,
                    Folder = folder,
                    Url = newFullPath,
                    UploadDateTime = DateTime.Now,
                    Title = fileNameOnly
                };

                return new FileRepository().Create(uploadedFile) == Enum.EntityResult.Failed ? null : uploadedFile;
            }
            catch (Exception)
            {
                System.IO.File.Delete(Server.MapPath(newFullPath));
                return null;
            }
        }

    }
}

