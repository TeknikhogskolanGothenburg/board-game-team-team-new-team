# Board game assignment

**OBS!** This is a translation of the [swedish assigment description](assignment.sv.md), and the swedish one is always the master document, so for any twist refer to the swedish version.

The assigment should be solved in teams of 3-4 students.

The assignment consist of two parts, a programming part and a docmentation part.

All work should be done in the teams github repo which should be public. With a [commit early and often](https://blog.codinghorror.com/check-in-early-check-in-often/) ([1](https://sethrobertson.github.io/GitBestPractices/)) strategy, the recomendation is of course only to commit code and documentation that builds.

# Programming

This project is about implememting a board game, it's upp to you which one, but there is a Ludo board in the folder *Content* which you can use for a start (to avoid implementing the HTML+CSS). The easist would be a game with a predictable game flow.

## Basics

The game should be a website which you enter as a player.

## Game Engine

The game engine controlls all rules in the game.

Implement the game engine in a serperate Class Library, the implementation should follow the SOLID princinples. 

An instance of the game engine should contain the state of the whole game, it should be possible to initiliate the game with a state.

A Unit Test Project should be created to test the game logic. 

# Documentation

The documentation should be written using markdown in the folder DocsSrc, you choose within the team if you should write in swedish or english.

Write user stories (the folder DocsSrc\userstories), and do not start coding anything before you have written at least three user stories, but make sure to maintain and add user stories during the process.

Descript the architecture of your application (in the folder DocsSrc\acrhitecture).

Remeber to include references to all resources you use.
