Feature: ArraysChallenge
As as Automated Tester
I want to write a function to return index of the array where the sum of integers at the index 
on the left is equal to the sum of integers on the right.


@positive
Scenario: Submit valid answers in the arrays challenge
	Given I am on the Ecs challenge homepage
	And I click on RenderChallengButton
	And I create an array of each row in table
	When I 'Jaydeep Patel' submit all my 'valid' answers for the challenge
	Then I should recieve a message 'Congratulations you have succeeded. Please submit your challenge'

@negative
Scenario: Submit invalid answers in the arrays challenge
	Given I am on the Ecs challenge homepage
	And I click on RenderChallengButton
	When I 'Jaydeep Patel' submit all my 'invalid' answers for the challenge
	Then I should recieve a message 'It looks like your answer wasn't quite right'





