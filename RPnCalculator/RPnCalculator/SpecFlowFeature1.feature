Feature: RPN Calculator Evaluator


Scenario: Evaluate RPN Calculator scenario 1
	Given I have entered "1 2 3 + -" into the calculator
	When I press calculate
	Then the result should be "-4" on the screen

Scenario: Evaluate RPN Calculator scenario 2
	Given I have entered "6 2 * 3 /" into the calculator
	When I press calculate
	Then the result should be "4" on the screen

Scenario: Evaluate RPN Calculator scenario 3
	Given I have entered "2 3 ^ 4 5 + +" into the calculator
	When I press calculate
	Then the result should be "17" on the screen

Scenario: Evaluate RPN Calculator scenario 4
	Given I have entered "50 % 2 *" into the calculator
	When I press calculate
	Then the result should be "1" on the screen

Scenario: Evaluate RPN Calculator scenario 5
	Given I have entered "3 ! 4 5 * +" into the calculator
	When I press calculate
	Then the result should be "26" on the screen

Scenario: Evaluate RPN Calculator scenario 6
	Given I have entered "12 3 / !" into the calculator
	When I press calculate
	Then the result should be "24" on the screen

Scenario: Evaluate RPN Calculator scenario 7
	Given I have entered "5 1 2 + 4 * + 3 -" into the calculator
	When I press calculate
	Then the result should be "14" on the screen
