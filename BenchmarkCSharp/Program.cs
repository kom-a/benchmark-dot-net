using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkCSharp
{
    
    public class SortsBenchmark
    {
        private const int m_ArraySize = 32768;
        private int[] m_SortedArray;
        private int[] m_UnsortedArray;


        public SortsBenchmark()
        {
            m_SortedArray = new int[m_ArraySize];
            m_UnsortedArray = new int[m_ArraySize];

            Random rnd = new Random();
            for (int i = 0; i < m_ArraySize; i++)
            {
                int value = rnd.Next(256);
                m_SortedArray[i] = value;
                m_UnsortedArray[i] = value;
            }
            
            Array.Sort(m_SortedArray);
        }

        [Benchmark]
        public void SumSortedArray()
        {
            long sum = 0;
            for (int i = 0; i < m_ArraySize; i++)
            {
                if (m_SortedArray[i] >= 128)
                    sum += m_SortedArray[i];
            }
        }

        [Benchmark]
        public void SumUnsortedArray()
        {
            long sum = 0;
            
            for (int i = 0; i < m_ArraySize; i++)
            {
                if (m_UnsortedArray[i] >= 128)
                    sum += m_UnsortedArray[i];
            }
        }
    }


    internal class Program
    {

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
