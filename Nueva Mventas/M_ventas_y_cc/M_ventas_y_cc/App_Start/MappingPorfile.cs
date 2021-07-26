using AutoMapper;
using M_ventas_y_cc.Models;
using M_ventas_y_cc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_ventas_y_cc.App_Start
{
    public class MappingPorfile:  Profile
    {
        public MappingPorfile()
        {
            Mapper.CreateMap<ENCARGADO, ENCARGADOVM>();
        }
    }
}