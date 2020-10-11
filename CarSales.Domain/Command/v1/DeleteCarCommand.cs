using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales.Domain.Command.v1
{
    public class DeleteCarCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
