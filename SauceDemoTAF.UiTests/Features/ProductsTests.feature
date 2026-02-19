Feature: ProductsTests

Products and cart operations. Managing products in the inventory and performing cart actions.

@E2E
Scenario: User completes a purchase after modifying the cart items
	Given I am logged in as standard user
	When I add the first product to the cart
	And I add the last product to the cart
	And I verify the correct products are added to the cart:
		| Product                           |
		| Sauce Labs Backpack               |
		| Test.allTheThings() T-Shirt (Red) |
	And I remove the first item from the cart
	And I add previous to the last product to the cart
	And I verify the correct products are added to the cart:
		| Product                           |
		| Test.allTheThings() T-Shirt (Red) |
		| Sauce Labs Onesie                 |
	And I go to checkout
	And I finish the checkout
	Then the order should be successfully placed
	And the cart should be empty
	And I should be able to logout successfully


Scenario: Sorting products by Price (high to low) sorts the items correctly
	Given I am logged in as standard user
	When I select sorting by Price (high to low)
	Then the products should be sorted by price in descending order
	And I should be able to logout successfully

