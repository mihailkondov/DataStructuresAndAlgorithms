namespace LinearDataStructures.Stack
{
	public class StackDynamic<T> : IStack<T>
	{
        public StackDynamic()
        {
            Count = 0;
        }

        public StackDynamic(T data)
        {
			Push(data);
        }

		public StackDynamic(T[] dataArray)
		{
			for(int i = 0; i<dataArray.Length; i++)
			{
				Push(dataArray[i]);
			}
		}

        public int Count { get; private set; }

		public DynamicStackNode<T>? Top { get; private set; } = null;

        public T Peek()
		{
			if (Top == null) throw new InvalidOperationException("Stack is empty");

			return Top.Data;
		}

		public T Pop()
		{
			if (Top == null) throw new InvalidOperationException("Stack is empty");

			T data = Top.Data;
			if(Top.Next != null)
				Top = Top.Next;
			Count--;
			return data;
		}

		public void Push(T data)
		{
			DynamicStackNode<T> newNode = new DynamicStackNode<T>(data);
			newNode.Next = Top;
			Top = newNode;
			Count++;
		}
	}
}
