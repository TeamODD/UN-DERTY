using System.Collections.Generic;
using System;

public class PriorityQueue<T>
{
    private List<(T item, int priority)> heap = new List<(T, int)>();

    public int Count => heap.Count;

    public bool Contains(T targetItem)
    {
        foreach (var (item, _) in heap)
        {
            if (EqualityComparer<T>.Default.Equals(item, targetItem))
                return true;
        }
        return false;
    }
    public void Enqueue(T item, int priority)
    {
        heap.Add((item, priority));
        heapifyUp(heap.Count - 1);
    }

    public T Dequeue()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Queue is empty");
        T result = heap[0].item;
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        heapifyDown(0);
        return result;
    }

    private void heapifyUp(int index)
    {
        while (index > 0 && heap[index].priority < heap[(index - 1) / 2].priority)
        {
            (heap[index], heap[(index - 1) / 2]) = (heap[(index - 1) / 2], heap[index]);
            index = (index - 1) / 2;
        }
    }

    private void heapifyDown(int index)
    {
        int lastIndex = heap.Count - 1;
        while (true)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int smallest = index;

            if (left <= lastIndex && heap[left].priority < heap[smallest].priority)
                smallest = left;
            if (right <= lastIndex && heap[right].priority < heap[smallest].priority)
                smallest = right;

            if (smallest == index) break;

            (heap[index], heap[smallest]) = (heap[smallest], heap[index]);
            index = smallest;
        }
    }
}