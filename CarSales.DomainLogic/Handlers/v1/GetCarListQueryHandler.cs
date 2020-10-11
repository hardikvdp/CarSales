using CarSales.Data.Models;
using CarSales.Data.Repository.v1;
using CarSales.Domain.Query.v1;
using CarSales.Domain.ViewModel.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarSales.DomainLogic.Handlers.v1
{
    public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, IEnumerable<CarDetail>>
    {
        public IDataRepository<Car> CarRepository { get; }

        public GetCarListQueryHandler(IDataRepository<Car> CarRepository)
        {
            this.CarRepository = CarRepository;
        }


        public async Task<IEnumerable<CarDetail>> Handle(GetCarListQuery request, CancellationToken cancellationToken)
        {
            var resource = await CarRepository.GetAllAsync();

            if (resource == null)
            {
                throw new KeyNotFoundException("Record not found.");
            }

            return resource.Select(x => new CarDetail()
            {
                Id = x.Id,
                Make = x.Make,
                Model = x.Model,
                Price = x.Price,
                Engine = x.Engine,
                Doors = x.Doors,
                Wheels = x.Wheels,
                BodyType = x.BodyType.BodyTypeName,
                VehicleType = x.VehicleType.VehicleTypeName
            });
        }
    }
}
