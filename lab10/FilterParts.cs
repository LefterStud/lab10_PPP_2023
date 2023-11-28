
using System;

namespace Lab10
{
    public class FilterParts
    {
        public delegate bool SearchDelegate(SparePart sparePart, string searchValue);
        /// <summary>
        /// Search by fields
        /// </summary>
        /// <returns>Storage</returns>
        public static Storage SearchParts(Storage storage, string searchValue, SearchDelegate searchDelegate)
        {
            if (storage != null && searchDelegate != null)
            {
                Storage tempStorage = new Storage();
                for (int i = 0; i < storage.SpareParts.Count(); i++)
                {
                    if (searchDelegate(storage.SpareParts[i], searchValue))
                    {
                        tempStorage.AddPart(storage.SpareParts[i]);
                    }
                }
                return tempStorage;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }
    }
}
