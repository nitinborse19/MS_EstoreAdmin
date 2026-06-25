using CatalogModel.Models.TypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogModel.ServiceContract
{
    public interface ITypeService
    {
        List<TypeModel> ListGetType();

        void CreateType(CreateTypeModel model);

        TypeModel GetTypeById(Guid Id);

        void DeleteTypeById(Guid Id);

        UpdateTypeModel EditType(Guid Id);

        void UpdateType(UpdateTypeModel model);
    }
}
