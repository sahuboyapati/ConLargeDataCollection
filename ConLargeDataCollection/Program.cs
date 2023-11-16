using System;
using System.Collections.Generic;

namespace ConLargeDataCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of LargeDataCollection
            string[] initialData = { "one", "two", "three", "four", "five" };
            using (LargeDataCollection<string> dataCollection = new LargeDataCollection<string>(initialData))
            {
                // Demonstrate adding, removing, and accessing elements
                dataCollection.AddElement("six");
                dataCollection.RemoveElement("three");
                Console.WriteLine("Accessed element: " + dataCollection.AccessElement(1));
            }
            // Dispose will be called implicitly due to the 'using' statement, but you can also call it explicitly if needed.

            // Move Console.ReadKey() here or within another appropriate method.
            Console.ReadKey();
        }

        public class LargeDataCollection<T> : IDisposable
        {
            private bool disposed = false;
            private T[] data;

            // Constructor
            public LargeDataCollection(T[] initialData)
            {
                data = new T[initialData.Length];
                Array.Copy(initialData, data, initialData.Length);
            }

            // Method to add elements to the collection
            public void AddElement(T element)
            {
                // Implement your logic to add an element
                // For simplicity, this example assumes that the collection size won't be exceeded
                for (int i = 0; i < data.Length; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(data[i], default(T)))
                    {
                        data[i] = element;
                        break;
                    }
                }
            }

            // Method to remove elements from the collection
            public void RemoveElement(T element)
            {
                // Implement your logic to remove an element
                for (int i = 0; i < data.Length; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(data[i], element))
                    {
                        data[i] = default(T);
                        break;
                    }
                }
            }

            // Method to access elements from the collection
            public T AccessElement(int index)
            {
                // Implement your logic to access an element
                // Check if the index is within bounds
                if (index >= 0 && index < data.Length)
                {
                    return data[index];
                }
                else
                {
                    // Handle out-of-bounds access, for example, throw an exception
                    throw new IndexOutOfRangeException("Index out of bounds");
                }
            }

            // Dispose method to release resources
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            // Dispose(bool disposing) method to handle managed and unmanaged resources
            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        // Release managed resources if any
                    }

                    // Release unmanaged resources
                    disposed = true;
                }
            }

            // Destructor to ensure Dispose is called if the client forgets
            ~LargeDataCollection()
            {
                Dispose(false);
            }
        }
    }
}
