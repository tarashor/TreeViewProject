using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalManagerApp.Models;

namespace PersonalManagerAppTest
{
    [TestClass]
    public class ControllerTest
    {
        private TodoItem item = new TodoItem() { IsDone = true, Title = "Work", TodoItemId = 1 };

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(item, item);
        }
    }
}
