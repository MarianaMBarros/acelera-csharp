using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly ScriptsContext _context;
        private readonly IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var quotes = _context.Quotes.ToList();
            var randonQuote = _randomService.RandomInteger(quotes.Count);
            return quotes[randonQuote];
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotes = _context.Quotes.
               Where(x => x.Actor == actor).
               ToList();

            if (quotes.Count == 0)
                return null;

            var randonQuote = _randomService.RandomInteger(quotes.Count);
            return quotes[randonQuote];
        }
    }
}