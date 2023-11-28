using System.Text;
using System.Text.Json;

namespace Lab10
{
    public class FileSaveLoad
    {
        /// <summary>
        /// Json serialization of Storage
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="storage">Instance of Storage class</param>
        public static void JsonSave(string filePath, Storage storage)
        {
            string jsonString = JsonSerializer.Serialize(storage);
            using (FileStream jsonOutFile = new(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter jsonWriter = new(jsonOutFile))
                {
                    jsonWriter.Write(jsonString);
                }
            }
        }

        /// <summary>
        /// Json deserialization of Storage
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>Instance of Storage class</returns>
        public static Storage JsonLoad(string filePath)
        {
            using (FileStream jsonInpFile = new(filePath, FileMode.Open))
            {
                using (StreamReader jsonReader = new(jsonInpFile))
                {
                    string jsonString = jsonReader.ReadToEnd();
                    return JsonSerializer.Deserialize<Storage>(jsonString);
                }
            }
        }

        /// <summary>
        /// Binary serialization of Storage
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="storage">Instance of Storage class</param>
        public static void BinSave(string filePath, Storage storage)
        {
            using (FileStream binFile = new(filePath, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writer = new(binFile, Encoding.Default))
                {
                    foreach (SparePart part in storage.GetAllParts())
                    {
                        writer.Write(part.Name);
                        writer.Write(part.Id);
                        writer.Write(part.Cost);
                        writer.Write(part.Weight);
                    }
                }
            }
        }

        /// <summary>
        /// Binary deserialization of Storage
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>Instance of Storage class</returns>
        public static Storage BinLoad(string filePath)
        {
            using (FileStream binFile = new(filePath, FileMode.Open))
            {
                using (BinaryReader reader = new(binFile, Encoding.Default))
                {
                    Storage tempStorage = new Storage();
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        SparePart part = new SparePart
                        {
                            Name = reader.ReadString(),
                            Id = reader.ReadInt32(),
                            Cost = reader.ReadInt32(),
                            Weight = reader.ReadInt32()
                        };

                        tempStorage.GetAllParts().Add(part);
                    }
                    return tempStorage;
                }
            }
        }
    }
}
