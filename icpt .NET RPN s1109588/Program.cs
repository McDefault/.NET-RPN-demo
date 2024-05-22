// See https://aka.ms/new-console-template for more information

using icpt_.NET_RPN_s1109588;

Console.WriteLine("Hello, World!");

string RPNnotatie = "123++";

RpnEvaluator myObject = new RpnEvaluator(RPNnotatie);

myObject.MyStack.Push(1);
myObject.MyStack.Pop();
myObject.MyStack.Push(1);
myObject.MyStack.Push("+");
// myObject.PrintString();





