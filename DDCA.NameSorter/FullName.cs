namespace DDCA.NameSorter
{
    /// <summary>
    /// Simple data-only full name implementation
    /// </summary>
    public class FullName : IFullName
    {
        public FullName(string lastName, string firstName) : this(lastName, new[] { firstName })
        {
        }

        public FullName(string lastName, string[] givenNames)
        {
            LastName = lastName;
            GivenNames = givenNames;
        }

        public string LastName { get; }
        public string[] GivenNames { get; }
    }
}