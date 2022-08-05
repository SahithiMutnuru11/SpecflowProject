Feature: LoginScenarios

@Login
Scenario: Verify User login with valid credentials
	Given I navigate to url - 'SwengLabs'
	Then I verify login page
	When I enter user credentials
	| userName      | password     |
	| standard_user | secret_sauce |
	Then I verify login successful

@Login
Scenario: Verify User login with invalid credentials
	Given I navigate to url - 'SwengLabs'
	Then I verify login page
	When I enter user credentials
	| userName      | password     |
	| standard_user | abcde123 |
	Then I Verify error message - 'Username and password do not match any user'