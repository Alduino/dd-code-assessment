using System;
using System.Linq;

namespace DDCA.NameSorter.Parser
{
    /// <summary>
    /// Parses a full name from a string in the format "(...space separated given names) (last name)"
    /// </summary>
    public class FullNameStringParser : IFullNameParser<string>
    {
        /// <summary>
        /// Parses a FullName where each part of the name is separated by spaces. A FullName has a last name, and
        /// between one and three given names.
        /// </summary>
        /// <param name="source">The source text to parse the full name. Should be trimmed and have a single space
        /// between parts.</param>
        /// <returns>A full name parsed from the string</returns>
        public IFullName Parse(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Full name cannot be empty or whitespace");
            }

            if (source.StartsWith(" "))
            {
                throw new ArgumentException("Spaces not allowed at beginning of full name");
            }

            if (source.EndsWith(" "))
            {
                throw new ArgumentException("Spaces not allowed at end of full name");
            }

            var parts = source.Split(' ');

            if (parts.Length < 2)
            {
                throw new ArgumentException("Not enough parts to construct full name");
            }

            if (parts.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Must not have extra spaces between parts");
            }

            var givenNames = parts.Take(parts.Length - 1).ToArray();

            if (givenNames.Length > 3)
            {
                throw new ArgumentException("Too many given names");
            }

            var lastName = parts.Last();

            return new FullName(lastName, givenNames);
        }
    }
}