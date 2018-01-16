# Steps

* Read and understand the game rules, and write user stories 
* Create an empty ASP.NET MVC project in the src folder
* When the home controller loads show the gameboard
* Create a Class Library called *Gameengine*, implement the game logic in this library 
* Create a unittest project called *GameengineTests* to be able to unittest the gamelogic
* Use the Gameengine in the MVC project
* Make it possible to start a new game or join an exsiting
* Inform the players when it's their time to do next move

# Emails
It's not recomended to use a smtp server to send out emails, this is possible but not recomended, it's can easy take up very much time.

A solution to this problem is to use a service like [SendGrid](http://sendgrid.com/), they have a free plan for 30 days.