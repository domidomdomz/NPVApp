using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NPVApp.Business;
using NPVApp.Web;
using NPVApp.Web.Controllers;
using Newtonsoft.Json;

namespace NPVApp.Tests.Controllers
{
    [TestClass]
    public class CalculateNPVRequestsControllerTest
    {
        private Mock<ICalculateNPVRequestsLogic> _calculateNPVRequestsLogic;
        [TestInitialize]
        public void TestInit()
        {
            _calculateNPVRequestsLogic = new Mock<ICalculateNPVRequestsLogic>();
        }

        [TestMethod]
        public void ShouldReturnCalculateNPVRequestsSuccessfully()
        {
            //Arrange
            var mockResult = GetMockResult();

            _calculateNPVRequestsLogic.Setup(x => x.GetAllAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>()))
                .Returns(Task.FromResult(mockResult));

            var controller = new CalculateNPVRequestsController(_calculateNPVRequestsLogic.Object);

            //Act
            var calculateNPVRequests = controller.Get();
            var contentResult = calculateNPVRequests.Result as OkNegotiatedContentResult<IList<CalculateNPVRequest>>;


            //Assert
            Assert.IsNotNull(calculateNPVRequests);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(contentResult.Content, typeof(List<CalculateNPVRequest>));
        }

        [TestMethod]
        public void ShouldThrowBadRequestIfLogicThrowsException()
        {
            //Arrange
            _calculateNPVRequestsLogic.Setup(x => x.GetAllAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>()))
                .Throws(new System.Exception());

            var controller = new CalculateNPVRequestsController(_calculateNPVRequestsLogic.Object);

            //Act
            var calculateNPVRequests = controller.Get();
            var badRequestResult = calculateNPVRequests.Result as BadRequestWithErrorsResult;
            var responseMessage = badRequestResult.Execute();

            //Assert
            Assert.IsNotNull(badRequestResult);
            Assert.IsInstanceOfType(badRequestResult, typeof(BadRequestWithErrorsResult));
            Assert.AreEqual(responseMessage.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        #region ---- Private methods

        private IList<CalculateNPVRequest> GetMockResult()
        {
            var requests = new List<CalculateNPVRequest>();

            var cashFlows = new List<CashFlow>
            {
                new CashFlow{ RequestId = 1, CashFlowValue = 1000, CashFlowOrder = 1 },
                new CashFlow{ RequestId = 1, CashFlowValue = 1500, CashFlowOrder = 2 },
                new CashFlow{ RequestId = 1, CashFlowValue = 2000, CashFlowOrder = 3 }
            };

            requests.Add(new CalculateNPVRequest
            {
                Id = 1,
                InitialInvestment = 10000,
                LowerBoundDiscountRate = 0.01,
                UpperBoundDiscountRate = 0.015,
                DiscountRateIncrement = 0.0025,
                CashFlowsJSON = JsonConvert.SerializeObject(cashFlows)
            });

            return requests;
        }

        #endregion
    }
}
