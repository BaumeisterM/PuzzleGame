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
