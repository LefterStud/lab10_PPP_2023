using Lab10;
using System.Collections.Generic;
using System.Linq;
using static Lab10.SortParts;

namespace lab10
{
    public class TaskManager
    {

        /// <summary>
        /// Створення потоків та запуск процесу генерації в кілької потоках
        /// </summary>
        public static void GeneratePartsInStorage(Storage storage, string jsonPath, int arraySize, int threadNumber)
        {
            if (storage != null && !string.IsNullOrEmpty(jsonPath) && arraySize != 0 && threadNumber != 0)
            {
                int chunkSize = arraySize / threadNumber;
                Task[] tasks = new Task[threadNumber];
                for (int i = 0; i < threadNumber; i++)
                {
                    tasks[i] = PutPartsInStorage(storage, chunkSize);
                }
                Task.WaitAll(tasks);
                FileSaveLoad.JsonSave(jsonPath, storage);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        /// <summary>
        /// Процес генерації та береження елементів у список
        /// </summary>
        private static Task PutPartsInStorage(Storage storage, int chunkSize)
        {
            if (chunkSize > 0)
            {
                const int MAX_WEIGHT = 10000;
                const int MAX_COST = 1000000;
                for (int i = 0; i < chunkSize; i++)
                {
                    storage.AddPart(new SparePart(Utils.GetRandomPartName(), Utils.GetRandomNumber(MAX_COST), Utils.GetRandomNumber(MAX_WEIGHT)));
                }
                return Task.CompletedTask;
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }



        /// <summary>
        /// Паралельне сортування
        /// </summary>
        public static void ParallelSort(Storage storage, CompareDelegate compareParts)
        {
            if (compareParts != null && storage != null)
            {
                const int THREADS_NUMBER = 4;
                Task[] tasks = new Task[THREADS_NUMBER];
                List<Storage> sections = SplitList(storage, THREADS_NUMBER);
                for (int i = 0; i < THREADS_NUMBER; i++)
                {
                    tasks[i] = Task.Run(() => Sort(sections[i], compareParts));
                }

                Task.WaitAll(tasks);
                storage.SpareParts = MergeSortedChunks(sections, compareParts);
            }
            else
            {
                throw new ArgumentNullException("Element can not be null");
            }
        }


        /// <summary>
        /// Ділення на секції масиву
        /// </summary>
        public static List<Storage> SplitList(Storage storage, int sections)
        {
            if (sections > 0 || storage == null)
            {
                throw new ArgumentNullException("Element can not be null");
            }

            List<Storage> result = new List<Storage>();

            int partsPerGroup = storage.GetAllParts().Count / sections;
            int remainingParts = storage.GetAllParts().Count % sections;

            int currentIndex = 0;

            for (int i = 0; i < sections; i++)
            {
                int currentGroupSize = partsPerGroup + (i < remainingParts ? 1 : 0);

                Storage part = new Storage();
                for (int j = 0; j < currentGroupSize; j++)
                {
                    part.AddPart(storage.GetAllParts()[currentIndex]);
                    currentIndex++;
                }

                result.Add(part);
            }

            return result;
        }


        /// <summary>
        /// Об'єднання масивів
        /// </summary>
        private static List<SparePart> MergeSortedChunks(List<Storage> chunks, CompareDelegate compareParts)
        {
            List<SparePart> result = new List<SparePart>();

            while (chunks.Any(chunk => chunk.GetAllParts().Count > 0))
            {
                var nonEmptyChunks = chunks.Where(chunk => chunk.GetAllParts().Count > 0).ToList();

                if (nonEmptyChunks.Count > 0)
                {
                    var minItems = nonEmptyChunks.Select(chunk => chunk.GetAllParts().First()).ToList();
                    var minItem = minItems.Min();

                    foreach (var chunk in nonEmptyChunks)
                    {
                        if (compareParts(chunk.First(), minItem))
                        {
                            result.Add(chunk.First());
                            chunk.RemoveAt(0);
                            break;
                        }
                    }
                }
            }
            return result;
        }

    }
}

