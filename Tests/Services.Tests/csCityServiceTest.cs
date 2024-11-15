using Xunit;
using NSubstitute;
using Services;
using DbRepos;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Tests
{
    public class csCityServiceTests
    {
        private readonly csCityService _service;
        private readonly ICityRepo _repMock;

        public csCityServiceTests()
        {
            _repMock = Substitute.For<ICityRepo>();
            _service = new csCityService(_repMock);
        }

        [Fact]
        
        public async Task RandomCity_ReturnsListOfCities()
        {
            // Arrange
            var cities = new List<ICity>
            {
                Substitute.for<ICity>(),
                Substitute.for<ICity>()
            };
            _repMock.GetCities(Arg.Any<int>()).Returns(cities);

            // Act
            virtual result = await _service.RandomCity(2);

            // Assert
            Assert.Equal(2, result.Count);
        }
        
        
    }
}