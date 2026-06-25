using CatalogModel.Models.TypeModels;
using CatalogModel.ServiceContract;
using CatalogRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService
{
    public class TypeService : ITypeService
    {
        private readonly TypeRepository _typeRepository;

        public TypeService(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public void CreateType(CreateTypeModel model)
        {
            if (model == null) throw new ArgumentNullException("Type Model is null");

            TypeModel typeModel = new TypeModel { 
                Id = Guid.NewGuid(),
                Name =model.Name,
            };

            this._typeRepository.TypesModels.Add(typeModel);
            this._typeRepository.SaveChanges();
        }

        public void DeleteTypeById(Guid Id)
        {
            if(Id == Guid.Empty)
            {
                throw new ArgumentNullException("Type Id is Empty");
            }
            TypeModel? typeModel = null;

            typeModel = this._typeRepository.TypesModels.Where(type => type.Id == Id).FirstOrDefault();

            if (typeModel == null)
            {
                throw new Exception("Type Model is not found");
            }

            this._typeRepository.TypesModels.Remove(typeModel);
            this._typeRepository.SaveChanges();


        }

        public TypeModel GetTypeById(Guid Id)
        {
            if (Id == Guid.Empty) throw new ArgumentNullException("Type Id is not empty");

            TypeModel? typeModel = null;

            typeModel = this._typeRepository.TypesModels.Where(type => type.Id == Id).FirstOrDefault();

            if (typeModel == null)
            {
                throw new Exception("Type Model is not found");
            }

            return typeModel;
        }

        public List<TypeModel> ListGetType()
        {
            List<TypeModel>? typemodel = null;
            typemodel =this._typeRepository.TypesModels.ToList();
            return typemodel;
        }

        public UpdateTypeModel EditType(Guid Id)
        {
            if (Id == Guid.Empty) throw new ArgumentNullException("Type Id is not empty");

            TypeModel? typeModel = null;

            typeModel = this._typeRepository.TypesModels.Where(type => type.Id == Id).FirstOrDefault();

            if (typeModel == null)
            {
                throw new Exception("Type Model is not found");
            }
            UpdateTypeModel updateTypeModel = new UpdateTypeModel
            {
                Id = typeModel.Id,
                Name = typeModel.Name,
            };

            return updateTypeModel;
        }

        public void UpdateType(UpdateTypeModel updateTypeModel)
        {
            if (updateTypeModel == null) throw new ArgumentNullException("Update Model is null");

            TypeModel typeModel = new TypeModel
            {
                Id = updateTypeModel.Id,
                Name = updateTypeModel.Name,
            };

            this._typeRepository.TypesModels.Update(typeModel);
            this._typeRepository.SaveChanges();
        }
    }
}
