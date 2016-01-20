Feature: Crud

Scenario: Partial select 
	Given I have set up the building address repository
	And I have set up the building identity repository
	And I have inserted 10 full building DTOs
	When I retrieve all the building identity DTOs
	Then the retrieved building identity DTOs should match the inserted full building DTOs
