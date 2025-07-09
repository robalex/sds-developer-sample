# Rob Alexander's Code Exercise

This code exercise was completed with a few assumptions.

<ol>
	<li>I assumed that the FormatSeparators algorithm is meant to take the string inputs and create a literary list from them while leaving out the oxford comma.</li>
	<li>I assumed that completing the Frontend login page meant adding logins to the recent activity feed. Because you wouldn't generally want to expose user passwords, the login feed only shows usernames. The filter performs a simple match against the start of the username and displays matches. It would be very easy to modify to display passwords and filter on those as well if we didn't care about showing passwords on the page.</li>
</ol>

I added some unit tests and error handling to the dotnet code as appropriate.

To start the Frontend, navigate to the Frontend/login_app directory and run "npm install" and then run "npm start".