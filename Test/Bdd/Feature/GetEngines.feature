Feature: GetEngines
#

@Engines
Scenario: Get All Engines
	Given a Request to get All Egines and request to EngineApi returns :
			|Id							|Code		|Name			|
			|60633398527df471840ea894	|10			|Billet3		|
			|605dbf9f512f158a3ae3416c	|2			|E-ticket 		|
			
			


	When the Engine API receives the get request 
	Then the response status is "200"
	And the Engine API sends Engines information:
			|Id							|Code		|Name			|
			|60633398527df471840ea894	|10			|Billet3		|
			|605dbf9f512f158a3ae3416c	|2			|E-ticket 		|
			
Scenario: Get Engines from Empty DataBase
	Given a request and request to EngineApi returns :
			|Id							|Code		|Name			|	
	When the Engine API receives the get request 
	Then the response status is "404"
