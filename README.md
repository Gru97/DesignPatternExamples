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

