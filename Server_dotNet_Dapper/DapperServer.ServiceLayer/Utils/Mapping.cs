using AutoMapper;
using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.ServiceLayer.Utils
{
    public class Mapping
    {
        public static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => 
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                conf.CreateMap<RegisterRequest, AuthenticateResponse>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
