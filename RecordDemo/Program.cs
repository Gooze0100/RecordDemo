












// this is record declaration
// pascal case used for parameters, because behind the scenes it work for us in record declaration
// records act like value types, but they are not, they are reference type
// a Record is jsut a fancy class, with a lot stuff
// this is a reference type and behind the scene it makes a lot of work with prebuild code to make your life easier
// next feature of Record it is Immutable - values cannot be changed
// so when you set your values in record you cannot change the values by default, design
// so this is readonly class
// you can also make it muttable or mutate, but that breaks the design of the Record
// so it you need to change the values you better create a class with set values
// parameters is like a definition of it so it is with pascal case
// in record there is method that overrides Equality
// it check every property in the same object and if properties the same then both objects Equal
// you need to use this syntax to get good deconstructor for tuples etc.
using System.Security.Cryptography;

public record Record1(string FirstName, string LastName);

// it is kinda the same as above
// looks the same 
public class Class1
{
    // if we want to make it closer to record we need to make instead of set init
    // init means that this value can be initialized in instructor or then you create a class using curly brace syntax
    public string FirstName { get; init; }
    public string LastName { get; init; }

    // camel case is for parameters
    public Class1(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // this is class decostruction, this with out variable would create a tuple
    // this is how C# code is decompiled like, it would look like below
    // so this would have in order out value for constructor and then it would send the values
    // if we would need to write it our own
    public void Decostruct(out string FirstName, out string LastName)
    {
        FirstName = this.FirstName;
        LastName = this.LastName;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Record1 r1a = new("time", "corey");
        Record1 r1b = new("time", "corey");
        Record1 r1c = new("sue", "strom");

        Class1 c1a = new("time", "corey");
        Class1 c1b = new("time", "corey");
        Class1 c1c = new("sue", "strom");


        //record displays all the data and more readable
        // this is nice way that you can see data
        Console.WriteLine("Record type: ");
        Console.WriteLine($"to String: { r1a }");
        // they are different created objects, but they are the same, thats how they are like value type objects
        // this method Equals do IEqality check
        Console.WriteLine($"Are the two objects equal: {Equals(r1a, r1b)}");
        //ReferenceEquals what does that it look for address in disc for anything, not just the value, but location itself where r1a and r1b
        // this is false that this is not in same location they are the same object as far as value, but as not as far location
        Console.WriteLine($"Are the two reference equal: {ReferenceEquals(r1a, r1b)}");
        // like in if statement, different value checking not like Equals sligthy different
        // this is true similar like Equal
        Console.WriteLine($"Are the two objects ==: {r1a == r1b}");
        // true because value is not the same for r1c
        Console.WriteLine($"Are the two objects !=: {r1a != r1c}");
        // hash code does that it takes all the stuff in object and it created this unique code based what is upon object
        // with that code you can check if something is changed in object, because if something is changed it change that hash code
        // normaly you would check based on location in disc but in record it is overriten
        // first two values has same code because that hash code is overriten to by about just value
        // so object B is the same as object B
        // so if you dont want to have a dupicates you can use LINQ with hash code and say give me all the unique ones and it would give it to you
        Console.WriteLine($"Hash code of object A: {r1a.GetHashCode()}");
        Console.WriteLine($"Hash code of object B: {r1b.GetHashCode()}");
        Console.WriteLine($"Hash code of object C: {r1c.GetHashCode()}");
        // So record override Equals check and double  == and != and override HashCode
        // and essencialy they let us create class code in one line

        Console.WriteLine();
        Console.WriteLine("**************************************************");
        Console.WriteLine();

        Console.WriteLine("Class Type: ");
        Console.WriteLine($"to String: {c1a}");
        // Equals looks in memory place 
        // building a class it the building the house of blueprints
        Console.WriteLine($"Are the two objects equal: {Equals(c1a, c1b)}");
        // location is not the same as for record
        Console.WriteLine($"Are the two reference equal: {ReferenceEquals(c1a, c1b)}");
        Console.WriteLine($"Are the two objects ==: {c1a == c1b}");
        // this checks location on disc so it of course is not the same
        Console.WriteLine($"Are the two objects !=: {c1a != c1c}");
        // all three values are with different locations in memory thats why they hash codes all different
        Console.WriteLine($"Hash code of object A: {c1a.GetHashCode()}");
        Console.WriteLine($"Hash code of object B: {c1b.GetHashCode()}");
        Console.WriteLine($"Hash code of object C: {c1c.GetHashCode()}");


        Console.WriteLine("****************************************************");

        // Tuple can be used as capture value, that is awesome
        var (fn, ln) = r1a;
        // we got values from record, so this uses Deconstructor, it deconstructs to it deonstituate parts
        // because we declared with two values so we can deconstruct it with the same order
        Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");

        // record is read only so we can create a copies of it
        // if we want to change the state of the object, but it is kinda stateless 
        // but you can create a new object mostly of old values but where is changed value
        // with a class it is hard to do, you need to list all the properties one  by one
        // so this just create a copy of r1a and changes the values of FirstName, that is like value type
        // still remember records are still classes with extra stuff
        // this is the behind the scene hides constructor for itself and lets override values
        Record1 r1d = r1a with
        {
            FirstName = "jon"
        };
        Console.WriteLine($"Jon's record: {r1d}");

        Console.WriteLine();


        Record2 r2a = new("Time", "Cors");
        // writes just lastName, because it is internal
        // it is in the object but it cannot be seen if not asked straight, in this signature you wont see it
        Console.WriteLine($"R2a Value: {r2a}");
        Console.WriteLine($"R2a fn: {r2a.FirstName} ln: {r2a.LastName}");
        Console.WriteLine(r2a.SayHello());




    }
    // Struct and Record look like the same thing but they are not
    // Struct is the value type it is not the class, it cannot be instantiated 
    // it cannot be inherited from or inherit, Records can do that
    // Records are more closed to class than Struct
    // you can create Record just one way, this one public record Record1(string FirstName, string LastName);
    // you cannot inherit from a class to a record
    // records have to inherit from records and same for classes
    // so this syntax is so simple but if you need you can change it 
    public record Record2(string FirstName, string LastName)
    {
        // Record even can have methods
        // you can modify how FirstName property is created
        // internal first property
        // declaring property and assiging property explicitly what values are passing in
        // if this make public they will show value
        internal string FirstName { get; init; } = FirstName;
        // you can use lambda expression in get values
        // this values is immutable unchangable, just providing information
        public string FullName { get => $"{FirstName} {LastName}"; }

        // methods available
        public string SayHello()
        {
            return $"Hello, {FirstName}";
        }

        // this is as initializer and it reads as parameter value
        // so this is parameter
        private string _firstName = FirstName;
        // this is actual property name
        // this let us control return value, so like security numbers just last 4 numbers
        // so for the security stuff this is amazing, just make init not set below
        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init {  }
        }
        // records again are immutable so readable when they are set
    }

}

