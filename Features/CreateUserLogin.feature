Feature: Create a user on automation exercise website

A short summary of the feature

@endToendTest
Scenario: Varify user is able to Create User account on automation exercise signup page
	Given User is on automation exercise home page
	When User click login link text
	And User enter the following signup details
		| Name     | Email                      |
		| TestUser | AuthoTest{0}@letMeIn.co.uk |
	And User click signup button
	Then User is on 'ENTER ACCOUNT INFORMATION' page
	When User click title 
	    And User enter password
	    And User enter date of birth
	    And user enter first name
	    And User enter last name
	    And User enter company
		And User enter first adress
	    And User enter second address
	    And User select country
	    And User enter state
	    And User enter city
	    And User enter zipCode
	    And User enter mobile
	    And User click create account button
	Then User should be presented with a pageheader 'ACCOUNT CREATED!'
	    And User should see a message 'Congratulations! Your new account has been successfully created!'
	When User click login link text
	Then User should see the user account name created 'TestUser'