using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;

namespace Wunderlist.Tests
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            // Arrange
            //var mock = new Mock<IRepository<UserDalEntity>>();
            //mock.Setup(a => a.GetAll()).Returns(new List<UserDalEntity>()
            //{
            //    new UserDalEntity(1),
            //    new UserDalEntity(2)
            //});
        }
    }
}
