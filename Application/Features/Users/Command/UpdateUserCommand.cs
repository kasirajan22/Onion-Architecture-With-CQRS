using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using System.Linq;
using Domain.Common;

namespace Application.Features.Users.Command
{
    public class UpdateUserCommand : IRequest<ResponseEntity>
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string CountryCode { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<UpdateUserCommand, ResponseEntity>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ResponseEntity> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                ResponseEntity result = new ResponseEntity();
                var user = _context.Users.Where(u => u.UID == command.UID).FirstOrDefault();
                if (user != null)
                {
                    user.Name = command.Name;
                    user.Email = command.Email;
                    user.MobileNo = command.MobileNo;
                    user.CountryCode = command.CountryCode;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    result.Status = "0";
                    result.Message = "";
                    result.Data = command.UID;
                }
                else
                {
                    result.Status = "1";
                    result.Message = "User not found.";
                    result.Data = null;
                }
                return result;
            }
        }
    }
}
