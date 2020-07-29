using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Users.Where(c => c.Candidates.Any(d => d.Acceleration.Name == name)).ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _context.Users.Where(c => c.Candidates.Any(d => d.CompanyId == companyId)).ToList();
        }

        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);
        }

        public User Save(User user)
        {
            if (user.Id == 0)
                _context.Users.Add(user);
            else
                _context.Attach(user);

            _context.SaveChanges();
            return user;

        }
    }
}
