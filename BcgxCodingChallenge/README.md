Bcgx Coding Challenge - Applicant Joseph Lebold

Installation Instructions:
	Inside of the appsettings.json, replace the existing connection string with a personal connection string to
	an empty local sql server database.
 
Running the app:
	With the startup project set to BcgxCodingChallenge (set by default), you can click the green play button in visual studio to begin
	running the app. A swagger page should appear that will let you interact with the checkout endpoint.


Example API Request example:

POST http://localhost:8080/checkout
# Headers
Accept: application/json
Content-Type: application/json
# Body
[ "001", "002", "001", "004", "003" ]

Example API Response example:
{ "price": 360 }


Developer's notes:
	The architectural decisions made here were partially motivated by the idea that clients over time will begin to ask
	us to start carrying more and more watch brands. If we had the guarantee that this was not the case then one could
	argue that standing up an entire database just to host four rows of data was a bit of an overkill.

	In a true enterprise level solution I would have:
		- Given the entire DataAccess folder it's own project
		- Given the entire Services (business layer) folder it's own project
		- Have ShoppingServiceTest.cs run on all CI builds for the branch (unit tests)
		- Have ShoppingControllerTest.cs run on only specified CI builds for the branch (integration tests)
		- Given any relevant front end work their own solutions
		- Checked user input validation with some sort of standard library (Fluent / Command pattern is pretty darn nice for this)
		- recognized that our DbContext is being accessed synchronously, which is no good if we were only hosting a single instance and
		multiple users were hitting the endpoint at the same time.

	Side note:
	This was fun and relatively stress free! I wish more companies would give these sort of take home tests;
	It feels much more what it's actually like to work on the job than the 20 minute leetcode challeges do.
	Thanks for your consideration and I look forward to discussing the solution with you live.

Cheers,
Joe