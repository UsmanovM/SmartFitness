using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        /*[TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange (Объявление)
            var userName = Guid.NewGuid().ToString();

            // Act (Действие)
            var controller = new UserController(userName);

            // Assert (Утверждение)
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}