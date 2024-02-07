namespace CompanyManagement.Application
{
    public interface ICompanyService
    {
        public string GetCompanyByName(string name);
        public List<string> GetCompanies();
    }
}
