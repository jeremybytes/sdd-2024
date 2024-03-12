# Software Design & Development (SDD 2024) Presentations  

All of the slides and code samples for Jeremy's presentations at SDD 2024 (13-17 May, 2024).  

## Topics

**Abstract Art: Getting Abstraction "Just Right"**  
*Coding Level: 3*  
*Advanced Level: 2*  

Abstraction is awesome. And abstraction is awful. Too little, and our applications are difficult to extend and maintain. Too much, and our applications are difficult to extend and maintain. Finding the balance is the key to success. The first step is to identify your natural tendency as an under-abstractor or an over-abstractor. Once we know that, we can work on real-world techniques to dial in the level of abstraction that is “just right” for our applications.  

* Slides: [SLIDES-AbstractArt.pdf](./01-abstraction/SLIDES-AbstractArt.pdf)  
* Code: [01-abstraction/](./01-abstraction/)

---

**IEnumerable, ISaveable, IDontGetIt: Understanding C# Interfaces**  
*Coding Level: 4*  
*Advanced Level: 2*  

You want code that’s easy to maintain, extend, and test. C# interfaces are here to help. In this session, you’ll learn how to use interfaces effectively in your code, starting at the beginning (“what are interfaces?”), and then exploring why and when to use them. Along the way you’ll learn how to use existing interfaces, implement your own interfaces, and also use interfaces for unit testing and dependency injection. The result is code that is easier to maintain, extend, and test.  

* Slides: [SLIDES-Interfaces.pdf](./02-interfaces/SLIDES-Interfaces.pdf)  
* Code: [02-interfaces/](./02-interfaces/)

---

**Practical reflection in C#**  
*Coding Level: 4*  
*Advanced Level: 2*  

Reflection is an extremely powerful feature of .NET, but there’s a big difference between what we can do and what we should do. Several of these features are very useful to the everyday developer.  

We’ll take a quick look at what reflection is capable of, and then narrow our focus to practical uses, such as making runtime decisions for features and functionality – all while balancing flexibility, safety, and performance.  

* Slides: [SLIDES-reflection.pdf](./03-reflection/SLIDES-reflection.pdf)  
* Code: [03-reflection/](./03-reflection/)

---

**DI Why? Getting a Grip on Dependency Injection**  
*Coding Level: 4*  
*Advanced Level: 2*  

Many of our modern frameworks have Dependency Injection (DI) built in. But how do you use that effectively? We need to look at what DI is and why we want to use it. We’ll look at the problems caused by tight coupling. Then we’ll use some DI patterns such as constructor injection and property injection to break that tight coupling. We’ll see how loosely-coupled applications are easier to extend and test. With a better understanding of the basic patterns, we’ll remove the magic behind DI containers so that we can use the tools appropriately in our code.  

* Slides: [SLIDES-DependencyInjection.pdf](./04-dependency-injection/SLIDES-DependencyInjection.pdf)
* Code: [04-dependency-injection/](./04-dependency-injection/)

---

**LINQ - It's Not Just for Databases**  
*Coding Level: 4*  
*Advanced Level: 2*  

LINQ (Language Integrated Query) is mostly associated with Entity Framework and database access. But it can be used for much more. LINQ lets us sort, filter, and aggregate data all in memory without needing to make another database call.  

You’ll learn how to use the LINQ fluent syntax to combine functions and make a great experience for your users.  

* Slides: [SLIDES-LINQ.pdf](./05-linq/SLIDES-LINQ.pdf)
* Code: [05-linq/](./05-linq/)

---

**WORKSHOP Take Your C# Skills to the Next Level**  
*Coding Level: 4*  
*Advanced Level: 2*  

Are you a C# developer eager to create software that is easy to maintain, has minimal bugs, and makes your users happy? If so, this workshop is for you.  

Through lectures, code samples, and hands-on labs, you will learn how interfaces, delegates, dependency injection, and unit testing can help you write applications that are easy to extend, change, and debug. Along the way you will also encounter modern C# topics such as nullability, switch expressions, and asynchronous code. In the end, you will take away practical experience that you can immediately apply to your own projects. Topics will include:  

* **Interfaces**: Explore the art of writing clean, modular code through interfaces. Learn how interfaces facilitate code extension, make your applications more testable, and lead to fewer bugs.  
* **Delegates**: Gain a deep understanding of delegates and learn how to use them to build flexible and extensible code.  
* **Dependency Injection**: Discover the magic of dependency injection and how it promotes loose coupling, making your codebase more flexible, testable, and maintainable.  
* **Unit Testing**: Write tests that ensure your code functions as expected, enabling you to catch bugs early in the development process.  

Key Benefits:  

* **Easier Maintenance**: Explore practices for writing clean, maintainable code that’s a breeze to work with, whether you’re collaborating with a team or revisiting your own projects down the road.  
* **Fewer Bugs**: Learn the art of writing robust code that is easy to test. Find bugs before your users do, and be confident that code changes do not break existing functionality.  
* **Happier Users**: The point of writing software is to meet your user’s needs. With these tools in hand, you can create applications that not only meet but exceed user expectations.  

Pre-Requisites:  

Basic understanding of C# and object-oriented programming (classes, inheritance, methods, and properties). No prior experience with the primary topics is necessary; we’ll take care of that as we go.  

Take your C# development skills to the next level and build software that not only satisfies your users, but also simplifies your life as a developer. Say goodbye to frustrating bugs, hello to happier users, and welcome to the world of painless maintenance.  

* Slides: [SLIDES-csharp-workshop.pdf](./06-csharp-workshop/SLIDES-csharp-workshop.pdf)
* Code: [06-csharp-workshop/](./06-csharp-workshop/)

---