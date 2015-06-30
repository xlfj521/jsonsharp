# JSONSharp - C# meets JSON #
**JSONSharp** is a C# library for generating JSON-formatted data.  The library is very lightweight and fully object-oriented. The library was born out of a need to generate JSON-compliant strings from the server-side of a .Net application. The library is easily extensible to handle specific implementations to ease the syntactical burden of incorporating the library into your own project.


## {07/25/2007}: How to make ASP.NET user controls return as JSON ##
I put together a new example that uses Jsonsharp to return any user control to a JSON string.  There's a complete working example available on our [download page](http://code.google.com/p/jsonsharp/downloads/list), but you should check out the **[blog entry](http://code.google.com/p/jsonsharp/wiki/HowToConvertASPdotNETUserControlsToJSON)** first.



## {07/24/2007}: Jsonsharp and the GPL ##
There have been a few private questions posed to me about using jsonsharp with other projects (some personal, some commercial).  Unfortunately, licensing matters tend to cause more questions than they actually answer.  I put together my thoughts and notes on it over in our **[discussion group](http://groups.google.com/group/jsonsharp/web/jsonsharp-and-gpl)**.



## {07/06/2007}: Release 1.1 now available ##
**[Release 1.1](Release1Dot1.md)** is now available. As usual, the **[source code](http://jsonsharp.googlecode.com/svn/trunk/)** is available in the repository, but you can also **[download](http://code.google.com/p/jsonsharp/downloads/list)** the code and sample applications.

### What's new in Release 1.1? ###
In response to numerous questions about making the library easier to use, we've added the JSONReflector class.  This class takes an instance of any object and using standard reflection routines, generates a JSON string.  There are some constraints on JSONReflector for the time being (it doesn't do anything with generics yet) but we'll take care of that later.



## {07/02/2007}: Source and example apps available for zip download ##
the **[source code](http://jsonsharp.googlecode.com/svn/trunk/)** is available in the repository, but you can also **[download](http://code.google.com/p/jsonsharp/downloads/list)** the code and sample applications in zip format.  For some, this may be easier than updating from the repository.  Those projects are current with source, but may not always be up to date.




## Updated documentation ##
we have updated documentation as well as solution and project files for both the Windows .Net 2.0 Framework (Visual Studio 2005) and the Mono 2.0 Framework (Monodevelop).  You can find them over in **[source](http://jsonsharp.googlecode.com/svn/trunk/)**.





Please see the **[wiki](http://code.google.com/p/jsonsharp/wiki/Overview)** for details about the library and how to use it.
