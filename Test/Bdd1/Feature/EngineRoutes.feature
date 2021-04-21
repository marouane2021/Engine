Feature: Engine Routes

Scenario: Get a List of engines 200
	When the Api receives a Get request for /Moteur/GetAll/Engines
	Then the Api returns a list of engine with body
		| code  | name   | isEnable | 
		| 16    | Beaute | true     | 
		| 17    | Filme  | true     |
	And the status code should be 200

Scenario: Get a list of engines 404
	Given engines Informations inexistant in database
	When the Api receives a Get request for /Moteur/GetAll/Engines
	Then the status code should be 404

Scenario: Add engines 200
	When The Api receives a Post request for /Moteur/CreateEngine with body ./Json/CreateEngine.json
	Then  the status code should be 201
	

Scenario: Get engines by engineId 200
	When the Api receives a Get request for /Moteur/GetEngineByCode/16
	Then the status code should be 200
	And the returned body should be ./Json/GetEngine.json

Scenario: Get engines by engineId 404
	When the Api receives a Get request for /Moteur/GetEngineByCode/100
	Then the status code should be 404

 Scenario: Delete engines by engineId 200
	When the Api receives a Delete request for /Moteur/DeleteEngine/16
	Then the status code should be 200


Scenario: Delete engines 404
	When the Api receives a Delete request for /Moteur/DeleteEngine/100
	Then the status code should be 404

Scenario: Update engines by engineId 200
	When the Api receives a Put request for /Moteur/UpdateEngine/16 with body ./Json/UpdateEngine.json
	Then the status code should be 200


Scenario: Update engines 404
	When the Api receives a Put request for /Moteur/UpdateEngine/100 with body ./Json/UpdateEngine.json
	Then the status code should be 404