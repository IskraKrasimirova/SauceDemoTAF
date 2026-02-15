Feature: ProductsTests

Products and cart operations. Managing products in the inventory and performing cart actions.

@E2E
Scenario: User completes a purchase after modifying the cart items
	Given I am logged in as standard user
	When I add the first product to the cart
	And I add the last product to the cart
	And I verify the correct products are added to the cart:
		| Sauce Labs Backpack               |
		| Test.allTheThings() T-Shirt (Red) |
	And I remove the first item from the cart
	And I add previous to the last product to the cart
	And I verify the correct products are added to the cart:
		| Test.allTheThings() T-Shirt (Red) |
		| Sauce Labs Onesie                 |
	And I go to checkout
	And I finish the order
	Then the order should be successfully placed 
	And the cart should be empty
	And I should be able to logout successfully
