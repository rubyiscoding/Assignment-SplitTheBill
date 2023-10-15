# Assignment-SplitTheBill :spaghetti::pizza: :receipt:
## Project Structure

    **SplitTheBillLibrary:** Contains the core logic for splitting bills and calculating tips.
    **SplitTheBillTests:** This project contains unit tests that validates the functionality of the SplitTheBillLibrary classes and methods.

This solution provides a library for splitting bills among a group of people, calculating tips, and distributing the costs evenly. It includes a `BillSplitter` class which contains the following methods:

## `SplitBillAmount(decimal amount, int numberOfPeople)` 

This method splits the total bill amount equally among the specified number of people.

## `CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)`

This method calculates individual tip amounts based on the total meal costs provided in a dictionary. The Weighted Average approach is used here to distribute the tip according to individual expenses.

## `CalculateTipPerPerson(decimal totalPrice, int numberOfPatrons, float tipPercentage)`

This method calculates the amount of tip per person based on the total price, the number of people, and the tip percentage.

## Unit Tests

The solution includes a set of unit tests in the `SplitTheBillTests` project that validates the functionality of each method under various scenarios, including edge cases and exceptional inputs.



