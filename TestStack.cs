using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD2;

namespace TDD2
{
    [TestClass]
    public class MyStack_Test
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PopStack_PopFromEmptyStack_ThrowsNullReferenceException()
        {
            MyStack stack = new MyStack();

            stack.Pop();
        }

        [TestMethod]
        public void ToString_ConvertStackToString_ReturnsStringValue()
        {
            MyStack stack = new MyStack();
            
            stack.Push(false);
            stack.Push(false);
            stack.Push(true);
            
            Assert.AreEqual(stack.ToString(), "True,False,False");
        }

        [TestMethod]
        public void Push_AddElementToStack_WhenStackIsEmpty()
        {
            MyStack stack = new MyStack();
            
            stack.Push(true);

            Assert.AreEqual(true, stack.GetTop());
        }

        [TestMethod]
        public void Push_AddElementToStack_WhenStackIsNotEmpty()
        {
            MyStack stack = new MyStack();

            stack.Push(true); 
            stack.Push(false);

            Assert.AreEqual(false, stack.GetTop()); 
            stack.Pop(); 
            Assert.AreEqual(true, stack.GetTop()); 
        }

        [TestMethod]
        public void Push_ShouldIncreaseCapacity()
        {
            MyStack stack = new MyStack();
            int initialCapacity = stack.capacity;

            stack.Push(true);

            Assert.AreEqual(initialCapacity + 1, stack.capacity);
        }

        [TestMethod]
        public void OperatorLessThan_AddElementToStack_WhenStackIsNotEmpty()
        {
            MyStack stack = new MyStack();
       
            _ = stack < true;
            _ = stack < false;

            Assert.AreEqual(false, stack.GetTop());
            stack.Pop();
            Assert.AreEqual(true, stack.GetTop());
        }

        [TestMethod]
        public void OperatorGreaterThan_RemoveElementFromStack()
        {
            MyStack stack = new MyStack();
            stack.Push(true);
            stack.Push(false);

            _ = stack > true;
            Assert.AreEqual(true, stack.GetTop());
        }

        [TestMethod]
        public void Constructor_CopyingConstructor_WhenStackIsNotEmpty()
        {
            // Arrange
            MyStack stack = new MyStack();
            stack.Push(false);
            stack.Push(true);
            stack.Push(true);

            MyStack mock = new MyStack(stack);

            Assert.IsTrue(mock == stack);

            stack.Pop();

            Assert.IsTrue(mock != stack);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_CopyingConstructor_WhenStackIEmpty()
        {
            MyStack stack = new MyStack();
            MyStack mock = new MyStack(stack);
        }

        [TestMethod]
        public void Constructor_CopyingConstructor_ShouldNotModifyOriginalStack()
        {                                      
            MyStack stack = new MyStack();
            stack.Push(false);
            stack.Push(false);
            stack.Push(true);

            MyStack mock = new MyStack(stack);

            mock.Pop();

            Assert.IsTrue(stack != mock);
        }

        [TestMethod]
        public void Constructor_FromListToStack_AreEqual()
        {
            List<bool> mockList = new List<bool> { true, false, false };
            MyStack mock = new MyStack(mockList);

            Assert.AreEqual(mock.ToString(), "True,False,False");
        }

        [TestMethod]
        public void Constructor_InitializesEmptyStack_CapacityIsZero()
        {
            MyStack stack = new MyStack();

            Assert.AreEqual(0, stack.capacity);
        }

        [TestMethod]
        public void OperatorTrue_ShouldReturnTrue_WhenHeadIsNotNull()
        {
            MyStack stack = new MyStack();
            stack.Push(true);

            bool result = stack ? true : false;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorTrue_ShouldReturnFalse_WhenHeadIsNull()
        {
            MyStack stack = new MyStack();

            bool result = stack ? true : false;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorLessThanOrEqual_StackWithSmallerCapacity_ReturnsTrue()
        {
            MyStack stack1 = new MyStack();
            MyStack stack2 = new MyStack();
            stack1.Push(true);

            Assert.IsFalse(stack1 <= stack2);
        }

        [TestMethod]
        public void OperatorGreaterThanOrEqual_StackWithGreaterCapacity_ReturnsTrue()
        {
            MyStack stack1 = new MyStack();
            MyStack stack2 = new MyStack();
            stack1.Push(true);
            stack1.Push(false);

            Assert.IsTrue(stack1 >= stack2);
        }

        [TestMethod]
        public void ImplicitConversion_ListToStack_CreatesStackWithSameValues()
        {
            List<bool> list = new List<bool> { true, false, true };
            MyStack stack = list;

            Assert.AreEqual("True,False,True", stack.ToString());
        }

        [TestMethod]
        public void ExplicitConversion_StackToList_CreatesListWithSameValues()
        {
            MyStack stack = new MyStack();
            stack.Push(true);
            stack.Push(false);
            stack.Push(true);

            List<bool> list = (List<bool>)stack;

            CollectionAssert.AreEqual(new List<bool> { true, false, true }, list);
        }

        [TestMethod]
        public void Indexer_Get_ReturnsCorrectValue()
        {
            MyStack stack = new MyStack();
            stack.Push(false);
            stack.Push(true);
            stack.Push(true);

            Assert.AreEqual(true, stack[0]);
            Assert.AreEqual(true, stack[1]);
            Assert.AreEqual(false, stack[2]);
        }

        [TestMethod]
        public void Indexer_Set_ModifiesValueAtGivenIndex()
        {
            MyStack stack = new MyStack();
            stack.Push(false);
            stack.Push(true);
            stack[0] = false;

            Assert.AreEqual(false, stack[0]);
        }

    }
}
