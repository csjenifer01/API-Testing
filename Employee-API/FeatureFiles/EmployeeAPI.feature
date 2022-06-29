Feature: EmployeeAPI
	
@tag1
Scenario: To test whether the User is able to create new Employee using POST request
	When User enters the valid Url and the valid body for the POST request
	Then User should be able to create new Employee

Scenario: To validate the newly created Employee using GET request
	When User enters the valid Url for the GET request 
	Then User should be able to view the newly created Employee

Scenario: To check the details of all the Employees using GET request
	When User enters the valid Url for the GET request for Employee List Table
		|Url|
		|/employees|
	Then User should be able to view all Employees detail

Scenario: To delete the newly created Employee using DELETE request
	When User enters the valid Url for the DELETE request
	Then User should be able to delete newly created Employee