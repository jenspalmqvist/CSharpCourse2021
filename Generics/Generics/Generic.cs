using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Generics
{
    static class Generic
    {
        public static List<T> ReadFromCsv<T>(string filePath) where T : class, new()
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            List<T> output = new List<T>();

            T entry = new T();
            var props = entry.GetType().GetProperties();

            var headers = lines[0].Split(";");
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                entry = new T();
                var values = line.Split(";");

                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (var prop in props)
                    {
                        if (prop.Name == headers[i])
                        {
                            prop.SetValue(entry, Convert.ChangeType(values[i], prop.PropertyType));
                        }
                    }
                }

                output.Add(entry);
            }

            return output;
        }

        public static void SaveToCsv<T>(string filePath, List<T> data) where T : class
        {
            List<string> lines = new List<string>();

            var props = data[0].GetType().GetProperties();
            var line = new StringBuilder();

            foreach (var prop in props)
            {
                line.Append(prop.Name + ";");
            }

            lines.Add(line.ToString());

            foreach (var entry in data)
            {
                line = new StringBuilder();
                foreach (var prop in props)
                {
                    line.Append(prop.GetValue(entry).ToString() + ";");
                }

                lines.Add(line.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
