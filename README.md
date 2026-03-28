# LearnDartsMath

LearnDartsMath is a fullstack web application for training darts-related mental arithmetic, score management, and checkout decision-making. The project focuses on the mathematical side of the game and aims to provide a structured environment in which players can improve their confidence in typical match situations.

The application is being developed as a combination of a Vue frontend and an ASP.NET Core backend. The frontend is responsible for the user interface and training workflow, while the backend is intended to provide application logic, persistence, and user-related functionality such as authentication and progress tracking.

## Motivation

In darts, mathematical accuracy is an essential part of consistent performance. Players must regularly calculate remaining scores, identify practical checkout routes, and recognize when a leg can or cannot be finished according to double-out rules. These situations often occur under time pressure and require routine rather than theory alone.

The purpose of this project is to create a dedicated training application for these aspects of the game. Instead of serving as a general darts scoring tool, LearnDartsMath is intended as a focused training platform for practicing the cognitive side of darts.

## Objectives

The main objectives of the project are:

- to improve the user's speed and accuracy in remaining-score calculation
- to train recognition of valid and efficient checkout paths
- to reinforce understanding of double-out game logic
- to simulate realistic scoring situations in a controlled environment
- to provide a basis for long-term progress tracking and personalized training modes

## Features

The project is currently under development. Some features are already implemented, while others are planned for future iterations.

### Current or initial functionality

- basic frontend application structure
- routing between multiple views
- training view for score-based interaction
- dart input logic with score and modifier selection
- handling of game-specific conditions such as double-out
- basic layout with navigation and footer
- placeholder views for login, registration, and profile-related pages

### Planned functionality

- user authentication and account management
- persistent user profiles
- progress and statistics tracking
- additional training modes
- checkout-specific exercises
- configurable training sessions
- performance history and review
- backend API integration for user and session data

## Use Case

A typical use case for the application is a player who wants to practice darts mathematics outside of actual gameplay. Instead of only memorizing checkout tables, the user interacts with simulated scenarios and enters throws, modifiers, or resulting scores. The application then validates the outcome according to darts rules and can later be extended to provide structured feedback.

## Tech Stack

### Frontend

- Vue 3
- TypeScript
- Vue Router
- CSS

### Backend

- ASP.NET Core
- C#
- Entity Framework Core
- PostgreSQL

## Architecture Overview

The project follows a separated frontend/backend structure.

### Frontend responsibilities

The frontend handles:

- rendering of all views and components
- client-side navigation
- score input and interaction flows
- temporary UI state
- presentation of training scenarios

### Backend responsibilities

The backend is intended to handle:

- business logic that should not remain purely client-side
- user account management
- authentication and authorization
- storage of training sessions and progress
- database access
- future statistics and reporting endpoints

This separation keeps the application modular and makes it easier to develop, test, and extend both parts independently.

## Project Structure

```text
LearnDartsMath/
├── frontend/                # Vue frontend
│   ├── src/
│   │   ├── components/      # Reusable UI components
│   │   ├── views/           # Route-based pages
│   │   ├── router/          # Vue Router configuration
│   │   ├── assets/          # Static assets and styles
│   │   └── ...
│   └── ...
│
├── backend/                 # ASP.NET Core backend
│   ├── Controllers/         # API endpoints
│   ├── Models/              # Domain and data models
│   ├── Data/                # Database context and configuration
│   ├── Migrations/          # Entity Framework migrations
│   └── ...
│
└── README.md