using Xunit;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.EntityFramework.Test;

namespace ClassLibrary.EntityFramework.IntegrationTest
{
    [Collection("Collection 1")]
    public class OrderRepositoryIntegrationTest : OrderRepositoryUnitTest
    {
        public OrderRepositoryIntegrationTest()
        {
            context = ContextFactory.SqlServerEcommerceContext;
        }
    }
}

