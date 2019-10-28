using AutofacTests.Interfaces;

namespace AutofacTests.Services
{
    public class ServiceDecorator : IService
    {
        private readonly IService _original;

        public ServiceDecorator(IService original)
        {
            _original = original;
        }

        public bool NestedServiceIsNotNull()
        {
            return _original.NestedServiceIsNotNull();
        }
    }
}
