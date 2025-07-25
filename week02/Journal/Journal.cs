using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine();

        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine("------------------------------------------");
        }
        Console.WriteLine($"Total entries: {_entries.Count}");
    }


    //Added two ways to view the file in txt format and csv format.

    public void SaveToFileTXT(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"Date: {entry._date}");
                writer.WriteLine($"Prompt: {entry._promptText}");
                writer.WriteLine($"Response: {entry._entryText}");
                writer.WriteLine($"Mood: {entry._mood}");
                writer.WriteLine();
            }
        }
        Console.WriteLine($"Journal saved to {filename} (TXT format)");
    }

    public void LoadFromFileTXT(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        // Cada entrada está formada por 5 líneas (4 de contenido y 1 en blanco)
        for (int i = 0; i < lines.Length; i += 5)
        {
            if (i + 3 < lines.Length)
            {
                Entry entry = new Entry
                {
                    _date = lines[i].Substring(6),
                    _promptText = lines[i + 1].Substring(8),
                    _entryText = lines[i + 2].Substring(10),
                    _mood = lines[i + 3].Substring(6)
                };
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename} (TXT format)");
    }

    public void SaveToFileCSV(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                string line = $"\"{entry._date}\",\"{entry._promptText}\",\"{entry._entryText}\",\"{entry._mood}\"";
                writer.WriteLine(line);
            }
        }
        Console.WriteLine($"Journal saved to {filename} (CSV format)");
    }

    public void LoadFromFileCSV(string filename)
    {
        _entries.Clear();
        foreach (string line in File.ReadLines(filename))
        {
            string[] parts = line.Split(",");
            if (parts.Length >= 4)
            {
                Entry entry = new Entry
                {
                    _date = parts[0].Trim('"'),
                    _promptText = parts[1].Trim('"'),
                    _entryText = parts[2].Trim('"'),
                    _mood = parts[3].Trim('"')
                };
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename} (CSV format)");
    }

}


