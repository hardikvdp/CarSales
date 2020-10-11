using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarSalesAPI.Controllers;
using Xunit;
using CarSalesAPI.Controllers.v1;
using CarSales.Domain.Command.v1;
using CarSales.Domain.Query.v1;
using CarSales.Domain.ViewModel.v1;

namespace CarSalesAPI.Test.Controllers
{
    public class CarControllerTests
    {
        private readonly CarController _testee;
        private readonly IMediator _mediator;

        public CarControllerTests()
        {
            _mediator = A.Fake<IMediator>();
            _testee = new CarController(_mediator);

            var carLists = new List<CarDetail>
            {
                new CarDetail
                {
                      Id= 1,
                      Make= "Toyota",
                      Model= "Camry",
                      Engine= "AUTO",
                      Price= 25000,
                      Doors= 4,
                      Wheels= 4,
                      BodyType= "SEDAN",
                      VehicleType= "Car"
                },
                new CarDetail
                {
                      Id= 1,
                      Make= "Toyota",
                      Model= "Camry",
                      Engine= "AUTO",
                      Price= 25000,
                      Doors= 4,
                      Wheels= 4,
                      BodyType= "SEDAN",
                      VehicleType= "Car"
                }
            };

            A.CallTo(() => _mediator.Send(A<AddCarCommand>._, A<CancellationToken>._)).Returns(true);
            A.CallTo(() => _mediator.Send(A<UpdateCarCommand>._, A<CancellationToken>._)).Returns(true);
            A.CallTo(() => _mediator.Send(A<DeleteCarCommand>._, A<CancellationToken>._)).Returns(true);
            A.CallTo(() => _mediator.Send(A<GetCarByIdQuery>._, A<CancellationToken>._)).Returns(carLists.FirstOrDefault());
            A.CallTo(() => _mediator.Send(A<GetCarListQuery>._, A<CancellationToken>._)).Returns(carLists);
        }
    }
}
