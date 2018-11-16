using ClassLibrary.EntityFramework.Test;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ClassLibrary.EntityFramework.IntegrationTest
{
    [Collection("Collection 1")]
    public class ProductRepositoryIntegrationTest : ProductRepositoryUnitTestAsync
    {
        public ProductRepositoryIntegrationTest()
        {
            context = ContextFactory.SqlServerEcommerceContext;
        }
    }
}
