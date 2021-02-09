using System;

namespace DoubleLList1
{
  public class DoubleLList
  {

    public int Length { get; private set; }
    private Node _head;
    private Node _end;
    DoubleLList()
    {
      Length = 0;
      _head = null;
      _end = null;
    }

    public DoubleLList(int[] array)
    {
      Length = array.Length;

      if (array.Length != 0)
      {
        _head = new Node(array[0]);
        Node tmp = _head;
        for (int i = 1; i < array.Length; i++)
        {
          tmp.Next = new Node(array[i]);
          Node current = tmp;
          tmp = tmp.Next;
          tmp.Previous = current;
        }
        _end = tmp;
      }
      else
      {
        _head = null;
        _end = null;
      }
    }
    // добавление значения в конец
    public void Add(int value)
    {
      AddByIndex(Length, value);
    }
    // добавление значения в начало
    public void AddFirst(int value)
    {
      AddByIndex(0, value);
    }
    // добавление значения по индексу
    public void AddByIndex(int index, int value)
    {
      if (index < 0 || index > Length)
      {
        throw new IndexOutOfRangeException();
      }
      if (index != 0)
      {
        Node current = EndOrHead(index);
        if (current == _head)
        {
          for (int i = 0; i < index - 1; i++)
          {
            current = current.Next;
          }
          Node tmp = new Node(value);
          tmp.Next = current.Next;
          current.Next = tmp;
          tmp.Previous = current;
          current = current.Next;
          current = current.Next;
          current.Previous = tmp;
        }
        else
        {
          if (index == Length)
          {
            Node tmp = new Node(value);
            tmp.Previous = current;
            current.Next = tmp;
            _end = tmp;

          }
          else
          {
            for (int i = 0; i < Length - index - 1; i++)
            {
              current = current.Previous;
            }
            Node tmp = new Node(value);
            tmp.Previous = current.Previous;
            current.Previous = tmp;
            current = current.Previous;
            current = current.Previous;
            tmp.Next = current.Next;
            current.Next = tmp;
          }
        }

      }
      else
      {
        Node tmp = new Node(value);
        tmp.Next = _head;
        _head.Previous = tmp;
        _head = tmp;
      }
      Length++;
    }
    //удаление из начала одного элемента
    public void DeleteFirst()
    {
      DeleteByIndex(0);
    }
    // удаление из конца одного элемента
    public void DeleteLast()
    {
      DeleteByIndex(Length - 1);
    }
    // удаление значения по индексу
    public void DeleteByIndex(int index)
    {
      if (index < 0 || index >= Length)
      {
        throw new IndexOutOfRangeException();
      }
      if (index != 0)
      {
        Node current = EndOrHead(index);
        if (current == _head)
        {
          for (int i = 0; i < index - 1; i++)
          {
            current = current.Next;
          }
          Node tmp = current;
          tmp = tmp.Next;
          current.Next = tmp.Next;
          tmp.Next = null;
          current = current.Next;
          if (current != null)
          {
            current.Previous = tmp.Previous;
          }

          tmp.Previous = null;
        }
        else
        {
          if (index == Length - 1)
          {

            Node tmp = current;
            tmp = tmp.Previous;
            _end = tmp;
            current.Next = null;
            current.Previous = null;
          }
          else
          {
            for (int i = 0; i < Length - index - 2; i++)
            {
              current = current.Previous;
            }
            Node tmp = current;
            tmp = tmp.Previous;
            current.Previous = tmp.Previous;
            tmp.Previous = null;
            current = current.Previous;
            current.Next = tmp.Next;
            tmp.Next = null;
          }
        }
      }
      else
      {
        Node current = _head;
        Node tmp = current;
        tmp = tmp.Next;
        _head = tmp;
        current.Next = null;
        current.Previous = null;
      }
      Length--;
    }
    // вернуть длинну
    public int GetLength()
    {
      return Length;
    }
    // доступ по индексу 

    //индекс по значению
    public int IndexByValue(int value)
    {
      Node current = _head;
      for (int i = 0; i < Length; i++)
      {
        if (current.Value == value)
        {
          return i;
        }
        current = current.Next;
      }
      return -1;
    }
    // изменение по индексу

    //поиск значения максимального элемента
    public int GetMaxValue()
    {
      Node current = _head;
      for (int i = 0; i < GetIndexMax(); i++)
      {
        current = current.Next;
      }
      return current.Value;
    }
    //поиск значения минимального элемента
    public int GetMinValue()
    {
      Node current = _head;
      for (int i = 0; i < GetIndexMin(); i++)
      {
        current = current.Next;
      }
      return current.Value;
    }
    // поиск индекса минимального элемента
    public int GetIndexMin()
    {
      if (Length == 0)
      {
        throw new Exception("Массив пустой");
      }
      int index = 0;
      int max = _head.Value;
      Node tmp = _head;
      tmp = tmp.Next;
      for (int i = 1; i < Length; i++)
      {
        if (max > tmp.Value)
        {
          max = tmp.Value;
          index = i;
        }
        tmp = tmp.Next;
      }
      return index;
    }
    // сортировка
    public void ArraySort()
    {
      Node currenti = _head;
      for (int i = 0; i < Length; i++)
      {
        Node currentj = _head;
        currentj = currentj.Next;
        for (int j = 1; j < Length; j++)
        {
          if (j > i)
          {
            if (currenti.Value > currentj.Value)
            {

              int tmp;
              tmp = currenti.Value;
              currenti.Value = currentj.Value;
              currentj.Value = tmp;
            }
          }
          currentj = currentj.Next;
        }
        currenti = currenti.Next;
      }
    }
    // сортировка обратная
    public void ArraySortReverse()
    {
      Node currenti = _head;
      for (int i = 0; i < Length; i++)
      {
        Node currentj = _head;
        currentj = currentj.Next;
        for (int j = 1; j < Length; j++)
        {
          if (j > i)
          {
            if (currenti.Value < currentj.Value)
            {
              int tmp;
              tmp = currenti.Value;
              currenti.Value = currentj.Value;
              currentj.Value = tmp;
            }
          }
          currentj = currentj.Next;
        }
        currenti = currenti.Next;
      }
    }
    // поиск индекса максимального элемента
    public int GetIndexMax()
    {
      if (Length == 0)
      {
        throw new Exception("Массив пустой");
      }
      int index = 0;
      int max = _head.Value;
      Node tmp = _head;
      tmp = tmp.Next;
      for (int i = 1; i < Length; i++)
      {
        if (max < tmp.Value)
        {
          max = tmp.Value;
          index = i;
        }
        tmp = tmp.Next;
      }
      return index;
    }
    //Реверс
    public void Reverse()

