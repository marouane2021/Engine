Feature: CreateEngine
@Engine
Scenario: Create Engine
	Given EngneApi a Engine with informations  :
			| property      | value                           |			
			| code			| 12							  |
			| name			| Billet32                         |
	When the API receives the post request 
	Then the response status is "200"
	And should return Id of the Engine
	
Scenario: Create Engine by an existant code
	Given a Engine with the an existant Code 2 a :
			| property      | value                           |			
			| code			| 2							      |
			| name			| Billet                        |
	When the Engine API receives the post request with  Code 2
	Then the response of the request is  status is "405"
	And  return the message "Engine Exist, try again "
Scenario: Create Engine with code 0
	Given a Engine with the Code : 0 :
			| property      | value                           |			
			| code			| 0								  |
			| name			| Billet                         |
	When the Engine API receives the post request with  Code 0
	Then the response of the request is  status is "405"
	And return the error message "Code not accepted, try again "


