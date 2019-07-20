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
using Newtonsoft.Json;

namespace NPVApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for CalculateNPVResultsControllerTest
    /// </summary>
    [TestClass]
    public class CalculateNPVResultsControllerTest
    {
        private Mock<ICalculateNPVResultsLogic> _calculateNPVResultsLogic;
        [TestInitialize]
        public void TestInit()
        {
            _calculateNPVResultsLogic = new Mock<ICalculateNPVResultsLogic>();
        }

        [TestMethod]
        public void ShouldReturnCalculateNPVResultsSuccessfully()
        {
            //Arrange
            var mockResult = GetMockResult();

            _calculateNPVResultsLogic.Setup(x => x.GetByRequestId(It.IsAny<int>()))
                .Returns(Task.FromResult(mockResult));

            var controller = new CalculateNPVResultsController(_calculateNPVResultsLogic.Object);

            //Act
            var calculateNPVResults = controller.GetByRequestId(1);
            var contentResult = calculateNPVResults.Result as OkNegotiatedContentResult<IList<CalculateNPVResult>>;


            //Assert
            Assert.IsNotNull(calculateNPVResults);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(contentResult.Content, typeof(List<CalculateNPVResult>));
        }

        [TestMethod]
        public void ShouldThrowBadRequestIfLogicThrowsException()
        {
            //Arrange
            var mockResult = GetMockResult();

            _calculateNPVResultsLogic.Setup(x => x.GetByRequestId(It.IsAny<int>()))
                .Throws(new System.Exception());

            var controller = new CalculateNPVResultsController(_calculateNPVResultsLogic.Object);

            //Act
            var calculateNPVRequests = controller.GetByRequestId(1);
            var badRequestResult = calculateNPVRequests.Result as BadRequestWithErrorsResult;
            var responseMessage = badRequestResult.Execute();

            //Assert
            Assert.IsNotNull(badRequestResult);
            Assert.IsInstanceOfType(badRequestResult, typeof(BadRequestWithErrorsResult));
            Assert.AreEqual(responseMessage.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        #region Private Methods

        private IList<CalculateNPVResult> GetMockResult()
        {
            var requests = new List<CalculateNPVResult>();

            var cashFlows = new List<CashFlow>
            {
                new CashFlow{ RequestId = 1, CashFlowValue = 1000, CashFlowOrder = 1 },
                new CashFlow{ RequestId = 1, CashFlowValue = 1500, CashFlowOrder = 2 },
                new CashFlow{ RequestId = 1, CashFlowValue = 2000, CashFlowOrder = 3 }
            };

            requests.Add(new CalculateNPVResult
            {
                Id = 1,
                RequestId = 1,
                DiscountRate = 0.01,
                NetPresentValue = (decimal)-5598.28,
                CashFlowsJSON = JsonConvert.SerializeObject(cashFlows)
            });

            requests.Add(new CalculateNPVResult
            {
                Id = 2,
                RequestId = 1,
                DiscountRate = 0.0125,
                NetPresentValue = (decimal)-5622.32,
                CashFlowsJSON = JsonConvert.SerializeObject(cashFlows)
            });

            requests.Add(new CalculateNPVResult
            {
                Id = 2,
                RequestId = 1,
                DiscountRate = 0.0150,
                NetPresentValue = (decimal)-5646.15,
                CashFlowsJSON = JsonConvert.SerializeObject(cashFlows)
            });


            return requests;
        }

        #endregion
    }
}
