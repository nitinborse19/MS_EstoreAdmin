using CatalogModel.Models.TypeModels;
using CatalogModel.ServiceContract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace EStoreAdminSetup.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeservice;

        public TypeController(ITypeService typeService)
        {
            _typeservice = typeService;
        }
        [Route("ListTypes")]
        public IActionResult ListTypes()
        {
            List<TypeModel> types = null;

            types = this._typeservice.ListGetType();

            return View(types);
        }

        [HttpGet]
        [Route("CreateType")]
        public IActionResult CreateType()
        { 
            return View();
        }

        [HttpPost]
        [Route("CreateType")]
        public IActionResult CreateType(CreateTypeModel createTypeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createTypeModel);
            }
            this._typeservice.CreateType(createTypeModel);
            return RedirectToAction("ListTypes");
        }

        [HttpGet]
        [Route("DeleteType/{Id:Guid}")]
        public IActionResult DeleteType(Guid Id) 
        {
            if (Id == Guid.Empty) 
            {
                throw new ArgumentException("Type Id is Empty");
            }
            this._typeservice.DeleteTypeById(Id);
            return RedirectToAction("ListTypes");
        }

        [HttpGet]
        [Route("EditType{Id:Guid}")]
        public IActionResult EditType(Guid Id) 
        {
            if (Id == Guid.Empty) 
            {
                throw new ArgumentException("Type Id is Empty");
            }
            UpdateTypeModel  UpdateTypeModel = null;
            //typeModel = this._typeservice.GetTypeById(Id);
            UpdateTypeModel = this._typeservice.EditType(Id);
            return View(UpdateTypeModel);
        }

        [HttpPost]
        [Route("UpdateType")]
        public IActionResult UpdateType(UpdateTypeModel updateTypeModel)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            this._typeservice.UpdateType(updateTypeModel);
            return RedirectToAction("ListTypes");
        }
    }
}
