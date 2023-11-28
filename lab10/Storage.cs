using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    /// <summary>
    /// Storage is a class for managing spare parts in the Storage
    /// </summary>

    public class Storage
    {
        List<SparePart> spareParts = new List<SparePart>();

        public List<SparePart> SpareParts { get => spareParts; set => spareParts = value; }

        /// <summary>
        /// Add the Spare part in the Storage.
        /// </summary>
        /// <param name="newPart">Part for add.</param>
        public void AddPart(SparePart newPart)
        {
            lock (spareParts)
            {
                if (newPart != null && !spareParts.Contains(newPart))
                {
                    spareParts.Add(newPart);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Data can`t be null!/Part is already in Storage!");
                }
            }
        }

        /// <summary>
        /// Remove the Spare part from the Storage
        /// </summary>
        /// <param name="partId">Id of the spare part to delete</param>
        public void RemovePart(SparePart partToRemove)
        {
            if (partToRemove != null && spareParts.Contains(partToRemove))
            {
                spareParts.Remove(partToRemove);
            }
            else
            {
                throw new ArgumentException("Data can`t be null!/This spare part does not exist!");
            }
        }

        /// <summary>
        /// Find the Spare part in the Storage
        /// </summary>
        /// <param name="partId">Id of the part.</param>
        public SparePart FindPartById(int partId)
        {
            foreach (SparePart sparePart in spareParts)
            {
                if (sparePart.Id == partId)
                {
                    return sparePart;
                }
            }
            throw new ArgumentOutOfRangeException("Element not found!");
        }


        public List<SparePart> GetAllParts()
        {
            return spareParts;
        }
        public void RemoveAt(int index) { 
            spareParts.RemoveAt(index);
        }
        public SparePart First() { 
            return spareParts.First();
        }

        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder();
            foreach (SparePart part in SpareParts)
            {
                tempString.Append(part + "\n");
            }
            return tempString.ToString();
        }

    }
}
