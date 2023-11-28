namespace Lab10
{
    public class SortParts
    {
        public delegate bool CompareDelegate(SparePart left, SparePart right);

        /// <summary>
        /// Sorting the list
        /// </summary>
        public static void Sort(Storage storage, CompareDelegate compareParts)
        {
            if (compareParts != null && storage != null)
            {
                for (int i = 0; i < storage.SpareParts.Count() - 1; i++)
                {
                    for (int j = 0; j < storage.SpareParts.Count() - 1; j++)
                    {
                        if (compareParts(storage.SpareParts[j], storage.SpareParts[j + 1]))
                        {
                            (storage.SpareParts[j], storage.SpareParts[j + 1]) = (storage.SpareParts[j + 1], storage.SpareParts[j]);
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        public static bool CompareByAscendingName(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return string.Compare(left.Name, right.Name, StringComparison.Ordinal) > 0;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool CompareByDescendingName(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return !CompareByAscendingName(left, right);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        public static bool CompareByAscendingId(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return left.Id > right.Id;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool CompareByDescendingId(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return !CompareByAscendingId(left, right);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        public static bool CompareByAscendingCost(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return left.Cost > right.Cost;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool CompareByDescendingCost(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return !CompareByAscendingCost(left, right);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        public static bool CompareByAscendingWeight(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return left.Weight > right.Weight;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
        public static bool CompareByDescendingWeight(SparePart left, SparePart right)
        {
            if (left != null && right != null)
            {
                return !CompareByAscendingWeight(left, right);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
    }
}
