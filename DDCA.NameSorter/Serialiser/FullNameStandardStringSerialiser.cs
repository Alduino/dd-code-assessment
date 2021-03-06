namespace DDCA.NameSorter.Serialiser
{
    /// <summary>
    /// Serialises a full name into a string of the format "(given names) (last name)" in the same case as given
    /// </summary>
    public class FullNameStandardStringSerialiser : IFullNameSerialiser<string>
    {
        public string Serialise(IFullName fullName)
        {
            var givenNames = string.Join(' ', fullName.GivenNames);
            return $"{givenNames} {fullName.LastName}";
        }
    }
}