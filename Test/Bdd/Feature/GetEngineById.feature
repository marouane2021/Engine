Feature: GetEngineById
#

@EngineById
Scenario: Get Engine by Id	
	Given a Engine with the  Code 10 and request to EngineApi returns :
			| property      | value                           |
			| id			| 60633398527df471840ea894		  |
			| code			| 10							  |
			| name			| Billet3                         |
	When the Engine API receives the get request with Code 10
	Then the response status is "200"
	And the Engine API sends Engine information:
			| property      | value                           |
			| id			| 60633398527df471840ea894		  |
			| code			| 10							  |
			| name			| Billet3                         |
Scenario: Get Engine by Inexistant Id 
	Given a Engine with the Code 1600 and request to EngineApi returns :
		| property      | value                           |		
	When the Engine API receives the get request with Code 10
	Then the response status is "404"

