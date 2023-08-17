Bcgx Coding Challenge - Applicant Joseph Lebold

Installation Instructions:
	1.) Inside of the appsettings.json, replace the existing connection string with a personal connection string to
		an empty local sql server database.

Running the app:
	With the startup project set to BcgxCodingChallenge (set by default), you can click the green play button in visual studio to begin
	running the app

Running the test cases:

Example API input example:

POST http://localhost:8080/checkout
# Headers
Accept: application/json
Content-Type: application/json
# Body
[
"001",
"002",
"001",
"004",
"003"
]

Example API Response example:



Developer's notes:
	The architectural decisions made here were partially motivated by the idea that clients over time will begin to ask
	us to start carrying more and more watch brands. If we had the guarantee that this was not the case then one could
	argue that standing up an entire database just to host four rows of data was a bit of an overkill.

	In a true enterprise level solution I would have instead:
		- Given the entire DataAccess folder it's own project (layer)
		- Given the entire Services (business layer) folder it's own project
		- Given any relevant user interfaces their own solutions

	Side note:
	This was fun and relatively stress free! I wish more companies would give these sort of take home tests;
	It feels much more what it's actually like to work on the job than the 20 minute leetcode challeges do.
	Thanks for your consideration and I look forward to discussing the solution with you live.

	Cheers,
	Joe