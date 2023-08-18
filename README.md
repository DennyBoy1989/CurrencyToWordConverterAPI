# CurrencyToWordConverterAPI
Application that provides an Web API endpoint for converting a given currency to its corresponding word representation.

## Exposition
This is an .NET 7 web application, that provides an endpoint for converting a currency to its word representation. It was created as part of the application process for a Software Developer position at Qoniac GmbH, a KLA Company. An example client WPF app, that consumes the endpoint is the [CurrencyToWordConverterClient](https://github.com/DennyBoy1989/CurrencyToWordConverterClient)

## How to run it
First clone this repository and open it in your favorite IDE. There are a couple of launch profiles for this project. You can run it with docker, but I recommend using the "https" profile. If you want to, you can also change the LogLevel in the appsettings.json. When you run the application with the "https"-profile, the is sever listening to port 7107 by default. You can change the port in the launchSettings.json in "Api/Properties". While the server is starting, you may get asked, to create a new developer certificate. You should agree and follow the instructions. If you have created a new certificate, restart the server, so that the new certificate is used correctly. After the server was started, your standard browser should open and display an OpenAPI document. You can use this, to send some requests to the /wordrepresentation/{number} endpoint.

## Principles
This project is very small, but I tried to demonstrate some principles, that I like to use:
### Clean Architecture
I really like the 'Clean Architecture' design conceived by Robert C. Martin. In short, it says, that you have a business/domain core and all other layers like datasbases, web APIs or view, should depend on it. The business/domain core contains the models and the core logic of the application and is unware of the other layers. It does provide interfaces, that the other layers can implement, though. To enforce this seperation, I usually like to devide my C# projects into multiple assemblies. So, even though the CurrencyToWordConverterAPI is very small, I have two assemblies. One for API controller and app configuration logic and one for the domain core logic.
### Domain-Driven Design
I try to design my code along the domain context. The context of the CurrencyToWordConverterAPI is the conversion of a currency value, that consists of dollars and cents into its word representation. So these are words, that should be reflected in the code.
#### Domain Errors
I think, that its usefull to wrap exceptions into a more domain specific language. I called them Errors and not Exceptions, to better differentiate between both.
#### Domain Primitives
The domain types are usually composed of domain primitives. Those are types, that restrict the properties of the programming language specific primitive types. For example an "uint" of c# can store values between 0 and 4.294.967.295, but the domain primitive UnsignedIntDec3 can only contain values between 0 and 999. Trying to convert a string "123.456" into an UnsignedIntDec3, should end in an domain exception, reflecting that the value was too big.
### Functional Programming
Except for the Factory-methods, that I use to instantiate new types and primitives, my classes don't contain logic, and are more or less pure data classes. They are also immutable, so they cannot be changed after instantiation. Also all functions, that are definied in this project (not including the unit tests), have a return type and the most of them have no dependencies, too, which makes them super easy to test. 
#### Extension Methods
The extension methods feature of C# is a great way, to structure functional code. I normally create a class with the suffix "Methods", like DollarsMethods, and put all dollar related functions into it. If the class gets to big, you can split it into multiple classes with a more specific context, like DollarsWordReperesentationMethods. This makes naming things a lot more intuitive in my opinion. Furthermore I only need to import the extension (modules), that I need, while my entity objects stay clean data classes, that can easily be used in tests. 
### Grey-Box-Testing
Another aspect, that is worth mentioning, is the way I like to unit test. After many years of heavy white box testing, I decided to switch to an approach, that focuses more on the result of a test, then the behaviour of the code. On the same time, I know the code, and I know, which inputs I need, to test the edge cases. This is sometimes called Grey-Box-Testing. In the last years I extended the approach by using stubs for the IO-Interfaces and relay on the actual implementations of all classes instead of writing a mock for every dependency, that a class under test has. So my tests mostly create the input and configure the IO stubs (comparable to an in-memory database) in the "arrange"-phase and are then executed pretty straightforward.
One downside of this approach is, that I have some redundancy in my tests and one change in my code, has the potential to effect many unit tests.
