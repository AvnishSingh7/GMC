using AutoMapper.Configuration;
using GMCManagementSystemAPI.Models;
using GMCManagementSystemAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMCManagementSystemAPI.Mappings
{
    /// <summary>
    /// Contains objects mapping
    /// </summary>
    /// <seealso cref="MapperConfigurationExpression" />
    public class MapsProfile : MapperConfigurationExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapsProfile"/> class
        /// </summary>
        public MapsProfile()
        {
           
            // DeviceViewModel To Device and its reverse from Device To DeviceViewModel
            CreateMap<MunicipalCorporationDetailViewModel, MunicipalCorporationDetail>().ReverseMap();
            
        }
    }
}
