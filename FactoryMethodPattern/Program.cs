// See https://aka.ms/new-console-template for more information

using FactoryMethodPattern;

Console.WriteLine("工厂方法模式!");

LoggerCreator fileLogger = new FileLoggerCreator();
fileLogger.Log("记录到文件中");

LoggerCreator databaseLogger = new DatabaseLoggerCreator();
databaseLogger.Log("记录到数据库中");