// this is inheritance from record
// so there are three values and two values are passed in base class to initialize it 
// and then there will be one initial property
// you do need to pass the values for Record constructor for inheritance to work
// C# is mature language
public record User1(int Id, string FirstName, string LastName) : Record1(FirstName, LastName)
{
    // also you can do additional stuff here too
}


/*
 * Benefits of Records:
 *  - Simple to set up
 *  - Thread-safe - immutable by definition is thread safe, if you have two different threads working in pararel working with the same object at same time, if both change value at the same time that can cause a conflict, since we cant change any property by default there is no problems.
 *  - Easy/safe to share - pass all day and and it will be safe, if you pass class you pass the reference and in method it can be changed and you cannot stop it, with a Record you can pass always it is a reference, but can see it anc cannot change it because it is immutable, don't worry about changing info
 *  
 *  When to use Records:
 *  - Capturing external data that doesn't change - WeatherService, that data do not change, informational data, SWAPI.dev, that data not to change all the program
 *  - API calls, data from database, if you not modify it. You need to know if data will be changed and mutated
 *  - Processing data - getting data from DB and not changing it. Also you can create a class that contains a record
 *  - Read-only data - if you absolutely certain that data won't be needed to change and you know that you use it
 *  
 *  When not to use Records:
 *  - When you need to change the data (Entity Framework), when you need to work on traking it does not work
 */



// With Maschine learning you can check in DB with 10000 records when it they harraset someone, on FB or something
// you dont want to change their data you just maybe create a class
// this would have read only about the User1 and then you can populate the values that you found
// that is nice to use
public class DiscoveryModel
{
    public User1 LookupUser { get; set; }
    public int IncidentsFound { get; set; }
    public List<string> MyProperty { get; set; }
}


//********************************
// DO NOT DO ANY OF THE BELOW
//********************************
// this code SMELLS and it can cause instability
// hash code will change for this
public record Record3 // No CONSTRUCTOR so no DECONSTRUCTOR
{
    // SET works here but it should not work, and you dont have any constructor so no deconstruturization too
    public string FirstName { get; set; } // the SET makes this record mutable (BAD!)
    public string LastName { get; set; } // the SET makes this record mutable (BAD!)
}

// don't just make clones all over to update state
// it is shallow copy so it cluters memory and this is not very efficient
// if you need to change always use a class 
//Record1 r1d = r1a with
//{
//    FirstName = "jon"
//};









// there is still accesability for args if it is with top level statements
// command line arguments passed down to our application

Console.WriteLine(args);

