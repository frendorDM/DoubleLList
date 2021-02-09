using System;
using System.Text;
using NUnit.Framework;
using DoubleLList1;

namespace DoubleLListTests
{
  public class Tests
  {
    [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
    [TestCase(new int[] { 1, 2, 3, 4,5 }, new int[] { 5,4, 3, 2, 1 })] 
    [TestCase(new int[] { -1, -2, -3 }, new int[] { -3, -2, -1 })]
    [TestCase(new int[] { }, new int[] { })]
    public void ReverseTest(int[] array, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual.Reverse();
      Assert.AreEqual(expected, actual);

    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 4, new int[] { 1, 4, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 4, new int[] { 4, 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 4, new int[] { 1, 2, 3, 4, 4, 5 })]
    [TestCase(new int[] { 9, 9, 9, 9, 9 }, 5, 8, new int[] { 9, 9, 9, 9, 9, 8 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 4, new int[] { 1, 2, 3, 4, 4, 5 })]
    public void AddByIndexTest(int[] array, int index, int value, int[] expected)
    {

      DoubleLList Expect = new DoubleLList(expected);
      DoubleLList actual = new DoubleLList(array);
      actual.AddByIndex(index, value);
      Assert.AreEqual(Expect, actual);
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, -5, new int[] { -5, 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 0, 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 9, 9, 9,9, 9 }, 8, new int[] { 8,9, 9, 9, 9, 9 })]
    public void AddFirstTest(int[] array, int value, int[] expected)
    {

      DoubleLList Expect = new DoubleLList(expected);
      DoubleLList actual = new DoubleLList(array);
      actual.AddFirst(value);
      Assert.AreEqual(Expect, actual);
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, new int[] { 1, 2, 3, 4, 5, -1 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 2, 3, 4, 5, 0 })]
    [TestCase(new int[] { 9, 9, 9, 9, 9 }, 8, new int[] { 9, 9, 9, 9, 9, 8 })]
    public void AddTest(int[] array, int value, int[] expected)
    {

      DoubleLList Expect = new DoubleLList(expected);
      DoubleLList actual = new DoubleLList(array);
      actual.Add(value);
      Assert.AreEqual(Expect, actual);
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2, 3, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
    public void DeleteByIndexTest(int[] array, int index, int[] expected)
    {

      DoubleLList Expect = new DoubleLList(expected);
      DoubleLList actual = new DoubleLList(array);
      actual.DeleteByIndex(index);
      Assert.AreEqual(Expect, actual);
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
    [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -5)]
    [TestCase(new int[] { 1 }, 0, 1)]
    public void GetByIndexTest(int[] array, int index, int expected)
    {
      DoubleLList DlinkedList = new DoubleLList(array);

      int actual = DlinkedList[index];

      Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
    [TestCase(new int[] { 1, 2, -3, 4, 5 }, 2)]
    [TestCase(new int[] { 1, 2, 3, 4, }, 0)]
    public void GetIndexMinTest(int[] array, int expected)
    {
      DoubleLList actual = new DoubleLList(array);
      Assert.AreEqual(expected, actual.GetIndexMin());
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
    [TestCase(new int[] { 1, 2, -3, 4, 5 }, 4)]
    [TestCase(new int[] { 1, 2, 3, 4, }, 3)]
    [TestCase(new int[] { 1, 2, 3, 4,9,8,7 }, 4)]

    public void GetIndexMaxTest(int[] array, int expected)
    {
      DoubleLList actual = new DoubleLList(array);
      Assert.AreEqual(expected, actual.GetIndexMax());
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [TestCase(new int[] { 1, 2, 333, 4, 5 }, 333)]
    [TestCase(new int[] { 1, 2, 3, 4, -1, -2 }, 4)]
    public void GetMaxValueTest(int[] array, int expected)
    {
      DoubleLList actual = new DoubleLList(array);
      Assert.AreEqual(expected, actual.GetMaxValue());
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
    [TestCase(new int[] { 1, 2, 333, 4, 5 }, 1)]
    [TestCase(new int[] { 1, 2, 3, 4, -1, -2 }, -2)]
    public void GetMinValueTest(int[] array, int expected)
    {
      DoubleLList actual = new DoubleLList(array);
      Assert.AreEqual(expected, actual.GetMinValue());
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0,1, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 9, new int[] { 1, 2, 9, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5,6,7,8 }, 7, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 7 })]

    public void SetByIndexTest(int[] array, int index, int value, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual[index] = value;

      Assert.AreEqual(expected, actual);

    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 4)]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3)]
    [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -1)]
    [TestCase(new int[] { 1 }, 1, 0)]
    public void IndexByValueIndexTest(int[] array, int value, int expected)
    {
      DoubleLList actual = new DoubleLList(array);
      Assert.AreEqual(expected, actual.IndexByValue(value));

    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, -3, 4, 5 }, new int[] { -3, 1, 2, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, -5 }, new int[] { -5, 1, 2, 3, 4, })]
    public void ArraySortTest(int[] array, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual.ArraySort();

      Assert.AreEqual(expected, actual);

    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
    [TestCase(new int[] { 1, 2, -3, 4, 5 }, new int[] { 5, 4, 2, 1, -3 })]
    [TestCase(new int[] { 1, 2, 3, 4, -5 }, new int[] { 4, 3, 2, 1, -5 })]
    [TestCase(new int[] { }, new int[] { })]
    public void ArraySortReverseTest(int[] array, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual.ArraySortReverse();

      Assert.AreEqual(expected, actual);

    }


    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 4 }, new int[] { 1, 4, 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 0, -4 }, new int[] { 1, 2, 0, -4, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 4 }, new int[] { 1, 2, 3, 4, 1, 4, 5 })]
   
    public void AddByIndexArrayTest(int[] array, int index, int[] value, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual.AddByIndexArray(index, value);

      Assert.AreEqual(expected, actual);

    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 3, new int[] { 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1, new int[] { 1, 2, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 1, new int[] { 1, 2, 3, 4, })]
    public void DeleteByIndexNElementTest(int[] array, int index, int size, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual.DeleteByIndexNElement(index, size);

      Assert.AreEqual(expected, actual);

    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5, new int[] { 1, 2, 3, 4, })]
    public void DeleteByIndexNElementNegativTests(int[] array, int index, int value, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndexNElement(index, value));
    }
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 50, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, -50, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
    public void AddByIndexNegativTests(int[] array, int index, int value, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
    }

    [TestCase(new int[] { 1, 2, 3, 4, 1 }, new int[] { 2, 3, 4 })]
    [TestCase(new int[] { 1, 2, 1, 1, 1, 5 }, new int[] { 2, 5 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
    [TestCase(new int[] { -1, 2, 3, -1, -1 }, new int[] { 2, 3 })]
    public void DeleteByFirstTest(int[] array, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual.DeleteByFirst();
      Assert.AreEqual(expected, actual);

    }
    [TestCase(new int[] { 1, 2, 2, 9, 8, 1 }, 9, new int[] { 1, 2, 2, 8, 1 })]
    [TestCase(new int[] { 1, 2, 1, 2, 1 }, 1, new int[] { 2, 2 })]
    [TestCase(new int[] { 9, 9, 9,9,9,9,9,9,9,9 }, 9, new int[] { })]
    [TestCase(new int[] { 2, 2, 2, 2, 2, 2,6 }, 2, new int[] { 6 })]

    public void DeleteAllByValueTest(int[] array, int value, int[] expArray)
    {
      DoubleLList expected = new DoubleLList(expArray);
      DoubleLList actual = new DoubleLList(array);
      actual.DeleteAllByValue(value);
      Assert.AreEqual(expected, actual);

    }

  }
}