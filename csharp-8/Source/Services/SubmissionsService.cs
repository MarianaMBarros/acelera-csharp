using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;

        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return _context.Submissions.Where(c => c.ChallengeId == challengeId && c.Challenge.Accelerations.Any(d => d.Id == accelerationId)).ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions
                .Where(c => c.ChallengeId == challengeId)
                .Select(c => c.Score)
                .OrderByDescending(c => c)
                .FirstOrDefault();
        }

        public Submission Save(Submission submission)
        {
            if (submission.UserId == 0 && submission.ChallengeId == 0)
                _context.Submissions.Add(submission);
            else
                _context.Attach(submission);

            _context.SaveChanges();
            return submission;
        }
    }
}
