//using Comrade.Core.AirplaneCore.Commands;
//using Comrade.Persistence.DataAccess;
//using Comrade.UnitTests.Tests.AirplaneTests.Bases;
//using Comrade.UnitTests.Tests.AirplaneTests.TestDatas;
//using Xunit;

//namespace Comrade.UnitTests.Tests.AirplaneTests;

//public sealed class UcAirplaneCreateTests
//{
//    [Theory]
//    [ClassData(typeof(AirplaneCreateTestData))]
//    public async Task UcAirplaneCreate_Test(int expected, AirplaneCreateCommand testObjectInput)
//    {
//        var options = new DbContextOptionsBuilder<ComradeContext>()
//            .UseInMemoryDatabase("test_database_UcAirplaneCreate_Test")
//            .EnableSensitiveDataLogging().Options;

//        await using var context = new ComradeContext(options);
//        await context.Database.EnsureCreatedAsync();

//        var airplaneCreate = UcAirplaneInjection.GetUcAirplaneCreate(context);
//        var result = await airplaneCreate.Execute(testObjectInput);

//        Assert.Equal(expected, result.Code);
//    }
//}

