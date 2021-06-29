using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Query
{
    public class GetAllUsersQuery : IRequest<ResponseEntity>
    {

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseEntity>
        {
            private readonly IApplicationDbContext _context;
            public GetAllUsersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ResponseEntity> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                ResponseEntity result = new ResponseEntity();
                var userList = await _context.Users.ToListAsync();
                if (userList == null)
                {
                    result.Status = "1";
                    result.Message = "No data found!";
                    result.Data = null;
                }
                else
                {
                    result.Status = "0";
                    result.Message = "";
                    result.Data = userList;
                }
                return result;
            }
        }
    }
}
