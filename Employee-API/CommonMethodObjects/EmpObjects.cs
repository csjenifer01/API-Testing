using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Employee_API.CommonMethodObjects
{
    public class EmpObjects
    {
        public string baseUrl = "https://dummy.restapiexample.com/api/v1";
        public RestResponse response;
        public dynamic id;
        public string url = "";

        public void CreateEmployeePOSTRequest()
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("/create", Method.Post);
            request.AddBody("{\"name\":\"Joy\",\"salary\":123,\"age\":23}");
            response = client.Execute(request);
        }

        public void VerifyCreateEmployeePostResult()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            var value = deserializeAPI["data"]["name"];
            Assert.AreEqual("Joy", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            id = deserializeAPI["data"]["id"].Value;
            CreateTextFile();
        }

        public void CreateTextFile()
        {
            string filePath = @"C:\Users\mindtreejanedge225\Documents\Employee-API\Employee-API\EmployeeId.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (FileStream fs = File.Create(filePath))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text file");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Automation");
                    fs.Write(author, 0, author.Length);
                }

                using (StreamWriter sq = File.CreateText(filePath))
                {
                    sq.WriteLine(id);
                }
            }

            catch
            {

            }
        }

        public void ReadTextFile()
        {
            string filePath = @"C:\Users\mindtreejanedge225\Documents\Employee-API\Employee-API\EmployeeId.txt";

            using (StreamReader sr = File.OpenText(filePath))
            {
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    id = s;
                }
            }
        }

        public void GetEmployeeList()
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(url, Method.Get);
            response = client.Execute(request);
        }

        public void VerifyGetEmployeeListResult()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            var value = deserializeAPI.data[0].employee_name;
            Assert.AreEqual("Tiger Nixon", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void GetSpecificEmployee()
        {
            RestClient client = new RestClient(baseUrl);
            ReadTextFile();
            RestRequest request = new RestRequest("/employee/" + id, Method.Get);
            response = client.Execute(request);
        }

        public void VerifyGetEmployee()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            var value = deserializeAPI.status;
            Assert.AreEqual("success", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        public void DeleteCreatedEmployee()
        {
            RestClient client = new RestClient(baseUrl);
            ReadTextFile();
            RestRequest request = new RestRequest("/delete/" + id, Method.Delete);
            response = client.Execute(request);
        }

        public void VerifyEmployeeDeleted()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            var value = deserializeAPI.data;
            ReadTextFile();
            Assert.AreEqual(id, value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


    }
}
