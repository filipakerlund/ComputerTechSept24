# Read Me: 

- This is a 2022.3.40f1 project from a course using DOTS to learn ECS.  
- Packages: The Entities package, the new Math library and the new Input System. 
- It contains a pre-made Windows build in the zip-file Builds.zip 

In this project, I was introduced to how to create a project using Unity's Data-Oriented Technology Stack (DOTS): the project uses ECS, a Job System and Burt Compiles code. 

Quick run-down of ECS: ECS instead of OOP is a data-oriented design: it is optimized for how the computer processes and store data.
It separates the data from the logic, by using entities, components and systems:  

# Entities: 
An id that is associated to a set of Components. 

# Components: 
Holds the data. Stored in chunks. This data becomes more “cache-friendly" by storing data contiguously packed together, 
the CPU can use its cache memory better: It will optimize cache hits, so the CPU doesn’t have to request data that is from the slower memory, the RAM. 

# Systems: 
Modifies the data in the Component. 

DOTS also has the Job System and the Burst Compiler, which are utilized in this project. By having the code in the game using DOTS it boosts the hardware performance for both CPU and memory. 

# Job System: 
Moved CPU work from the main thread to improve performance. 

# Burst Compiler: 
Is used to compile the code to optimized code, Unity Mono is very slow and impacts the memory access. The Burst compiler works well for memory with a Data Oriented Design, like ECS, 
There’re no managed memory allocations:  
https://www.youtube.com/watch?v=QkM6zEGFhDY.
