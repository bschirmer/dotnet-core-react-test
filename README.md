
# dotnet-core-react-test
A quick and simple app to explore building a .net core/react app

## Run instructions
For testing purposes, this will have to be run locally (i.e. not using docker). See Technology note below
**For Docker:**
Depending on your use, you may need `sudo` at the start of these commands
1. clone this repo 
2. navigate to the repo folder in CMD or Terminal
3. run `docker build -t <image-name> -f Dockerfile .`
4. run `docker run -dit -p <outward port>:80 <image-name>`
5. navigate to `localhost:<outward-port>` in browser
	 * This will have the back-end running
6. navigate to `[repo]/pzcheesy.react` and repeat steps 3 and 5 with a different outward port
     * This will have the front-end running

**Running locally:**
1. clone this repo 
2. navigate to the repo folder in CMD or Terminal
To start backed:
3. run `dotnet run -p PZCheesy.Api/PZCheesy.Api.csproj`
	* This starts the back-end
4. navigate to `localhost:5000`
	* this will load the swagger page
5. navigate to `[repo]/pzcheesy.react` in a different CMD or Terminal window
6. run `npm install`
7. run `npm start`
8. navigate to `localhost:3000`
	* this loads the front-end  


## A few notes
There are a few things that were developed for POC only and I would have put more time into if I had the chance. 
1. After developing a working POC I learned about the Unit of Work pattern. As this is already working and because this is only a POC, I decided not to refactor and add it in. The repositories I added are not used, but would be used alongside unit of work if this were a real app. 
2. Because of the above, I realised my unit tests could do with some improving. For instance, they could use a mock class with mock data which would tie in nicely with the real repositories.
3. Data structure is stored in memory. For a real app, this would be a database. Furthermore, the data layer would be the only layer that interacts with the database.
4. I would add proper error handling and proper API requests/responses, this would also improve the swagger.

As mentioned above, the swagger page could use some improving. Because of the static data and no test database, the swagger works but you have to add data with the /cart/add before trying to retrieve 

### Technology notes
This is my first time using docker and I have only used react a handful of times. There are 2 dockerfiles, 1 in the root and 1 in the react project. Originally I had them combined but could not get everything running properly.
Splitting the dockerfile out into 2 allowed me to get the back-end and front-end running simultaneously, but unfortunately there is some networking issues stopping them from communicating. With more time, I feel like I could have solved this issue. 

I know there is a lot for me to learn and I look forward to growing and mastering all of the stack as a part of a PZ team.
