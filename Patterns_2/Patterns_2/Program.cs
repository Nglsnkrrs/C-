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

    public void InsertText(string text)
    {
        Content += text;
    }

    public void DeleteText(int startIndex, int length)
    {
        if (startIndex >= 0 && startIndex < Content.Length && length > 0)
        {
            Content = Content.Remove(startIndex, Math.Min(length, Content.Length - startIndex));
        }
    }

    public void FindAndReplace(string find, string replace)
    {
        Content = Content.Replace(find, replace);
    }
}

// Фабрика для создания текстовых документов
class DocumentFactory
{
    public static TextDocument CreateDocument(string name = "Untitled")
    {
        return new TextDocument(name);
    }
}

// Класс редактора для работы с текстовыми документами
class TextEditor
{
    private readonly List<TextDocument> documents = new();

    public TextDocument NewDocument()
    {
        var doc = DocumentFactory.CreateDocument();
        documents.Add(doc);
        Console.WriteLine("New text document created.");
        return doc;
    }

    public TextDocument OpenDocument(string filename)
    {
        var doc = DocumentFactory.CreateDocument(filename);
        doc.Open(filename);
        documents.Add(doc);
        return doc;
    }

    public void CloseDocument(TextDocument document)
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
        TextEditor editor = new();

        TextDocument textDoc = editor.NewDocument();
        textDoc.InsertText("Hello, world!\n");
        textDoc.Print();

        textDoc.FindAndReplace("world", "C#");
        textDoc.Print();

        textDoc.SaveAs("text_example.txt");
        editor.CloseDocument(textDoc);
    }
}
