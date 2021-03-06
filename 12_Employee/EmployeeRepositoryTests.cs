﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _12_Employee
{
    [TestClass]
    public class EmployeeRepostioryTests
    {
        private EmployeeRepository CreateRepository()
        {
            return new EmployeeRepository();
        }

        [TestMethod]
        public void Clear() 
        {
            EmployeeRepository repository = CreateRepository();
            repository.Clear();
            Assert.AreEqual(0, repository.CountEmployees());
            IEmployee simon = repository.CreateEmployee("Simon Stochholm", "Teacher");
            Assert.AreEqual(1, repository.CountEmployees());
            repository.Clear();
            Assert.AreEqual(0, repository.CountEmployees());
            
        }
        
        [TestMethod]
        public void Create() 
        {
            EmployeeRepository repository = CreateRepository();
            repository.Clear();
            IEmployee simon = repository.CreateEmployee("Simon Stochholm", "Teacher");
            Assert.AreEqual("Simon Stochholm", simon.Name);
            Assert.AreEqual("Teacher", simon.Type);
            Assert.IsTrue(simon.Id != 0);
            IEmployee nick = repository.CreateEmployee("Nick Chaffee", "Translator");
            Assert.IsTrue(nick.Id != 0);
            Assert.IsTrue(nick.Id != simon.Id);
        }
        
        [TestMethod]
        public void SaveAndCount() 
        {
            EmployeeRepository repository = CreateRepository();
            repository.Clear();
            IEmployee simon = repository.CreateEmployee("Simon Stochholm", "Teacher");
            repository.SaveEmployee(simon);
            Assert.AreEqual(1, repository.CountEmployees());
            
        }
        
        [TestMethod]
        public void SaveAndLoad() 
        {
            EmployeeRepository repository = CreateRepository();
            repository.Clear();
            IEmployee simon = repository.CreateEmployee("Simon Stochholm", "Teacher");
            repository.SaveEmployee(simon);
            IEmployee loadedsimon = repository.LoadEmployee(simon.Id);
            Assert.AreEqual(simon, loadedsimon);
            
        }
        
        [TestMethod]
        public void SaveAndLoadTwoEmployees() 
        {
            EmployeeRepository repository = CreateRepository();
            repository.Clear();
            IEmployee simon = repository.CreateEmployee("Simon Stochholm", "Teacher");
            repository.SaveEmployee(simon);
            IEmployee nick = repository.CreateEmployee("Nick Chaffee", "Translator");
            repository.SaveEmployee(nick);
            Assert.AreEqual(2, repository.CountEmployees());
            IEmployee loadedNick = repository.LoadEmployee(nick.Id);
            Assert.AreEqual(nick, loadedNick);
            
        }
        
        [TestMethod]
        public void FindAllEmployees() 
        {
            EmployeeRepository repository = CreateRepository();
            repository.Clear();
            IEmployee simon = repository.CreateEmployee("Simon Stochholm", "Teacher");
            repository.SaveEmployee(simon);
            IEmployee nick = repository.CreateEmployee("Nick Chaffee", "Translator");
            repository.SaveEmployee(nick);

            List<IEmployee> all = repository.FindAllEmployees();
            CollectionAssert.Contains(all, simon);
            CollectionAssert.Contains(all, nick);
            
        }
        
        [TestMethod]
        public void ChangeData() 
        {
            EmployeeRepository repository = CreateRepository();
            repository.Clear();
            IEmployee nick = repository.CreateEmployee("Nick Chaffee", "Translator");
            repository.SaveEmployee(nick);
            nick.Type = "Sous chef";
            repository.SaveEmployee(nick);
            nick = repository.LoadEmployee(nick.Id);
            Assert.AreEqual("Sous chef", nick.Type);
            
        }
        
    }
}
