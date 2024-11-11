namespace TDD2
{
class MyStack : IStack
    {
    // ---- INITIALIZERS START ---- //
    public MyStack(MyStack instance)
    {
        if (instance.head == null) throw new NullReferenceException();

        Node? temp = instance.head;
        Node? newHead = null;
        Node? current = null;

        while (temp != null)
        {
            Node newNode = new Node(temp.data);

            if (newHead == null)
            {
                newHead = newNode;
                current = newNode;
            }
            else
            {
                current.next = newNode;
                current = newNode;
            }

            capacity++;
            temp = temp.next;
        }

        this.head = newHead;
    }

    public MyStack(List<bool> values)
    {
        int size = values.Count;
        while (size >= 1)
        {
            Push(values[size - 1]);
            size--;
        }
    }

    public MyStack()
    {

    }
    // ---- INITIALIZERS END ---- //


    public bool this[int index]
    {
        get
        {
            if (head == null) throw new NullReferenceException();
            if (index >= capacity) throw new IndexOutOfRangeException();

            int currentIndex = 0;
            Node? temp = head;

            while (currentIndex < index)
            {
                temp = temp.next;
                currentIndex++;
            }

            return temp.data;
        }
        set
        {
            if (head == null) throw new NullReferenceException();
            if (index >= capacity) throw new IndexOutOfRangeException();

            int currentIndex = 0;
            Node? temp = head;

            while (currentIndex < index)
            {
                temp = temp.next;
                currentIndex++;
            }

            temp.data = value;
        }
    }

    class Node
    {
        public bool data;
        public Node? next;
        public Node(bool data)
        {
            this.data = data;
            this.next = null;
        }
    }


    // ---- DATAS START ---- //
    Node? head;
    public int capacity { get; private set; } = 0;
    // ---- DATAS END ---- //


    // ---- FUNCTIONS START ---- //

    public void Push(bool data)
    {
        Node temp = new Node(data);
        temp.next = head;
        head = temp;

        capacity++;
    }

    public void Pop()
    {
        if (head == null) throw new NullReferenceException();

        Console.WriteLine(head.data);
        head = head.next;

        capacity--;
    }

    public bool GetTop()
    {
        if (head == null) throw new NullReferenceException();

        return head.data;
    }

    public new string ToString()
    {
        if (head == null) throw new NullReferenceException();

        string output = "";
        Node temp = head;

        while (temp.next != null)
        {
            output += temp.data;
            output += ',';
            temp = temp.next;
        }
        output += temp.data;
        return output;
    }
    // ---- FUNCTIONS END ---- //


    // ---- OPERATORS START ---- //
    public static MyStack operator <(MyStack stack, bool data)
    {
        Node temp = new Node(data);
        temp.next = stack.head;
        stack.head = temp;


        stack.capacity++;
        return stack;
    }

    public static MyStack operator >(MyStack stack, bool remove)
    {
        if (stack.head == null) throw new NullReferenceException();

        if (remove == true)
        {
            stack.head = stack.head.next;
            stack.capacity--;
        }

        return stack;
    }


    public static bool operator >=(MyStack stack, MyStack stack1)
    {
        if (stack.capacity >= stack1.capacity) return true;
        return false;
    }
    public static bool operator <=(MyStack stack, MyStack stack1)
    {
        if (stack.capacity <= stack1.capacity) return true;
        return false;
    }


    public static bool operator ==(MyStack stack, MyStack stack1)
    {
        if (stack.head == null || stack1.head == null)
            throw new NullReferenceException();

        if (stack.capacity != stack1.capacity) return false;
        
        Node? temp = stack.head;
        Node? temp1 = stack1.head;

        while (temp != null)
        {
            if (temp.data != temp1.data) return false;

            temp = temp.next;
            temp1 = temp1.next;
        }

        return true;
    }

    public static bool operator !=(MyStack stack, MyStack stack1)
    {
        return !(stack == stack1);
    }


    public static bool operator false(MyStack stack)
    {
        return stack.head == null;
    }
    public static bool operator true(MyStack stack)
    {
        return stack.head != null;
    }
    // ---- OPERATORS END ---- //


    // ---- TYPE CASTING START ---- //
    public static explicit operator List<bool>(MyStack stack)
    {
        if (stack.head == null) throw new NullReferenceException();

        List<bool> result = new List<bool>(stack.capacity);

        Node temp = stack.head;

        while (temp.next != null)
        {
            result.Add(temp.data);
            temp = temp.next;
        }

        result.Add(temp.data);

        return result;
    }

    public static implicit operator MyStack(List<bool> values)
    {
        return new MyStack(values);
    }

    // ---- TYPE CASTING END ---- //
}
}
