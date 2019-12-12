# Introduction
Edinburgh Health Board provide a number of services to elderly and housebound clients. A system is
required to ensure to keep track of visits that must be made to clients.
# Tasks
- Design the classes and appropriate relationships for the business and data layers. Make sure
that your design is captured in a class diagram. Make appropriate use of design patterns.
Your initial design should allow the storing of Staff, Clients and Visits.
- Implement your design from task 1 using c# within the Business Layer Project and within a
Data Layer project. Test your design by using the Add Staff, Clients and Visit buttons. 
- Modify the add visit mechanism to check that the staff and patient ids exist – throw an
exception if they do not.
- Use the c# DateTime class to store appointment times.
- Modify the add visit mechanism to check that the visit is of a valid type – throw an exception
if it is not.
- Modify the add visit mechanism to check that the appropriate number and grade of staff are
being sent.
- Implement a Save mechanism (HealthFacade.save) that saves Clients, Staff and Visits to a
file.
- Implement a load mechanism (HealthFacade.load) that loads Clients, Staff and Visits from a
file.
- Add a mechanism for checking if an appointment causes a clash with another appointment
(you need to check for clashes with each member of staff and with the client), make sure
that HealthFacacde throws an exception.
- Create a unit test for one of your classes, using the Visual Studio testing framework.
Demonstrate the instantiation of the object under test and the correct assertion of expected
actual results.
