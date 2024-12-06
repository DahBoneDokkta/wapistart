// using NSubstitute;
// using Services;
// using DbRepos;
// using Models;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Logging.Abstractions;
// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace Services.Tests
// {
//     [TestClass]
//     public class csCityServiceTests
//     {
//         private readonly csCityService _service;
//         private readonly ICityRepo _repMock;

//         [TestInitialize]
//         public void Setup()

//         public csCityServiceTests()
//         {
//             _repMock = Substitute.For<ICityRepo>();
//             _service = new csCityService(_repMock);
//         }

//         [TestMethod]
        
//         public async Task RandomCity_ReturnsListOfCities()
//         {
//             // Arrange
//             var cities = new List<ICity>
//             {
//                 Substitute.for<ICity>(),
//                 Substitute.for<ICity>()
//             };
//             _repMock.GetCities(Arg.Any<int>()).Returns(cities);

//             // Act
//             var result = await _service.RandomCity(2);

//             // Assert
//             Assert.AreEqual(2, result.Count);
//         }
        
        
//     }
// }