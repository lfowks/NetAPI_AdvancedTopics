using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddUser : IRequest<User> 
    {
        public string Name { get; set; }
    }

    public class AddUserHandler : IRequestHandler<AddUser, User>
    {
        //private IRepository _myRepository;
        //AddUserHandler(IRepository myRepository)
        //{
        //    _myRepository = myRepository;
        //}

        public async Task<User> Handle(AddUser request, CancellationToken cancellationToken)
        {
            User user = new User();
            user.Id = 1;
            user.Name = request.Name;

           // _myRepository.Add(user);

            return user;
        }
    }
}
