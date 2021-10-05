using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;

namespace ProjectAlza
{
    public class TestsAlza
    {
        RestClient client;
        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://webapi.alza.cz");
        }

        [Test]
        public void VerifyJobAttributes()
        {
            // Get endpoint objects
            var request = new RestRequest("/api/career/v2/positions/softwarovy-tester?country=cz", DataFormat.Json);
            var response = client.Get(request);
            var rootResponseContent = JsonConvert.DeserializeObject<Root>(response.Content);

            // Verify if position contains description
            Assert.IsNotEmpty(rootResponseContent.name, "Position name is missing.");
            Assert.IsNotEmpty(rootResponseContent.seoName, "Position seoName is missing.");
            Assert.IsNotEmpty(rootResponseContent.url, "Position url is missing.");

            // Print job placement
            Console.WriteLine("Job Address:");
            Console.WriteLine("Name: " + rootResponseContent.placeOfEmployment.name);
            Console.WriteLine("State: " + rootResponseContent.placeOfEmployment.state);
            Console.WriteLine("City: " + rootResponseContent.placeOfEmployment.city);
            Console.WriteLine("Street: " + rootResponseContent.placeOfEmployment.streetName);
            Console.WriteLine("Street: " + rootResponseContent.placeOfEmployment.postalCode);

            // Print interiview host info.
            var gestorUser = rootResponseContent.gestorUser.meta.href;
            var gestorUserDataRequest = new RestRequest(gestorUser, DataFormat.Json);
            var gestorUserDataResponse = client.Get(gestorUserDataRequest);
            var gestorUserDataRequestContent = Newtonsoft.Json.JsonConvert.DeserializeObject<GestorUserRoot>(gestorUserDataResponse.Content);
            Console.WriteLine("Interview Host:");
            Console.WriteLine("Host Name: " + gestorUserDataRequestContent.name);
            Assert.IsNotEmpty(gestorUserDataRequestContent.image, "Image is not available.");
            Console.WriteLine("Description: " + gestorUserDataRequestContent.description);

            // Print if the position is for students.
            Console.WriteLine("Availability For Students:");
            PositionAttributes.checkIfPositionIsForStudents(rootResponseContent.forStudents);
        }
    }
}