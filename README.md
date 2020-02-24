# dotnet-core-react-test
A quick and simple app to explore building a .net core/react app

## Run instuctions
clone this repo
For Docker:
...


## A few notes
There are a few things that were developed for POC only and I would have put more time into if I had the chance. 
1. After devloping a working POC I learned about the Unit of Work pattern. As this is already working and because this is only a POC, I decided not to refactor and add it in. The repositories I added are not used, but would be used alongside unit of work if this were a real app. 
2. Because of the above, I realised my unit tests could do with some improving. For instace, they could use a mock class with mock data which would tie in nicely with the real repositories.
3. Data structure is stored in memory. For a real app, this would obviously be a database. Furthermore, the data layer would be the only layer that interacts with the database.
4. I would add proper error handling and proper API requests/responses, this would also improve the swagger.

### Technology notes
This is my first time using docker and I have only used react a handful of times. I was unsure of what was required in the Dockerfile, but this was my best attempt for my first time

I know there is a lot for me to learn and I look forward to growing and mastering all of the stack as a part of a PZ team.