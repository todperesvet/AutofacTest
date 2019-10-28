using AutofacTests.Interfaces;

namespace AutofacTests.Services
{
    public class Service : IService
    {
        public INestedService NestedService { get; set; }

        public bool NestedServiceIsNotNull()
        {
            return NestedService != null;
        }
    }
}
