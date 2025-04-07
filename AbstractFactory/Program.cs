// See https://aka.ms/new-console-template for more information

using AbstractFactory;

Console.WriteLine("抽象工厂模式!");

var windowFactory = new WindowsFactory();
var wb = windowFactory.CreateButton();
wb.Render();
var wt = windowFactory.CreateTextBox();
wt.Display();
Console.WriteLine(new string('=', 50));
var macFactory = new MacFactory();
var mb = macFactory.CreateButton();
mb.Render();
var mt = macFactory.CreateTextBox();
mt.Display();