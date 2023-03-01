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

--------

A good software abstraction requires that we understand the problem well enough in all of its breadth to know what is common across related items of interest, and to know what details vary from item to item.

Abstraction focuses on the essential characteristics of some object, relative to the perspective of the viewer
*OOAD Grady Booch*

### Composite ###
Composite is structural. Represents part-whole hierarchies with tree structure. Client doesn't care about individual of objects and composition of objects. Composition lets the client treat parent and child nodes of this tree the same way.  
File system → Directory → File  
For client, deleting a file is the same as deleting a directory.  
Front end frameworks use this pattern a lot. Like a panel that holds a grid and the grid holds the button. Resizing a panel resizes the children.  

Composite is aligned with OCP principle.
It's not possbile to restrict operations with type. Run-time check is needed.

### Adding an opperation ###
We might need to add operation to nodes of our composite structure, traverse it or change its structure.
Adding operation to a composite structure has different methods. One way is to put the operation on the shared interface between leaf and parent (e.g. *Add*). That way, the child and parent maintain transparency from the client perspective. Client treats them both the same way. But it has a drawback. This generalization is not correct, and child methods are forced to implement methods that do not belong to them. The client can call these methods on the leaf node and cause an issue. This is a violation of LSP principle. So there is a trade-off between safety and transparency.

### Building composite structures ###

---------------
### Specification Pattern ### 
Specification is an abstraction to check some criteria on candidates. It is good for reusability of predicates and decouples predicates from objects.  

Use cases
* Selection (like query)  
* Validation  
* Construction-to-order  

Types of specification:
Hard coded specification → AdultSpec: age> 10
Parametrized specification (more abstract) → AgeSpec: age > inputeAge
Composite specification (it's a binary tree!)

Hard coded specs are more expressive. Parametrized specs are more flexible. In both, our specs are dependent on the object (candid) and it's parameter(s). We can make it more general, but it gets complex.
**Do not refactor all ifs to specs.** ask yourself:
* Is it the case that knowledge of these are being used at different places? (e.g. in query and validation)
* Does decoupling these specs makes my design robust to change?
* Do we have different composition of these ifs in different situations?

---------------
### Builder ###
* Builder with director  
This is the original builder pattern in GOF that we don't use much these days. It goes right with the intent of builder, quoting from GOF, it is to *"Separate the construction of a complex object from its representation so that the same construction process can create different representations"*.
The idea is that we might have different representations of an object. Builder let us add these different representations with implementing the same abstraction, and letting the client decide which implementation to use. The client pass it's desired implementation to a *director*. This *director* uses the builder contract to create an object step by step for the client.   
Example: When we want to create a document, and we can create it in HTML format, in CSV format, etc. The steps to create this document are the same (add header, add body, add title, etc.). So we create a builder for each representation, and the director calls the steps of that builder abstraction.  
* Simple builder  
This is the builder we are most familiar with. This way of implementation of builder pattern helps us with construction of a complex object. We can chain builders or create step builders that control order of method calls. Sometimes because creation of an object has different ways and parameters, we can't use factory, since then we must write multiple overloads with different parameters. In that case, simple builder helps us. 

Examples are in code base.  

---------------
### Visitor ###
Intent: Represent an operation to be performed on the elements of an abject structure. Visitor lets you define a new operation without changing the classes of the elements in which it operates.  
For example, in a composite structure, you want to add an operation without changing the node class. These operations are distinct and unrelated. 

Multiple Dispatch:
According to the Wikipedia, multiple dispatch or multimethods is a feature of some programming languages in which a function or method can be dynamically dispatched based on the run-time (dynamic) type or, in the more general case, some other attribute of more than one of its arguments.
For example, we have an abstract class called *Shape*, and it has three subclasses, *Square*, *Rectangle* and *Circle*. We also have a *Board* class which has 3 draw methods, and each method takes either Square, Rectangle or Circle. In C# if I call this draw method and give it a Shape reference instance (which will be one of the subtypes, but that subtype will be known to the compiler at run time, I will get an error. Because this way compiler can not choose which function to call. To achieve multidispatch, we use the keyword *dynamic*.  

Visitor uses some sort of multiple dispatch which is called double dispatch to add behaviour to an structure of elements (like a tree of root and child objects in a composite structure). Example is in codes.
