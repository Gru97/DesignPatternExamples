# Design Pattern Examples
**Notes and examples from design patterns course**  

Architectural patterns - like MVC, broader than application patterns but not as broad as architecture
Designing for change, not that you design something generic that handles all possible scenarios and changes

For *reusability*, we apply inheritance or composition.
Reuse by subclassing → white box reuse → parent is visible to child
Composition → black box reuse

* Inheritance  
Compile time → parent child relationship is determined in compile time. 
Cost of change is high, structures are statically defined.
Changes in parent class affects subclasses. 
Details of parent is exposed to subclass. 
It is said that "inheritance breaks encapsulation"

* Composition  
Runtime → parameters passed to the class can be decided in runtime
Composition is like Lego. We can compose class in all kinds of ways.
Most design patterns emphasize favoring composition over inheritance
Composition enables change, it enforces OCP
---
**Commonality Analysis**  
Commonality vs variability  
**Abstraction**: To focus on general and put aside the specific  
Commonality is the basis of abstraction  
Variability: The part that differs/ the part that changes/ the specifics  

Commonality can be in algorithm, behavior, structure, etc  
When designing, isolate the variation and create an abstraction for client  

**(Implementation patterns from Kent Beck)**  

**Communication vs Relation**  
Communication happens between two thins that are related.  
Structural patterns talk about relation between objects.  
Behavioral patterns talk about communication between objects.  

Design patterns are creational, structural, behavioral. Meaning that, for example, a creational design pattern isolates the creation part. The creation part is the variable part.  

Strategy is behaviaral. Variation is different algorithms (different sort algorithms). Commonality is the "sorting"   
Decorator is structural. It lets us add behavior to an object by composing it.  
Adapter is structural. It comes to cut communication between client and adaptee. Talks about a relation between us and adaptee.  

A model is not the real thing. It's a representation of that thing that is useful to solve our problem. So depending on the problem, the model of the same thing varies.  

------

**A good software abstraction requires that we understand the problem well enough in all of its breadth to know what is common across related items of interest, and to know what details vary from item to item.**

Abstraction focuses on the essential characteristics of some object, relative to the perspective of the viewer
*OOAD Grady Booch*

**Composite**
Composite is structural. Represents part-whole hierarchies with tree structure. Client doesn't care about individual of objects and composition of objects. Composition lets the client treat parent and child nodes of this tree the same way.  
File system → Directory → File  
For client, deleting a file is the same as deleting a directory.  
Front end frameworks use this pattern a lot. Like a panel that holds a grid and the grid holds the button. Resizing a panel resizes the children.  

Composite is aligned with OCP principle.
It's not possbile to restrict operations with type. Run-time check is needed.
---------------
**Specification Pattern**  
Specification is an abstraction to check some criteria on candidates. It is good for reusability of predicates and decouples predicates from objects.  

Use cases
* Selection (like query)  
* Validation  
* Construction-to-order  

Types of specification:
Hard coded specification → AdultSpec: age> 10
Parametrized specification (more abstract) → AgeSpec: age > inputeAge
Composite specification

Hard coded specs are more expressive.Parametrized specs are more flexible.  
In both, our specs are dependent on the object (candid) and it's parameter(s). We can make it more general, but it gets complex.
**Do not refactor all ifs to specs.** ask yourself:
* Is it the case that knowledge of these are being used at different places? (e.g. in query and validation)
* Does decoupling these specs makes my design robust to change?
* Do we have different composition of these ifs in different situations?
