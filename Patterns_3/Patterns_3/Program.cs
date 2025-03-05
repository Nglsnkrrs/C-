
using System;
using System.Collections.Generic;
using System.IO;

// Абстрактный класс документа
abstract class Document
{
    public string Name { get; protected set; }
    protected Document(string name = "Untitled")
    {
        Name = name;
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
    public string Content { get; protected set; }

    public TextDocument(string name = "Untitled") : base(name)
    {
        Content = "";
    }

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

// Класс графического документа
class GraphicDocument : Document
{
    public string Format { get; private set; }
    public List<string> Tools { get; private set; }

    public GraphicDocument(string name = "Untitled", string format = "png") : base(name)
    {
        Format = format;
        Tools = new List<string> { "Brush", "Eraser", "Fill", "Crop" };
    }

    public override void Open(string filename)
    {
        Name = filename;
        Console.WriteLine($"Graphic document {filename} opened.");
    }

    public override void Save()
    {
        Console.WriteLine($"Graphic document {Name} saved in {Format} format.");
    }

    public override void SaveAs(string newFilename)
    {
        Name = newFilename;
        Console.WriteLine($"Graphic document saved as {newFilename} in {Format} format.");
    }

    public override void Print()
    {
        Console.WriteLine($"Printing graphic document {Name}.");
    }

    public void ApplyTool(string tool)
    {
        if (Tools.Contains(tool))
        {
            Console.WriteLine($"Applying {tool} tool on {Name}.");
        }
        else
        {
            Console.WriteLine($"Tool {tool} is not available.");
        }
    }
}

// Фабрика для создания документов
class DocumentFactory
{
    public static TextDocument CreateTextDocument(string name = "Untitled")
    {
        return new TextDocument(name);
    }

    public static GraphicDocument CreateGraphicDocument(string name = "Untitled", string format = "png")
    {
        return new GraphicDocument(name, format);
    }
}

// Класс редактора для работы с документами
class DocumentEditor
{
    private readonly List<Document> documents = new();

    public TextDocument NewTextDocument()
    {
        var doc = DocumentFactory.CreateTextDocument();
        documents.Add(doc);
        Console.WriteLine("New text document created.");
        return doc;
    }

    public GraphicDocument NewGraphicDocument(string format)
    {
        var doc = DocumentFactory.CreateGraphicDocument(format: format);
        documents.Add(doc);
        Console.WriteLine("New graphic document created.");
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
        DocumentEditor editor = new();

        TextDocument textDoc = editor.NewTextDocument();
        textDoc.InsertText("Hello, world!\n");
        textDoc.Print();
        textDoc.SaveAs("text_example.txt");
        editor.CloseDocument(textDoc);

        GraphicDocument graphicDoc = editor.NewGraphicDocument("jpg");
        graphicDoc.ApplyTool("Brush");
        graphicDoc.SaveAs("image_example.jpg");
        editor.CloseDocument(graphicDoc);
    }
}