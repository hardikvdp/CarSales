using CarSales.Data.Models;
using CarSales.Data.Repository.v1;
using CarSales.Domain.Command.v1;
using CarSales.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarSales.DomainLogic.Handlers.v1
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, bool>
    {
        private IDataRepository<Car> _carRepository;
        private IDataRepository<VehicleType> _vehicleTypeRepository;
        private IDataRepository<BodyType> _bodyTypeRepository;

        public AddCarCommandHandler(IDataRepository<Car> carRepository, IDataRepository<VehicleType> vehicleTypeRepository, IDataRepository<BodyType> bodyTypeRepository)
        {
            this._carRepository = carRepository;
            this._vehicleTypeRepository = vehicleTypeRepository;
            this._bodyTypeRepository = bodyTypeRepository;
        }
        public async Task<bool> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var vehicleType = await _vehicleTypeRepository.GetByNameAsync(request.VehicleType);

            if (vehicleType == null)
            {
                throw new Exception("Vehicle type not found.");
            }

            var bodyType = await _bodyTypeRepository.GetByNameAsync(request.BodyType);

            if (bodyType == null)
            {
                throw new Exception("Body type not found.");
            }

            var resource = await _carRepository.AddAsync(new Data.Models.Car()
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Engine = request.Engine,
                Doors = request.Doors,
                BodyTypeId = bodyType.Id,
                VehicleTypeId = vehicleType.Id,
                Created = DateTime.Now
            });

            //EmailHelper.SendEmail("", "hr@hardiktest.com", "Car details added successfully", "Body Of the email");

            return true;

        }

        public void Validate(AddCarCommand request)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(request, null, null);
            Validator.TryValidateObject(request, context, results, true);
            if (results.Count > 0)
                throw new ArgumentException(string.Join(", ", results));
        }
    }
}
