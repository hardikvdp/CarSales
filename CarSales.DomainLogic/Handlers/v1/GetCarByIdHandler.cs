using CarSales.Data.Models;
using CarSales.Data.Repository.v1;
using CarSales.Domain.Query;
using CarSales.Domain.Query.v1;
using CarSales.Domain.ViewModel;
using CarSales.Domain.ViewModel.v1;
using CarSales.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarSales.DomainLogic.Handlers.v1
{
    public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, CarDetail>
    {
        private IDataRepository<Car> CarRepository;

        public GetCarByIdHandler(IDataRepository<Car> CarRepository)
        {
            this.CarRepository = CarRepository;
        }

        public async Task<CarDetail> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            if (!request.CarId.HasValue)
            {
                throw new ArgumentException("Car id is required field");
            }

            var resource = await CarRepository.GetAsync(request.CarId.Value);

            if (resource == null)
            {
                throw new KeyNotFoundException("Record not found.");
            }

            // We can use AutoMapper here to map the entities.
            return new CarDetail()
            {
                Id = resource.Id,
                Make = resource.Make,
                Model = resource.Model,
                Engine = resource.Engine,
                Doors = resource.Doors,
                Wheels = resource.Wheels,
                Created = resource.Created,
                Price = resource.Price,
                BodyType = resource.BodyType.BodyTypeName,
                VehicleType = resource.VehicleType.VehicleTypeName
            };
        }
    }
}
