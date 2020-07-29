using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context.Companies.Where(c => c.Candidates.Any(d => d.AccelerationId == accelerationId)).ToList();
        }

        public Company FindById(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context.Companies.Where(c => c.Candidates.Any(d => d.UserId == userId)).ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id == 0)
                _context.Companies.Add(company);
            else
                _context.Attach(company);

            _context.SaveChanges();
            return company;
        }
    }
}