using AutoApplication.DataLibrary.BusinessLogic.AutoBusinessLogic;
using AutoApplication.DataLibrary.Model;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutoApplication.Tests.Controllers
{
    public class AutoControllerTest
    {
        [Fact]
        public void GetAllAutoCollection_ShouldWork()
        {
            // Arrange
            IList<Auto> _autos = A.CollectionOfFake<Auto>(2);
            var mockAutoManager = A.Fake<IAutoDataProcessor>();

            // Act
            A.CallTo(() => mockAutoManager.LoadAutos()).Returns(_autos);

            // Assert
            Assert.Equal(2, mockAutoManager.LoadAutos().Count);
        }
    }
}
