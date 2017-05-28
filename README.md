To be used with Microsoft Visual Studio

# CURRENT ISSUES
Hey guys, this is a beginner side project I've been working on for the last 2 days or so. There is one issue that makes me want to drink
bleach... 
Anyways... to locate the problematic code:
  step1: open the GameOfLine.sln file
  step2: navigate to Generator.cs
Ok so the actual problem. If you're familiar with Conway's Game of Life each "tick" results in a new map as each cell follows specific 
rules. I got that part to work in a earlier version. Now, I'm trying to store each tick (represented by a 2d int array, int[,]thisGen,
as well as another 2d int array, int[,]nextGen, to form the current and the next ticks. Each tick is added to Array[] aoa by the compile 
method(line 74). Lines 29-32 is where the user can choose which tick to retrieve. Depending on the answer, the program should retrieve 
the int[,] array stored in the answer position of the Array[] aoa, or aoa[answer]- unless I'm wrong. The visualize method that calls on
the retrieved array is lines 86-105. Line 90 is the real problem I think. The aoa that I retrieved seemed to be just a 1d array, not the
2d one that I should have stored.
So in all, there are 4 areas from which the error could have come from:
  1) Line 21: initialization of Array[] aoa(possibly wrong kind of array?)
  2) Lines 29-32: retrieving the 2d int array from 1d array array aoa
  3) Lines 74-84: error in assigning the 2d int array thisGen to 1d array array aoa
  4) Line 90: In addition to missing a cast, the array retrieved isn't 2d like the array stored(unless it really was possible error 3)

# GameOfLife
1) declare grid size 
2) declare number of iterations 
3) each iteration of a 2d int[,] is stored in an array[]. 
4) Specific iterations would be printed out on the user's request.

# Rules
1) A cell's "neighbours" are the 8 cells around it.
2) If a cell is 'off' but exactly 3 of its neighbours are on, that cell will also turn on - like reproduction.
3) If a cell is 'on' but less than two of its neighbours are on, it will die out - like underpopulation.
4) If a cell is 'on' but more than three of its neighbours are on, it will die out - like overcrowding.
(In progress, more will be added according to https://www.reddit.com/r/dailyprogrammer/comments/6bumxo/20170518_challenge_315_intermediate_game_of_life/?st=j36nngc2&sh=d1ab8a02)
