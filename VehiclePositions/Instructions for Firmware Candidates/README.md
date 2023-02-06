# Vehicle Position Challenge - Instructions for Firmware Candidates ONLY

## Task
The binary data file "VehiclePositions.dat" in "VehiclePositions_DataFile.zip" contains a position for each of 2 million vehicles. Your task is to write a program that finds the nearest vehicle 
positions in the data file to each of the 10 co-ordinates provided in the table below. Your program should be able to find the position ID's of all 10 closest positions in less time than the benchmark approach that simply loops through each of the 2 million positions and keeps the closest to each of the 10 co-ordinates. The challenge is to optimize for speed and improve on the benchmark to the best of your ability.

## Specifics
  * Use Git to clone the project template to your PC
  * Use C language and GCC compiler toolchain (recommend MinGW/MSYS for Windows users)
  * Your code should be compatible with 32 and 64 bit architectures
  * Add your code to _solution.c_
  * Complete _makefile_ with rules to compile and clean
     * Compile: Should only recompile code when any source code changed
       * Disable optimization
       * Disable generation of debug information (for final submission)
       * Enable all general warnings
       * Enable conversion warnings
     * Clean: Should not show error if files does not exist
  * Add code to time execution of the content of the _main()_ function with millisecond accuracy. This includes reading of the file.
  * You are allowed to use any means possible to speed up execution - this is not limited to code/algorithm optimization.

## Minimum acceptance criteria:
 * Your solution should correctly identify the position IDs of the closest positions
 * Your solution should find the position IDs in under 500ms when run on our benchmark PC: 1.9GHz, Turbo 4.8Ghz, 4 Cores, 8 Threads
 * You are allowed 3 submission attempts

## Fast track acceptance criteria:
 * Your solution should correctly identify the position IDs of the closest positions
 * Your solution should find the position IDs in under 80ms when run on our benchmark PC: 1.9GHz, Turbo 4.8Ghz, 4 Cores, 8 Threads
 * You are allowed 1 submission attempt

## Additional information

### Structure of the objects within _position.dat_:

Field               |Data Type
--------------------|--------------------------------------------------------
Position ID         |32 bit integer
Vehicle Registration|Null terminated string (ASCII)
Latitude            |32 bit floating point
Longitude           |32 bit floating point
UTC Timestamp       |64 bit unsigned integer (number of seconds since Epoch)

### 10 co-ordinates:

Position  |1          | 2        | 3         | 4        | 5        | 6         | 7         | 8        | 9        | 10
----------|-----------|----------|-----------|----------|----------|-----------|-----------|----------|----------|------------
Latitude  |34.544909  |32.345544 |33.234235  |35.195739 |31.895839 |32.895839  |34.115839  |32.335839 |33.535339 |32.234235
Longitude |-102.100843|-99.123124|-100.214124|-95.348899|-97.789573|-101.789573|-100.225732|-99.992232|-94.792232|-100.222222


## Hints

- A basic optimized version using the benchmark approach is expected to run in under 400ms.
- A further optimized approach that e.g. focuses on maximum CPU utilization is expected to run in under 200ms.
- The current record for finding all position IDs on our benchmarking PC is 29 ms.
