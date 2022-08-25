﻿using System;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.RoleTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.RoleIntegrationTests;

public class RoleControllerGetAllPaginatedTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public RoleControllerGetAllPaginatedTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task RoleController_GetAll_Paginated()
    {
        var RoleController =
            RoleInjectionController.GetRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var paginationQuery = new PaginationQuery();
        var result = await RoleController.GetAll(paginationQuery);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as PageResultDto<RoleDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
            Assert.NotNull(actualResultValue?.Data);
            Assert.Equal(1, actualResultValue?.Data?.Count);
        }
    }
}