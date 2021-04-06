Feature: UpdateEngineById
#

@EngineById
Scenario: Update Engine by Id	
	Given a Api with the  Code : 10 and request to EngineApi should returns :
			| property      | value                           |
			| code			| 117							  |
			| name			| Billet9                         |
	When the Engine API receive the put request with Code 117 
	Then the response of Update  status is "200"
	And the UpdatedEngine API sends : "True"
			

Scenario: Update  Engine by Inexistant Id 
	Given a Engine with the  Code 1600 and request to EngineApi returns :
         | property | value |
	When the Engine API receives the get request with new Code 1600
	Then the response of NoContent status is "404"