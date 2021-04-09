Feature: Post Code Details

#Happy path test case
Scenario: User can get city details using a valid post code
Given I have created a request for a city in Country US
And I have created a request using post code 90210
When I send the Get City Details with Post Code request to the server
Then the returned response must contain the expected Post code
And the returned response must contain the expected Place name Beverly Hills
And the returned response must contain the expected Country United States

#Exception test using 1 valid request param.
Scenario: User must not get city details with an invalid country code
Given I have created a request for a city in Country GB
And I have created a request using post code 90210
When I send the Get City Details with Post Code request to the server
Then City Details must not be returned to the user

#Exception test using 1 valid request param.
Scenario: User must not get city details with an invalid post code
Given I have created a request for a city in Country GB
And I have created a request using post code 0000
When I send the Get City Details with Post Code request to the server
Then City Details must not be returned to the user

#Exception test wrong request param.
Scenario: The system responds without expections when both Country and Post code are invalid
Given I have created a request for a city in Country XXXXXXXX
And I have created a request using post code 000000000
When I send the Get City Details with Post Code request to the server
Then City Details must not be returned to the user