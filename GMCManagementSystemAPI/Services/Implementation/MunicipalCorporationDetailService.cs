using AutoMapper;
using GMCManagementSystemAPI.Models;
using GMCManagementSystemAPI.Repository;
using GMCManagementSystemAPI.Services.Generic;
using GMCManagementSystemAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GMCManagementSystemAPI.Services
{
    public class MunicipalCorporationDetailService<T> : IGenericService<MunicipalCorporationDetailViewModel>
    {
      
        private readonly IMapper mapper;
        private IGenericRepository<MunicipalCorporationDetail> GenericRepository;

        public MunicipalCorporationDetailService(IMapper mapper,
            IGenericRepository<MunicipalCorporationDetail> genericRepository)
        {
          //  this.context = context;
            this.mapper = mapper;
            GenericRepository = genericRepository;


        }

        public MunicipalCorporationDetailViewModel Create(MunicipalCorporationDetailViewModel model)
        {
            var device =  mapper.Map<MunicipalCorporationDetailViewModel, MunicipalCorporationDetail>(model);
            var entity = GenericRepository.Create(device);
            //context.SaveChanges();
            return mapper.Map<MunicipalCorporationDetail,MunicipalCorporationDetailViewModel>(entity);
           
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MunicipalCorporationDetailViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MunicipalCorporationDetailViewModel>> GetAll(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MunicipalCorporationDetailViewModel>> GetAll(string include)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MunicipalCorporationDetailViewModel>> GetAllWithData(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MunicipalCorporationDetailViewModel>> GetByAny(int value)
        {
            throw new NotImplementedException();
        }

        public Task<MunicipalCorporationDetailViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MunicipalCorporationDetailViewModel> Update(MunicipalCorporationDetailViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
