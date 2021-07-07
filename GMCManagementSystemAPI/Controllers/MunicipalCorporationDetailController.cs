using GMCManagementSystemAPI.Services.Generic;
using GMCManagementSystemAPI.ViewModel;

namespace GMCManagementSystemAPI.Controllers
{


    public class MunicipalCorporationDetailController : BaseController<MunicipalCorporationDetailViewModel>
    {
        private readonly IGenericService<MunicipalCorporationDetailViewModel> Service;
        public MunicipalCorporationDetailController(IGenericService<MunicipalCorporationDetailViewModel> service) : base(service)
        {
            Service = service;
        }
        // [HttpGet("GetAll")]
        // //[Route("[action]")]
        //// [Route("api/MunicipalCorporationDetail/GetMunicipalCorporationDetail")]
        // public IEnumerable<MunicipalCorporationDetailService> GetMunicipalCorporationDetail()
        // {
        //     return MunicipalCorporationDetail.Get();
        // }
        // [HttpPost]
        // //[Route("[action]")]
        // //[Route("api/MunicipalCorporationDetail/AddMunicipalCorporationDetail")]
        // public MunicipalCorporationDetailService AddMunicipalCorporationDetail(MunicipalCorporationDetailService employee)
        // {
        //     return MunicipalCorporationDetail.Add(employee);
        // }
        // [HttpPut]
        //// [Route("[action]")]
        //// [Route("api/MunicipalCorporationDetail/EditMunicipalCorporationDetail")]
        // public MunicipalCorporationDetailService EditMunicipalCorporationDetail(MunicipalCorporationDetailService employee)
        // {
        //     return MunicipalCorporationDetail.Update(employee);
        // }
        // [HttpDelete("{id}")]
        // //[Route("[action]")]
        // //[Route("api/MunicipalCorporationDetail/DeleteMunicipalCorporationDetail")]
        // public MunicipalCorporationDetailService DeleteMunicipalCorporationDetail(int id)
        // {
        //     return MunicipalCorporationDetail.Delete(id);
        // }
        // [HttpGet ("{id}")]
        //// [Route("[action]")]
        //// [Route("api/MunicipalCorporationDetail/GetMunicipalCorporationDetailId")]
        // public MunicipalCorporationDetailService GetMunicipalCorporationDetailId(int id)
        // {
        //     return MunicipalCorporationDetail.GetById(id);
        // }
    }
}
