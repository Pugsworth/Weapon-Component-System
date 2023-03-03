# Composed Weapons

## About
I'm mostly just messing around with the concept of a composed weapon system similar to something like in the game [Borderlands](https://en.wikipedia.org/wiki/Borderlands_(franchise)).
I'm writing it in C# since it's a more neutral language compared to something like Rust or Kotlin.


## What is a composed weapon?
A composed weapon is a weapon whose physical components are represented by separate (virtual) objects. These objects can add to or modify the weapon's stats and behavior. For example, a weapon could have a scope that allows ADS. The primary use, though, is to allow for a more modular approach to weapon creation. Stats would be generated based on the components added. For example, a weapon barrel could be "long" which would increase the weapon's range.
I plan on implementing soft and hard stats. Soft stats would be things like the performance of the weapon. Hard stats would be additional functionality introduced by specific properties of the components. The long barrel example is one of these.
You could think of these hard stats as modifiers to the weapon from the component. 

This is still in development so the above is subject to change.


## Why?
I like weapons in games, especially first person games. More specifically, the technicalities of the weapons in the games.
Some games have very basic weapons that do one thing and that's it. Games like Half-Life follow this model.
Other games have greatly detailed guns with stats and other fun things. Games like Borderlands follow this model.
I've tried to implement something like this to various degrees before, but it's always been a bit of a mess. I'm hoping to make something that's more organized and easier for a proof of concept here before I try to implement it in a game.


## How?
Polymorphism and components!

## How to use
The main program will pick a random weapon and generate the components for it. Then, it will print out the weapon's stats and the components that make it up.

Run with:
```dotnet run```