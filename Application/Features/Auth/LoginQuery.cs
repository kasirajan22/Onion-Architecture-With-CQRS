using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Auth
{
    public class LoginQuery : IRequest<ResponseEntity>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string DeviceIP { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, ResponseEntity>
        {
            private readonly IApplicationDbContext _context;
            public LoginQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ResponseEntity> Handle(LoginQuery query, CancellationToken cancellationToken)
            {
                ResponseEntity result = new ResponseEntity();
                User user = _context.Users.Where(u => u.Email == query.Email && u.Password == query.Password && u.IsLocked != true && u.IsActive == true).FirstOrDefault();
                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    user.LoginAttempt = null;
                    _context.Users.Update(user);

                    List<UserSession> session = _context.UserSession.Where(s => s.UserUID == user.UID && s.EndsOn > DateTime.Now).ToList();
                    List<UserSession> updateSession = new List<UserSession>();
                    foreach (UserSession ses in session)
                    {
                        ses.EndsOn = DateTime.Now;
                        updateSession.Add(ses);
                    }

                    _context.UserSession.UpdateRange(updateSession);
                    result.Status = "0";
                    result.Message = "";
                    result.Data = _context.Users.Where(u => u.Email == query.Email && u.Password == query.Password && u.IsLocked != true && u.IsActive == true).FirstOrDefault();
                }
                else
                {

                }
                return result;
            }
        }
    }
}
