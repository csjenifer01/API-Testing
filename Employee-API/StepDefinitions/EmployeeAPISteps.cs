using Employee_API.CommonMethodObjects;
using System;
using TechTalk.SpecFlow;

namespace Employee_API.StepDefinitions
{
    [Binding]
    public class EmployeeAPISteps
    {
        EmpObjects obj = new EmpObjects();

        [When(@"User enters the valid Url and the valid body for the POST request")]
        public void WhenUserEntersTheValidUrlAndTheValidBodyForThePOSTRequest()
        {
            obj.CreateEmployeePOSTRequest();
        }

        [Then(@"User should be able to create new Employee")]
        public void ThenUserShouldBeAbleToCreateNewEmployee()
        {
            obj.VerifyCreateEmployeePostResult();
        }

        [When(@"User enters the valid Url for the GET request")]
        public void WhenUserEntersTheValidUrlForTheGETRequest()
        {
            obj.GetSpecificEmployee();
        }

        [Then(@"User should be able to view the newly created Employee")]
        public void ThenUserShouldBeAbleToViewTheNewlyCreatedEmployee()
        {
            obj.VerifyGetEmployee();
        }

        [When(@"User enters the valid Url for the GET request for Employee List Table")]
        public void WhenUserEntersTheValidUrlForTheGETRequestForEmployeeListTable()
        {
            obj.GetEmployeeList();
        }


        [Then(@"User should be able to view all Employees detail")]
        public void ThenUserShouldBeAbleToViewAllEmployeesDetail()
        {
            obj.VerifyGetEmployeeListResult();
        }

        [When(@"User enters the valid Url for the DELETE request")]
        public void WhenUserEntersTheValidUrlForTheDELETERequest()
        {
            obj.DeleteCreatedEmployee();
        }

        [Then(@"User should be able to delete newly created Employee")]
        public void ThenUserShouldBeAbleToDeleteNewlyCreatedEmployee()
        {
            obj.VerifyEmployeeDeleted();
        }
    }
}

