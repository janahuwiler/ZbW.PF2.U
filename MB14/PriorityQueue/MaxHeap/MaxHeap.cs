﻿namespace MB14.PriorityQueue.MaxHeap
{
    public class MaxHeap
    {
        private int[] Heap { get; set; }
        private int Size { get; set; }
        private int Capacity { get; set; }

        public MaxHeap(int capacity)
        {
            this.Capacity = capacity;
            Heap = new int[capacity];
            Size = 0;
        }

        #region Iterativ Enqueue
        public void Enqueue(int value)
        {
            if (Size < Capacity)
            {
                Size++;
                int currentIndex = Size - 1;
                Heap[currentIndex] = value;

                while (currentIndex > 0 && Heap[GetParentIndex(currentIndex)] < Heap[currentIndex])
                {
                    var parentIndex = GetParentIndex(currentIndex);
                    Swap(currentIndex, parentIndex);
                    currentIndex = parentIndex;
                }
            }
        }

        private int GetParentIndex(int index)
        {
            var parentIndex = (index - 1) / 2;
            return parentIndex;
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            int temp = Heap[currentIndex];
            Heap[currentIndex] = Heap[parentIndex];
            Heap[parentIndex] = temp;
        }
        #endregion

        #region Recursive Enqueue
        public void EnqueueRecursive(int value)
        {
            if (Size < Capacity)
            {
                Size++;
                int currentIndex = Size - 1;
                Heap[currentIndex] = value;

                BubbleUp(currentIndex);
            }
        }

        private void BubbleUp(int index)
        {
            if (index == 0)
                return;

            int parentIndex = GetParentIndex(index);
            if (Heap[parentIndex] < Heap[index])
            {
                Swap(parentIndex, index);
                BubbleUp(parentIndex);
            }
        }

        #endregion

        #region Dequeue
        public int Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            int root = Heap[0];
            Heap[0] = Heap[Size - 1];
            Size--;
            var index = 0;
            var largestValueOnTop = false;
            while (!largestValueOnTop)
            {
                int largest = index;
                int leftChild = GetLeftChildIndex(index);
                int rightChild = GetRightChildIndex(index);

                if (leftChild < Size && Heap[leftChild] > Heap[largest])
                {
                    largest = leftChild;
                }

                if (rightChild < Size && Heap[rightChild] > Heap[largest])
                {
                    largest = rightChild;
                }

                if (largest == index)
                {
                    largestValueOnTop = true;
                }

                Swap(index, largest);
                index = largest;
            }

            return root;
        }



        #endregion

        #region Recursive Dequeue
        public int DequeueRecursive()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            int root = Heap[0];
            Heap[0] = Heap[Size - 1];
            Size--;
            BubbleDown(0);

            return root;
        }

        private void BubbleDown(int index)
        {
            int largest = index;
            int leftChild = GetLeftChildIndex(index);
            int rightChild = GetRightChildIndex(index);

            if (leftChild < Size && Heap[leftChild] > Heap[largest])
            {
                largest = leftChild;
            }

            if (rightChild < Size && Heap[rightChild] > Heap[largest])
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                Swap(index, largest);
                BubbleDown(largest);
            }
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        #endregion


        public void PrintHeap()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.Write(Heap[i] + " ");
            }
            Console.WriteLine();
        }
    }

}

