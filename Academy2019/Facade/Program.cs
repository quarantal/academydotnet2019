﻿// EN: Facade Design Pattern
//
// Intent: Provides a simplified interface to a library, a framework, or any
// other complex set of classes.
//
// RU: Паттерн Фасад
//
// Назначение: Предоставляет простой интерфейс к сложной системе классов,
// библиотеке или фреймворку.

using System;

namespace RefactoringGuru.DesignPatterns.Facade.Conceptual
{
    // EN: The Facade class provides a simple interface to the complex logic of
    // one or several subsystems. The Facade delegates the client requests to
    // the appropriate objects within the subsystem. The Facade is also
    // responsible for managing their lifecycle. All of this shields the client
    // from the undesired complexity of the subsystem.
    //
    // RU: Класс Фасада предоставляет простой интерфейс для сложной логики одной
    // или нескольких подсистем. Фасад делегирует запросы клиентов
    // соответствующим объектам внутри подсистемы. Фасад также отвечает за
    // управление их жизненным циклом. Все это защищает клиента от нежелательной
    // сложности подсистемы.
    public class Facade
    {
        protected Subsystem1 _subsystem1;
		
        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }
		
        // EN: The Facade's methods are convenient shortcuts to the
        // sophisticated functionality of the subsystems. However, clients get
        // only to a fraction of a subsystem's capabilities.
        //
        // RU: Методы Фасада удобны для быстрого доступа к сложной
        // функциональности подсистем. Однако клиенты получают только часть
        // возможностей подсистемы.
        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this._subsystem1.operation1();
            result += this._subsystem2.operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this._subsystem1.operationN();
            result += this._subsystem2.operationZ();
            return result;
        }
    }
    
    // EN: The Subsystem can accept requests either from the facade or client
    // directly. In any case, to the Subsystem, the Facade is yet another
    // client, and it's not a part of the Subsystem.
    //
    // RU: Подсистема может принимать запросы либо от фасада, либо от клиента
    // напрямую. В любом случае, для Подсистемы Фасад – это еще один клиент, и
    // он не является частью Подсистемы.
    public class Subsystem1
    {
        public string operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string operationN()
        {
            return "Subsystem1: Go!\n";
        }
    }
	
    // EN: Some facades can work with multiple subsystems at the same time.
    //
    // RU: Некоторые фасады могут работать с разными подсистемами одновременно.
    public class Subsystem2
    {
        public string operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string operationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }


    class Client
    {
        // EN: The client code works with complex subsystems through a simple
        // interface provided by the Facade. When a facade manages the lifecycle
        // of the subsystem, the client might not even know about the existence
        // of the subsystem. This approach lets you keep the complexity under
        // control.
        //
        // RU: Клиентский код работает со сложными подсистемами через простой
        // интерфейс, предоставляемый Фасадом. Когда фасад управляет жизненным
        // циклом подсистемы, клиент может даже не знать о существовании
        // подсистемы. Такой подход позволяет держать сложность под контролем.
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // EN: The client code may have some of the subsystem's objects
            // already created. In this case, it might be worthwhile to
            // initialize the Facade with these objects instead of letting the
            // Facade create new instances.
            //
            // RU: В клиентском коде могут быть уже созданы некоторые объекты
            // подсистемы. В этом случае может оказаться целесообразным
            // инициализировать Фасад с этими объектами вместо того, чтобы
            // позволить Фасаду создавать новые экземпляры.
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            Client.ClientCode(facade);
        }
    }
}
