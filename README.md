# 🧩 C# Console Puzzle Game

A classic sliding tile puzzle (15-puzzle style) built with C#. This project focuses on clean code principles, object-oriented design, and modern C# features.

## 🚀 Features

* **Dynamic Difficulty:** Choose between 2x2 (test mode) up to 6x6 grids.
* **Encapsulated Logic:** The `Board` class manages its own state and validates moves internally.
* **Visual Feedback:** Tiles turn **green** when placed in the correct position and remain **gray** otherwise.
* **Smart Shuffling:** Implementation of an anti-backtracking algorithm to ensure an effective and solvable board scramble.
* **Persistent Highscores:** Results are serialized into board-specific JSON files.
* **Interactive UI:** Animated "blinking" inputs and ASCII art for an improved user experience.

## 🕹️ Preview

```text
 ┌───────┐  ┌───────┐  ┌───────┐ 
 │   1   │  │   2   │  │   3   │ 
 └───────┘  └───────┘  └───────┘ 
 ┌───────┐  ┌───────┐            
 │   4   │  │   5   │            
 └───────┘  └───────┘            
 ┌───────┐  ┌───────┐  ┌───────┐ 
 │   7   │  │   8   │  │   6   │ 
 └───────┘  └───────┘  └───────┘ 

 Moves: 12
 ```

## 🛠️ Getting Started

### Prerequisites
* .NET 8.0 SDK or higher

### Installation
1. Clone the repository:
   git clone https://github.com/BaumeisterM/PuzzleGame.git
2. Navigate to the project directory:
   cd PuzzleGame
3. Run the application:
   dotnet run

## 🏗️ Architecture & Patterns

This project follows the Separation of Concerns principle:

* **Board.cs**: The "Brain". Handles the 2D-array logic, shuffling, and win-condition checks.
* **Player.cs**: The "Controller". Manages user input, timing, and interaction with the board.
* **Score.cs**: The "Data Layer". Handles JSON serialization and highscore management.
* **StartMenu.cs**: The "View". Handles the initial user interface and difficulty selection.



## 🧠 Key Learnings
* **JSON Serialization:** Using System.Text.Json to persist data across game sessions.
* **Switch Expressions:** Utilizing modern C# 8.0+ syntax for cleaner and more readable logic.
* **Encapsulation:** Protecting the board state and providing a clean API for the Player class to interact with.
* **Game Loop Logic:** Managing real-time input and state updates in a console environment.

