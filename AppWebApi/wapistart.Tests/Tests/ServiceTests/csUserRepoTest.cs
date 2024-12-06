// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using NSubstitute;
// using Models;
// using DbContext;
// using DbRepos;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace wapistart.Tests
// {
//     [TestClass]
//     public class csUserRepoTest
//     {
//         private csUserRepo _userRepo;
//         private csMainDbContext _mockContext;

//         [TestInitialize]
//         public void Setup()
//         {
//             var options = new DbContextOptionsBuilder<csMainDbContext>()
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Option;
            
//             _mockContext = Substitute.For<csMainDbContext>(options);
//             _userRepo = new csUserRepo(_mockContext);
//         }

//         [TestMethod]
//         public async Task GetTaskAsync_ShouldReturnUsers()
//         {
//             // Arrange
//             var users = new List<csUserDbM>
//             {
//                 new csUserDbM { UserId = Guid.NewGuid(), Email = "test@example.com", nameof = "Test User"}
//             };

//             var dbSet = Substitute.For<DbSet<csUserDbM>, IQueryable<csUserDbM>>();
//             ((IQueryable<csUserDbM>)dbSet).Provider.Returns(users.AsQueryable().Provider);
//             ((IQueryable<csUserDbM>)dbSet).Expression.Returns(users.AsQueryable().Expression);
//             ((IQueryable<csUserDbM>)dbSet).ElementType.Returns(users.AsQueryable().ElementType);
//             ((IQueryable<csUserDbM>)dbSet).GetEnumerator().Returns(users.AsQueryable().GetEnumerator());

//             _mockContext.Users.Returns(dbSet);

//             // Act
//             var result = await _userRepo.GetUsersAsync(1);

//             // Assert
//             Assert.AreEqual(users.Count, result.Count);
//             Assert.AreEqual(users[0].Email, result[0].Email);
            
//         }
//     }
// }