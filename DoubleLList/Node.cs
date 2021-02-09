﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLList1
{
  public class Node
  {
    public int Value { get; set; }
    public Node Next { get; set; }
    public Node Previous { get; set; }
    public Node()
    {
      Next = null;
      Previous = null;
    }
    public Node(int value)
    {
      Value = value;
      Next = null;
      Previous = null;
    }
  }
}
