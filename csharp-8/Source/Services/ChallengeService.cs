using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context.Challenges.Where(c => c.Accelerations.Any(d => d.Id == accelerationId) && c.Submissions.Any(d => d.UserId == userId)).ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
                _context.Challenges.Add(challenge);
            else
                _context.Attach(challenge);

            _context.SaveChanges();
            return challenge;
        }
    }
}