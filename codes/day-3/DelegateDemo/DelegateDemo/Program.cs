// See https://aka.ms/new-console-template for more information
using DelegateDemo;
using System.Reflection;

Trainer joydipTrainer = new() { Assistant = new Assistant { Name = "anil" } };
joydipTrainer.UseFacilities();

//2. how to use delegate
//a. create an instance of a delegate and pass the reference to the method

//i. when the method is instance method
//if the method is instance method then first create the instance of that class
Facilities facilities = new();
FacilityInvoker markerInvoker = new(facilities.GetMarker);

//ii. when the method is static method
//if the method is static method then simply pass the method name withe the class name (no need to instantiate that class)
FacilityInvoker waterInvoker = new(Facilities.GetWaterBolltles);


//b. invoke the delegate instance(s) to call the methods
Console.WriteLine(markerInvoker(2));
Console.WriteLine(waterInvoker.Invoke(1));

//MethodInfo? methodInfo = facilities.GetType().GetMethod("GetMarker");
//Console.WriteLine(methodInfo?.Invoke(facilities, new object[] { 2 }));
