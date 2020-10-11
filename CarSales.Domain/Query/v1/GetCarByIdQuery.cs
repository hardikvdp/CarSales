using CarSales.Domain.ViewModel;
using CarSales.Domain.ViewModel.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Domain.Query.v1
{
    public class GetCarByIdQuery : IRequest<CarDetail>
    {
        public int? CarId { get; set; }
    }
}
