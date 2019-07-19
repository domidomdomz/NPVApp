using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NPVApp.Business;
using System.Threading.Tasks;
using NPVApp.Web.Controllers;
using System.Web.Http.Results;
using NPVApp.Web;

namespace NPVApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for CalculateController
    /// </summary>
    [TestClass]
    public class CalculateControllerTest
    {
        private Mock<ICalculationLogic> _calculationLogic;
        [TestInitialize]
        public void TestInit()
        {
            _calculationLogic = new Mock<ICalculationLogic>();
        }

        [TestMethod]
        public void ShouldDoCalculateNPVSuccessfully()
        {
            //Arrange
            var mockCalculateNPVRequest = GetMockRequest();
            var mockResultId = 1;

            _calculationLogic.Setup(x => x.ManageNPVCalculation(It.IsAny<CalculateNPVApiRequest>()))
                .Returns(Task.FromResult(mockResultId));

            var controller = new CalculateController(_calculationLogic.Object);

            //Act
            var requestId = controller.CalculateNPV(mockCalculateNPVRequest);
            var contentResult = requestId.Result as OkNegotiatedContentResult<int>;

            //Assert
            Assert.IsNotNull(requestId);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content, 1);
            Assert.IsInstanceOfType(contentResult.Content, typeof(int));
        }

        [TestMethod]
        public void ShouldThrowBadRequestIfLogicThrowsException()
        {
            //Arrange
            var mockCalculateNPVRequest = GetMockRequest();

            _calculationLogic.Setup(x => x.ManageNPVCalculation(It.IsAny<CalculateNPVApiRequest>()))
                .Throws(new System.Exception());

            var controller = new CalculateController(_calculationLogic.Object);

            //Act
            var requestId = controller.CalculateNPV(mockCalculateNPVRequest);
            var badRequestResult = requestId.Result as BadRequestWithErrorsResult;
            var responseMessage = badRequestResult.Execute();

            //Assert
            Assert.IsNotNull(badRequestResult);
            Assert.IsInstanceOfType(badRequestResult, typeof(BadRequestWithErrorsResult));
            Assert.AreEqual(responseMessage.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }


        private CalculateNPVApiRequest GetMockRequest()
        {
            var calculateNPVApiRequest = new CalculateNPVApiRequest
            {
                InitialInvestment = 500000,
                LowerBoundDiscountRate = 0.1,
                UpperBoundDiscountRate = 0.1,
                DiscountRateIncrement = 0.0,
                CashFlows = new List<double> { 200000.00, 300000.00, 200000.00 }
            };

            return calculateNPVApiRequest;
        }
    }
}
