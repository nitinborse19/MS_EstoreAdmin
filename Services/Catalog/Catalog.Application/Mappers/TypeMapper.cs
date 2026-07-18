using Catalog.Application.DTOs.TypeDTOs;
using Catalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public static class TypeMapper
    {
        public static List<TypeDTO> ToTypeListMapper(this List<TypeModel> typeModels)
        {
            List<TypeDTO> typeDTOs = null;
            if (typeModels != null) 
            {
                typeDTOs = new List<TypeDTO>();
                foreach (TypeModel typeModel in typeModels) 
                {
                    typeDTOs.Add(ToTypeMapper(typeModel));
                }
            }
            return typeDTOs;
        }

        public static TypeDTO ToTypeMapper(this TypeModel typeModel)
        {
            TypeDTO? typeDTO = null;
            if(typeModel != null)
            {
                typeDTO = new TypeDTO
                (
                    typeModel.Id,
                    typeModel.Name
                );
            }
            return typeDTO;
        }
    }
}
