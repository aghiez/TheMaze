/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratt : MonoBehaviour
{
 import random
import time

def running_mouse(width, height, iterations):
   # Initialize the grid with all zeros
    grid = [[0 for _ in range(width)] for _ in range(height)]

    # Start at a random position
    x, y = random.randint(0, width - 1), random.randint(0, height - 1)
    grid[y][x] = 1

    # Directions to move in
    directions = [(0, 1), (0, -1), (1, 0), (-1, 0)]

    for _ in range(iterations):
        # Choose a random direction
        dx, dy = random.choice(directions)

        # Calculate the new position
        new_x, new_y = x + dx, y + dy

        # Check if the new position is within the grid
        if 0 <= new_x < width and 0 <= new_y < height:
            # Move to the new position
            x, y = new_x, new_y
            grid[y][x] = 1

        # Print the current state of the grid
        for row in grid:
            print(''.join(['#' if cell else ' ' for cell in row]))
        print()

        # Wait for a short time before moving again
        time.sleep(0.1) 

# Run the simulation
running_mouse(20, 20, 100)
}*/
