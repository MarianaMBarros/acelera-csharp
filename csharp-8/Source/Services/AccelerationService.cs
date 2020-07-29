using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context.Accelerations.Where(c => c.Candidates.Any(d => d.CompanyId == companyId)).ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations.FirstOrDefault(c => c.Id == id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id == 0)
                _context.Accelerations.Add(acceleration);
            else
                _context.Attach(acceleration);

            _context.SaveChanges();
            return acceleration;
        }
    }
}
