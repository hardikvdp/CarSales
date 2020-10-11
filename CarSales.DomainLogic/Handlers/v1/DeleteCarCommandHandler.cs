using CarSales.Data.Models;
using CarSales.Data.Repository.v1;
using CarSales.Domain.Command.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarSales.DomainLogic.Handlers.v1
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, bool>
    {
        private IDataRepository<Car> CarRepository;

        public DeleteCarCommandHandler(IDataRepository<Car> CarRepository)
        {
            this.CarRepository = CarRepository;
        }
        public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid car id");
            }

            var resource = await CarRepository.DeleteAsync(Convert.ToInt32(request.Id));

            if (resource == null)
            {
                throw new KeyNotFoundException("Record not found.");
            }

            return true;
        }
    }
}
