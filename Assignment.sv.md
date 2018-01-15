#Brädspel

Uppgiften skall lösas i teams på 3 till 4 studenter.

Uppgiften består av två delar, en programmeringsdel och en teori/dokumentationsdel. 

Allt ni gör skall göras i ert GitHub repo (båda kod och dokumentation), som ligger på ert Team. Ni skall använda en ["commit tidigt och ofta"](https://blog.codinghorror.com/check-in-early-check-in-often/) ([1](https://sethrobertson.github.io/GitBestPractices/)) strategi, såklart bör ni endast commita kod och dokumentation som kan kompileras.

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
Säkkerhet


And to build the documentation for the source code to the webserver.

The run the documentation you can see the content of this by opening commandline and navigate to the DocsSrc folder, and write ```docfx .\docfx.json --serve --port 8081```, then open your browser and navigate to [localhost:8081](http://localhost:8081).

Remeber to include references to all resources you use.
