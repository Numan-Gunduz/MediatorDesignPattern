﻿using MediatR;

namespace MediatorDesignPattern.MediatorPattern.Commands
{
    public class RemoveProductCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveProductCommand(int id)
        {
            Id = id;
        }
    }
}
