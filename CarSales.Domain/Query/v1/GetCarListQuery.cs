using CarSales.Domain.ViewModel;
using CarSales.Domain.ViewModel.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Domain.Query.v1
{
   public class GetCarListQuery : IRequest<IEnumerable<CarDetail>>
    {
        //public int PageIndex { get; set; } = 1;
        //public int PageSize { get; set; } = 10;
    }
}
