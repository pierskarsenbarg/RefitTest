using NUnit.Framework;
using Refit;

namespace RefitTest
{
    [TestFixture]
    public class ApiTest
    {
        private IApi _api;
        private IApiService _service;

        [SetUp]
        public void Setup()
        {
            _api = RestService.For<IApi>("http://localhost:62675/");
            _service = new ApiService(_api);
        }

        [Test]
        public async void RunOnceIsFine()
        {
            var value = await _service.GetHeaderAsync("foobar");
            Assert.AreEqual("foobar", value);
        }
        
        [Test]
        public void RunHttpClient()
        {
            var value = _service.GetHeader("foobar");
            Assert.AreEqual("foobar", value);
        }

        [Test]
        public async void RunMoreThanOnceIsntFine()
        {
            var value = await _service.GetHeaderAsync("foobar");
            var anotherValue = _service.GetHeader("foobar");
            var otherValue = await _service.GetHeaderAsync("foobar");


            Assert.AreEqual("foobar", otherValue);
            Assert.AreEqual("foobar", anotherValue);
            Assert.AreEqual("foobar", value);
        }
    }
}
