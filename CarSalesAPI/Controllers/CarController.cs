using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using CarSales.Domain.Command.v1;
using CarSales.Domain.Query.v1;
using CarSales.Domain.ViewModel.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private IMediator _mediator;

        public CarController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// This will get list of all Cars.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ApiResponse> GetAllCars()
        {
            try
            {
                var response = await _mediator.Send(new GetCarListQuery() { });
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, ex);
            }
        }

        /// <summary>
        /// This will Car details via passing Car Id.
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{CarId}")]
        public async Task<ApiResponse> GetCarById(int CarId)
        {
            try
            {
                var response = await _mediator.Send(new GetCarByIdQuery() { CarId = CarId });
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, ex);
            }
        }

        /// <summary>
        /// This will add car record. 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<ApiResponse> SaveCar(AddCarCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, 400);
            }

        }

        /// <summary>
        /// This will add car record. 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public async Task<ApiResponse> UpdateCar(UpdateCarCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, 400);
            }

        }


        [HttpDelete]
        [Route("Delete/{CarId}")]
        public async Task<ApiResponse> DeleteCar(int CarId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteCarCommand() { Id = CarId });
                return new ApiResponse(response, 201);
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, ex);
            }

        }

    }
}
