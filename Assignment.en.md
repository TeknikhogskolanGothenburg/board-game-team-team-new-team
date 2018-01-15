# Board game assignment

The assigment should be solved in teams of 3-4 students.

The assignment consist of two parts, a programming part and a theory/docmentation part. Please see the prerequsists section (in the [README.md](README.md)).

The work should be done in the teams github repo which should be public. With a [commit early and often](https://blog.codinghorror.com/check-in-early-check-in-often/) ([1](https://sethrobertson.github.io/GitBestPractices/)) strategy, the recomendation is of course only to commit code and documentation that builds.

## Programming part

This repo is an assignment template, for implementening using ASP.NET MVC.

The folder *content* contains an example on how the [Ludo](https://en.wikipedia.org/wiki/Ludo_(board_game)) game board can be implemented in HTML and CSS.

Add store your source code in the *src* folder

### Game Engine

Implement the game engine in a serperate Class Library, the implementation should follow the SOLID princinples. 

An instance of the game engine should contain the state of the whole game, it should be possible to initiliate the game with a state (as loading a saved game).

A Unit Test Project should be created to test the game logic. 

## Teory / Documentation part

In the folder DocsSrc is an more or less empty DocFx project. DocFx is compiled documentation written in [markdown](https://guides.github.com/features/mastering-markdown/).

Your assigment is to fill the files:

* articles\Architecture.md

And to build the documentation for the source code to the webserver.

The run the documentation you can see the content of this by opening commandline and navigate to the DocsSrc folder, and write ```docfx .\docfx.json --serve --port 8081```, then open your browser and navigate to [localhost:8081](http://localhost:8081).

Remeber to include references to all resources you use.
