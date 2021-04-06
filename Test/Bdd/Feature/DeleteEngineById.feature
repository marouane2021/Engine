Feature: DeleteEngineById

#

@Engines
Scenario: Delete Engine
	Given a Api the  Code : 117 and request to EngineApi should returns :
			|Code		|Name			|
			|117		|TicketFilm		|
			

	When the Engine API receives the delete request with Code : 117

	Then the response of delete request status is "200"
	And the Engine should return : "True"
			
Scenario: Delete Engine with an Inexistant Code
	Given a Engine with the  Code 1600 and request to EngineApi returns :
         | property | value |
	When the Engine API receives the get request with new Code 1600
	Then the response of delete status is "404"