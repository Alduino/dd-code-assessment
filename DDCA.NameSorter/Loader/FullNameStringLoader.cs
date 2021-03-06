using System.Collections.Generic;
using System.Linq;
using DDCA.NameSorter.Parser;

namespace DDCA.NameSorter.Loader
{
    /// <summary>
    /// Loads full names from a file using the specified parser
    /// </summary>
    public class FullNameStringLoader : IFullNameLoader<string>
    {
        private readonly IFullNameParser<string> _parser;

        public FullNameStringLoader(IFullNameParser<string> parser)
        {
            _parser = parser;
        }

        public IEnumerable<IFullName> LoadFromLines(IEnumerable<string> lines) => lines.Select(line => _parser.Parse(line));
    }
}