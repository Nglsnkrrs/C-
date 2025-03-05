using System;
using System.Collections.Generic;
using System.IO;

// Абстрактный класс документа
abstract class Document
{
    public string Name { get; protected set; }
    public string Content { get; protected set; }

    protected Document(string name = "Untitled")
    {
        Name = name;
        Content = "";
    }

    public abstract void Open(string filename);
    public abstract void Save();
    public abstract void SaveAs(string newFilename);
    public abstract void Print();
    public void Close()
    {
        Console.WriteLine($"Document {Name} closed.");
    }
}

// Класс текстового документа
class TextDocument : Document
{
    public TextDocument(string name = "Untitled") : base(name) { }

    public override void Open(string filename)
    {
        Content = File.ReadAllText(filename);
        Name = filename;
        Console.WriteLine($"Text document {filename} opened.");
    }

    public override void Save()
    {
        File.WriteAllText(Name, Content);
        Console.WriteLine($"Text document {Name} saved.");
    }

    public override void SaveAs(string newFilename)
    {
        File.WriteAllText(newFilename, Content);
        Name = newFilename;
        Console.WriteLine($"Text document saved as {newFilename}.");
    }

    public override void Print()
    {
        Console.WriteLine($"Printing document {Name}:\n{Content}");
    }
}

// Класс таблицы (например, для электронных таблиц)
class SpreadsheetDocument : Document
{
    public SpreadsheetDocument(string name = "Untitled") : base(name) { }

    public override void Open(string filename)
    {
        Content = File.ReadAllText(filename);
        Name = filename;
        Console.WriteLine($"Spreadsheet document {filename} opened.");
    }

    public override void Save()
    {
        File.WriteAllText(Name, Content);
        Console.WriteLine($"Spreadsheet document {Name} saved.");
    }

    public override void SaveAs(string newFilename)
    {
        File.WriteAllText(newFilename, Content);
        Name = newFilename;
        Console.WriteLine($"Spreadsheet document saved as {newFilename}.");
    }

    public override void Print()
    {
        Console.WriteLine($"Printing spreadsheet {Name}:\n{Content}");
    }
}

// Фабрика для создания документов разных типов
class DocumentFactory
{
    public static Document CreateDocument(string docType, string name = "Untitled")
    {
        return docType.ToLower() switch
        {
            "text" => new TextDocument(name),
            "spreadsheet" => new SpreadsheetDocument(name),
            _ => throw new ArgumentException("Unsupported document type")
        };
    }
}

// Класс редактора для работы с разными типами документов
class MultiDocumentEditor
{
    private readonly List<Document> documents = new();

    public Document NewDocument(string docType)
    {
        var doc = DocumentFactory.CreateDocument(docType);
        documents.Add(doc);
        Console.WriteLine($"New {docType} document created.");
        return doc;
    }

    public Document OpenDocument(string docType, string filename)
    {
        var doc = DocumentFactory.CreateDocument(docType, filename);
        doc.Open(filename);
        documents.Add(doc);
        return doc;
    }

    public void CloseDocument(Document document)
    {
        if (documents.Contains(document))
        {
            document.Close();
            documents.Remove(document);
        }
    }
}

// Тестирование
class Program
{
    static void Main()
    {
        MultiDocumentEditor editor = new();

        Document textDoc = editor.NewDocument("text");
        textDoc.SaveAs("text_example.txt");
        textDoc.Print();

        Document spreadsheetDoc = editor.NewDocument("spreadsheet");
        spreadsheetDoc.SaveAs("spreadsheet_example.csv");
        spreadsheetDoc.Print();

        editor.CloseDocument(textDoc);
        editor.CloseDocument(spreadsheetDoc);
    }
}
