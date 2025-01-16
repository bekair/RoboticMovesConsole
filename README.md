# Mars Robot Navigation Project

## Project Overview
A coding exercise focused on clean coding and abstraction principles through simulating robot navigation on Mars. Robots navigate a bounded grid following specific instructions while implementing a scent mechanism to prevent repeated falls off the grid.

## Core Concepts

### Grid System
- Rectangular grid with defined boundaries
- Positions represented by coordinates (x, y) and orientation

### Robot Navigation
- Commands:
  - L: Turn left 90 degrees
  - R: Turn right 90 degrees
  - F: Move forward one grid position
- Robots marked "LOST" when falling off grid
- Last valid position before falling leaves a "scent"
- Scent prevents future robots from falling at same position

## Technical Implementation

### Key Components

1. **Grid Component**
   - Manages boundaries and scented positions
   - Validates robot movements

2. **Robot Component**
   - Manages position and orientation
   - Processes movement commands
   - Tracks lost status

### Data Structures

```typescript
interface Position {
    x: number;
    y: number;
    orientation: Orientation;
}

interface Grid {
    maxX: number;
    maxY: number;
    scentedPositions: Position[];
}

interface Robot {
    position: Position;
    isLost: boolean;
}
```

### Processing Flow

1. Initialize grid with dimensions
2. For each robot:
   - Set initial position
   - Process commands
   - Update position/status
   - Mark scented positions if lost

## Example Usage

### Input Format
```
5 3        // Grid dimensions (max X, max Y)
1 1 E      // Robot 1 initial position (x, y, orientation)
RFRFRFRF   // Robot 1 command sequence
3 2 N      // Robot 2 initial position
FRRFLLFFRRFLL  // Robot 2 command sequence
```

### Expected Output
```
1 1 E      // Robot 1 final position
3 3 N LOST // Robot 2 final status
```
## License

This project is licensed under the MIT License - see the LICENSE file for details.
