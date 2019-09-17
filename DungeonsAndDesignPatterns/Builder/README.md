Builder Pattern 

Diagram:


Question: 

Solid?

What's the difference between Builder and Abstract Factory?#

Like the Abstract Factory pattern, the Builder pattern requires that you define an interface, which will be used by clients to create complex objects in pieces. In the MazeBuilder example, there are BuildMaze(), BuildRoom() and BuildDoor() methods, along with a GetMaze() method. How does the Builder pattern allow one to add new methods to the Builder's interface, without having to change each and every sub-class of the Builder?

