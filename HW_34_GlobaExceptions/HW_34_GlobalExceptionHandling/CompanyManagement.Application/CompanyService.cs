using CompanyManagement.Application.Exceptions;

namespace CompanyManagement.Application
{
    public class CompanyService : ICompanyService
    {
        private List<string> _companies = new List<string>() { "Tbc", "Bog", "Magti" };

        private Guid guid => Guid.NewGuid(); // აგენერირებს უნიკალურ სიქვენსს

        public CompanyService()
        {
            File.AppendAllText("DI.txt", " " + guid + " " + "New CompanyService instance has created " + Environment.NewLine);
        }

        public List<string> GetCompanies()
        {
            return _companies;
        }

        public string GetCompanyByName(string name)
        {
            var result = _companies.SingleOrDefault(x => x.Equals(name));
            if (result == null)
            {
                throw new CompanyNotFoundException("kompania ar moidzebna");
            }

            return result;
        }

    }
}

