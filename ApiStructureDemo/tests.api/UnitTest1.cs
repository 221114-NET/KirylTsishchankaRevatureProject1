using BusinessLayer;
using ModelsLayer;
using RepoLayer;

namespace tests.api;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<Customer> list = bl.GetCustomerList();

        //Assert
         Assert.Equal(list[0].UserName, "m1");

    }

    [Fact]
    public void Test2()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<Customer> list = bl.GetCustomerList();

        //Assert
         Assert.Equal(list[0].UserPassword, "m1");

    }

    [Fact]
    public void Test3()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList2();

        //Assert
         Assert.Equal(list[0].FirstName, "m1");

    }

    [Fact]
    public void Test4()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList2();

        //Assert
         Assert.Equal(list[0].LastName, "m1");

    }

    [Fact]
    public void Test5()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList2();

        //Assert
         Assert.Equal(list[0].ETitle, "m1");

    }

    [Fact]
    public void Test6()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList2();

        //Assert
         Assert.Equal(list[0].RCategory, "m1");

    }

    [Fact]
    public void Test7()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList2();

        //Assert
         Assert.Equal(list[0].TotalAmount, 1);

    }

    [Fact]
    public void Test8()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList2();

        //Assert
         Assert.Equal(list[0].RDescription, "m1");

    }

    [Fact]
    public void Test9()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList2();

        //Assert
         Assert.Equal(list[0].RStatus, "m1");

    }

    [Fact]
    public void Test10()
    {
        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<ReimbursementForm> list = bl.GetCustomerList3();

        //Assert
         Assert.Equal(list[0].RStatus, "m1");

    }
}