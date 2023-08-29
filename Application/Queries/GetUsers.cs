using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetUsers : IRequest<User>
    {
    }

    public class GetUsersHandler : IRequestHandler<GetUsers, User> {

        public GetUsersHandler()
        {
            //inyectar repositorio
        }

        public async Task<User> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            //re
            return new User
            {
                Id = 1,
                Name = "Test Name"
            };
        }
    }
}
