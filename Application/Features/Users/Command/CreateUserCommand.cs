using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Common;

namespace Application.Features.Users.Command
{
    public class CreateUserCommand : IRequest<ResponseEntity>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string CountryCode { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateUserCommand, ResponseEntity>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ResponseEntity> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                ResponseEntity result = new ResponseEntity();
                var user = new Domain.Entities.User();
                user.UID = Guid.NewGuid();
                user.Name = command.Name;
                user.Email = command.Email;
                user.MobileNo = command.MobileNo;
                user.CountryCode = command.CountryCode;
                user.UserRole = "Admin";
                user.CreateOn = DateTime.Now;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                result.Status = "0";
                result.Message = "";
                result.Data = user.UID;
                return result;
            }

            
        }
    }
}
