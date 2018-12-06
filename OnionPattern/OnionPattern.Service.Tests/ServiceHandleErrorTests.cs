using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Errors;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.Service.Tests
{
    [TestClass]
    public class ServiceHandleErrorTests
    {
        private FakeServiceHandler serviceHandleError;

        [TestInitialize]
        public void TestInitialize()
        {
            serviceHandleError = new FakeServiceHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            serviceHandleError = null;
        }

        [TestMethod]
        public void DefaultStatusCode()
        {
            var fakeError = A.Fake<IError>();
            fakeError.StatusCode = null;

            var exception = new Exception(ExceptionsUtility.GenericMessage);

            serviceHandleError.TestHandlerErrors(fakeError, exception);

            fakeError.StatusCode.HasValue.Should().BeTrue();
            fakeError.StatusCode.Should().Be(500);
        }

        [TestMethod]
        public void SettingStatusCode()
        {
            const int STATUSCODE = 6969;

            var fakeError = A.Fake<IError>();
            fakeError.StatusCode = null;

            fakeError.StatusCode.HasValue.Should().BeFalse();

            serviceHandleError.TestHandlerErrors(fakeError, null, STATUSCODE);

            fakeError.StatusCode.HasValue.Should().BeTrue();
            fakeError.StatusCode.Value.Should().Be(STATUSCODE);

        }

        [TestMethod]
        public void DefaultValueWhenErrorResponseIsNull()
        {
            var fakeError = A.Fake<IError>();
            fakeError.ErrorResponse = null;

            serviceHandleError.TestHandlerErrors(fakeError, null);

            fakeError.ErrorResponse.Should().NotBeNull();
        }

        [TestMethod]
        public void ExceptionIsNullElvisOperator_ErrorSummary()
        {
            var fakeError = A.Fake<IError>();
            fakeError.ErrorResponse = new ErrorResponse();

            serviceHandleError.TestHandlerErrors(fakeError, null);

            fakeError.ErrorResponse.ErrorSummary.Should().BeNullOrWhiteSpace();
        }

        [TestMethod]
        public void ExceptionIsNullElvisOperator_InnerException()
        {
            var fakeError = A.Fake<IError>();
            fakeError.ErrorResponse = new ErrorResponse();

            serviceHandleError.TestHandlerErrors(fakeError, null);

            fakeError.ErrorResponse.InnerException.Should().BeNull();
        }

        [TestMethod]
        public void ExceptionMessageButNoInnerException()
        {
            var fakeError = A.Fake<IError>();
            var exception = new Exception(ExceptionsUtility.GenericMessage, null);

            serviceHandleError.TestHandlerErrors(fakeError, exception);

            fakeError.ErrorResponse.ErrorSummary.Should().Be(ExceptionsUtility.GenericMessage);
            fakeError.ErrorResponse.InnerException.Should().BeNull();
        }

        [TestMethod]
        public void ExceptionHasInnerException()
        {
            const string INNEREXCEPTIONMESSAGE = "InnerDude";
            var fakeError = A.Fake<IError>();
            var exception = new Exception(ExceptionsUtility.GenericMessage, new Exception(INNEREXCEPTIONMESSAGE));

            serviceHandleError.TestHandlerErrors(fakeError, exception);

            fakeError.ErrorResponse.ErrorSummary.Should().Be(ExceptionsUtility.GenericMessage);
            fakeError.ErrorResponse.InnerException.Should().NotBeNull();
            fakeError.ErrorResponse.InnerException.Message.Should().NotBeNullOrWhiteSpace();
            fakeError.ErrorResponse.InnerException.Message.Should().Be(INNEREXCEPTIONMESSAGE);
        }

        private class FakeServiceHandler : ServiceHandleError
        {
            public void TestHandlerErrors(IError error, Exception message, int statusCode = 500)
            {
                HandleErrors(error, message, statusCode);
            }
        }
    }
}
