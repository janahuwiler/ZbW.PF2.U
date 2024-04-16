namespace MB11.SortComparison.SortingAlgorithms
{
    public class BubbleSort : SortAlgorithm
    {
        public override string Name => "Bubblesort";

        public override void Sort(IList<int> arrayToSort)
        {
            //var a = arrayToSort.ToArray();
            var swapped = true;

            while (swapped)
            {
                // as soon as they are no longer swapps // in one round, it is sorted
                swapped = false;
                for (int i = 0; i < arrayToSort.Count - 1; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        SwapItems(arrayToSort, i, i + 1);
                        swapped = true;
                    }
                }
            }

        }

        private void SwapItems(IList<int> arrayToSort, int index1, int index2)
        {
            var temporary = arrayToSort[index2];
            arrayToSort[index2] = arrayToSort[index1];
            arrayToSort[index1] = temporary;
        }
    }
}
