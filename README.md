A Big Misunderstanding : Unit Testing and Integrated Testing Same

Software testing is a good way to find software bugs. Also, it has important role on ‘Continuous Integration’ for SOA and MicroService(Modern SOA). Today’s, there are a few ways to test our system. ‘Unit’ and ‘Integration’ tests are the popular two type of these tests.

When I search on the internet especially in Stackoverflow.com, I recognize that some developers have misunderstanding about on ‘Unit Testing’ role.( If to be honest , I had the same misunderstanding idea  before searching :) ) According to a common misconception, ‘Unit Test’ result guarantee that a function or class work as correctly or has an exception. According to this idea one problem is occurring that ‘What about Integration test?’ If we look at the aim of Integrated test, we can see the same definition.

Let’s look an shortest definition of Unit Test and Integrated Test.




Unit Testing
I think, This name is the best chose for this test. This testing name give an important clue about the aim of testing. This testing aim is that to test a little part of application. This can be simple method. 
Example Functions: Search Function, Record Function

Integration Testing
This testing aim is that to test a little part of application. This can be simple method. 
Example Functions: Search Function, Record Function.

Wait a minute, They have the same idea. At first sight, the aim of Integration and Unit test have the same idea. 

Let’s look these testing’s aim on a simple example:

bool isThisKeyOnDb (string searchKey)
{
     - logThisKeyOnDb(searchKey) (instance or function)
       /*Do something there*/
    - searchKeyOnService(searchKey) (instance or function)
    - return result
}
Unit Test Result
Unit Test is only check local syntax and structure. Unit Test ignore called function results.
At there logThisKeyOnDb and searchKeyOnService result ignored. (You should test this method with mock object to ignore these functions.)
Integrated Test Result
Integrated Test doesn’t ignore logThisKeyOnDb and searchKeyOnService result. For example, when you test this function logThisKeyOnDb function throw example for the given searchKey  value, Integrated Test result will be fail. For this reason, Integrated Test is called as Integrated. According to integrated test function’s local and global function,variables result important.
Let’s A Quick Look: Mock Object Using In Test
We know that Unit Test ignore non local function or variable. Let’s look at one more time our sample function.

bool isThisKeyOnDb (string searchKey)
{
     - logThisKeyOnDb(searchKey) (instance or function)
       /*Do something there*/
    - searchKeyOnService(searchKey) (instance or function)
    - return result
}

When we use unit test at there, logThisKeyOnDb and searchKeyOnService results have to be ignored. For this case, Unit Test need mock object. This mock object behave like a these functions. 

One of the most important framework(.Net) for this aim is that MOQ framework. You can get detailed info at there.

An Important Clue:    

If you want to Mock Entity Framework class in Unit Test, this idea is called like memory test for entity framework. You can do this via Moq Framework also. At the given, you can see a few sample about on.

You can also get detailed info about on at this link:
msdn.microsoft.com/en-us/library/dn314429(v=vs.113).aspx




The official web site for Moq : https://github.com/Moq/moq4/wiki/Quickstart


At the given link at below, you can find a simple implementation of Unit Test and Integrated Test.


