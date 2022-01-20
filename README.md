# Blazor MVVM
Blazor MVVM pattern with SOLID principles

# Why?
I have seen many examples of Web developments trying to apply MVVM but none is based on applying robust SOLID principles.
There are many examples of MVVM binding models directly in the view, Models with services, VM with business logic/initialization, etc...

# SOLID MVVM

![architecture](https://user-images.githubusercontent.com/19477700/150187108-2a162aab-be54-4a45-98f1-4341865e6977.png)
https://www.learnmvvm.com/theory.html

I will try to follow this MVVM architecture to introduce between VM and Model the following components, where we will separate different responsibilities:

- Creation - Have control of the creation of the infrastructure through factories
- Initialization - Create VM initializers
- Syncronization - Create DataSource component to synchronize VM and Model
- Business Logic - Create Commands/CommandManager/EventManager with the responsibility of containing the delegates that execute the business logic.

