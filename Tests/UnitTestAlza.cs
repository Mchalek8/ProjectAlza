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
            RestRequest request = new RestRequest("/api/career/v2/positions/softwarovy-tester?country=cz", DataFormat.Json);
            IRestResponse response = client.Get(request);
            PositionRoot rootResponseContent = JsonConvert.DeserializeObject<PositionRoot>(response.Content);

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
            String gestorUser = rootResponseContent.gestorUser.meta.href;
            RestRequest gestorUserDataRequest = new RestRequest(gestorUser, DataFormat.Json);
            IRestResponse gestorUserDataResponse = client.Get(gestorUserDataRequest);
            GestorUserRoot gestorUserDataRequestContent = Newtonsoft.Json.JsonConvert.DeserializeObject<GestorUserRoot>(gestorUserDataResponse.Content);
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