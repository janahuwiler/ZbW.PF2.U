using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB11.SortComparison.SortingAlgorithms
{
    public class MergeSort : SortAlgorithm
    {
        public override string Name => "MergeSort";

        public override void Sort(IList<int> arr)
        {
            int length = arr.Count;
            int middle = length / 2;

            if (length == 1)
            {
                return;
            }

            IList<int> leftArray = new List<int>();
            for (int i = 0; i < middle; i++)
            {
                leftArray.Add(arr[i]);
            }

            IList<int> rightArray = new List<int>();
            for (int i = middle; i < length; i++)
            {
                rightArray.Add(arr[i]);
            }

            Sort(leftArray);
            Sort(rightArray);
            Merge(leftArray, rightArray, arr);
        }

        public void Merge(IList<int> leftArr, IList<int> rightArr, IList<int> arr)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            int leftLength = leftArr.Count;
            int rightLength = rightArr.Count;

            while (leftIndex < leftLength && rightIndex < rightLength)
            {
                if (leftArr[leftIndex] <= rightArr[rightIndex])
                {
                    arr[mergedIndex++] = leftArr[leftIndex++];
                }
                else
                {
                    arr[mergedIndex++] = rightArr[rightIndex++];
                }
            }

            while (leftIndex < leftLength)
            {
                arr[mergedIndex++] = leftArr[leftIndex++];
            }

            while (rightIndex < rightLength)
            {
                arr[mergedIndex++] = rightArr[rightIndex++];
            }
        }

    }
}