    {
      Node left = _head, right = _end;
      while (left != right && left.Previous != right)

      {
        int tmp = left.Value;
        left.Value = right.Value;
        right.Value = tmp;
        left = left.Next;
        right = right.Previous;
      }

    }
    //удаление по значению первого
    public void DeleteByFirst()
    {
      int value = _head.Value;
      int v = Length;
      for (int j = 0; j < v; j++)
      {
        int index = IndexByValue(value);
        if (index != -1)
        {
          DeleteByIndex(index);

        }
        else
        {
          return;
        }
      }
    }
    //удаление по значению всех
    public void DeleteAllByValue(int value)
    {

      int v = Length;
      for (int j = 0; j < v; j++)
      {
        int index = IndexByValue(value);
        if (index != -1)
        {
          DeleteByIndex(index);
        }
        else
        {
          return;
        }
      }
    }
    //добавление массива в конец
    public void AddEndArray(int[] array)
    {
      for (int i = 0; i < array.Length; i++)
      {
        AddByIndex(Length + i, array[i]);
      }
    }
    // добавление массива в начало
    public void AddHeadArray(int[] array)
    {
      for (int i = 0; i < array.Length; i++)
      {
        AddByIndex(i, array[i]);
      }
    }
    // добавление массива по индексу
    public void AddByIndexArray(int index, int[] array)
    {
      for (int i = 0; i < array.Length; i++)
      {
        AddByIndex(index + i, array[i]);
      }
    }
    // удаление по индексу N элементов
    public void DeleteByIndexNElement(int index, int size)
    {
      if (size > Length - index)
      {
        throw new IndexOutOfRangeException();
      }
      for (int i = 0; i < size; i++)
      {
        DeleteByIndex(index);
      }
    }
    //удаление из конца N элементов
    public void DeleteN(int size)
    {
      for (int i = 0; i < size; i++)
      {
        DeleteLast();
      }
    }
    //удаление из начала N элементов
    public void DeleteNFirst(int size)
    {
      for (int i = 0; i < size; i++)
      {
        DeleteFirst();
      }
    }

    private Node EndOrHead(int index)
    {
      if (index > Length / 2)
      {

        return _end;
      }
      else
      {

        return _head;
      }
    }
    
    
    public int this[int index]
    {
      get
      {
        if (index > Length - 1 || index < 0)
        {
          throw new IndexOutOfRangeException();
        }
        Node tmp = EndOrHead(index);
        if (tmp == _head)
        {
          for (int i = 0; i < index; i++)
          {
            tmp = tmp.Next;
          }
          return tmp.Value;
        }
        else
        {
          for (int i = 0; i < Length - index - 1; i++)
          {
            tmp = tmp.Previous;
          }
          return tmp.Value;
        }
      }

      set
      {
        if (index > Length - 1 || index < 0)
        {
          throw new IndexOutOfRangeException();
        }
        Node tmp = EndOrHead(index);
        if (tmp == _head)
        {
          for (int i = 0; i < index; i++)
          {
            tmp = tmp.Next;
          }
          tmp.Value = value;
        }
        else
        {
          for (int i = 0; i < Length - index - 1; i++)
          {
            tmp = tmp.Previous;
          }
          tmp.Value = value;
        }
      }
    }
    
    
    public override bool Equals(object obj)
    {
      DoubleLList DoublelinkedList = (DoubleLList)obj;

      if (Length != DoublelinkedList.Length)
      {
        return false;
      }

      Node tmp = _head;
      Node tmpobj = DoublelinkedList._head;

      for (int i = 0; i < Length; i++)
      {
        if (tmp.Value != tmpobj.Value)
        {
          return false;
        }
        tmp = tmp.Next;
        tmpobj = tmpobj.Next;
      }
      Node current = _end;
      Node currentobj = DoublelinkedList._end;
      for (int j = 0; j < Length; j++)
      {
        if (current.Value != currentobj.Value)
        {
          return false;
        }
        current = current.Previous;
        currentobj = currentobj.Previous;
      }
      return true;
    }
    public override string ToString()
    {
      string s = "";

      Node tmp = _head;
      for (int i = 0; i < Length; i++)
      {
        s += tmp.Value + ";";
        tmp = tmp.Next;
      }
      return s;
    }
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }
}

