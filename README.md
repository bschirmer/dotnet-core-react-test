# dotnet-core-react-test
A quick and simple app to explore building a .net core/react app


## A few notes
There are a few things that I feel I haven't developed correctly....
unit tests
data structure, not sure how to structure the data without a database, for instance, cart data v cheese data
Because of the POC i used static data, which means it add more than 1 of the same item


# Design
## Back end
API end points
- "retrieve" data
-- this will get hardcoded data of cheeeese
- Add to cart
-- Add cheese to a memory data structure
- delete from cart
-- delete cheese from memory data structure
- Update cart
-- used to update a quantity in cart
(Optional)
- Calculate cheese cost (add comment about this being a front end 
feature, but for tests sake, it was added to an api call)
Optional
- User sign in / guest checkout

Data layer
- Add comments into this to make sure you communicate that you know what you would do in a real database
- Add hard coded data into proper data structures

Services layer
- This is where all the services sit
-- API -> services -> Data

Core layer
- This is where we add interfaces, models and other essential stuff

Unit tests
- add a test for each service
- add a test for each api end point

## Front end
Cheese component
- picture
- price per kilo 
- cheese color
- Add to cart
- (optional) Calculator to calculate the cost as per the amount entered
    - input number (check for number)
    - quick math
    - output to somewhere on the row

Page header component
- PZ Cheesy

Nav bar component
- if this is added, just add "pages" with a message saying "coming soon"

Cart 
- simple cart, keep track of cart data in memory and display it in cart

Checkout
- Simple checkout, keep track of cart data in memory and display in checkout
- maybe add a fake user login
    or checkout as guest
- quick message to say this is not a working store, so you cant buy

## Notes
May need to add Cart/Checkout inferfaces