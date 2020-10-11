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
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, bool>
    {
        private IDataRepository<Car> CarRepository;
        private IDataRepository<VehicleType> _vehicleTypeRepository;
        private IDataRepository<BodyType> _bodyTypeRepository;

        public UpdateCarCommandHandler(IDataRepository<Car> CarRepository, IDataRepository<VehicleType> vehicleTypeRepository, IDataRepository<BodyType> bodyTypeRepository)
        {
            this.CarRepository = CarRepository;
            this._vehicleTypeRepository = vehicleTypeRepository;
            this._bodyTypeRepository = bodyTypeRepository;
        }
        public async Task<bool> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
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

            var resource = await CarRepository.UpdateAsync(new Data.Models.Car()
            {
                Id = request.Id,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Engine = request.Engine,
                Doors = request.Doors,
                Wheels = request.Wheels,
                BodyTypeId = bodyType.Id,
                VehicleTypeId = vehicleType.Id,
                Modified = DateTime.Now
            });
           
            //EmailHelper.SendEmail("", "hr@hardiktest.com", "Car detail updated.", "Body Of the email");

            return true;

        }

        public void Validate(UpdateCarCommand request)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(request, null, null);
            Validator.TryValidateObject(request, context, results, true);
            if (results.Count > 0)
                throw new ArgumentException(string.Join(", ", results));
        }
    }
}
