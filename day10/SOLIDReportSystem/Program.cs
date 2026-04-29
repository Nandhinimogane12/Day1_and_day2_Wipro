using System;
using System.IO;

// ========== INTERFACES - ISP + DIP ==========
public interface IReportGenerator // SRP: Only generates
{
    string Generate();
}

public interface IReportSaver // ISP: Split interface, SRP: Only saves
{
    void Save(string content, string filePath);
}

public interface IReportFormatter // OCP: Open for extension
{
    string Format(string data);
}

// ========== MODELS - LSP ==========
public abstract class Report // LSP: Base class
{
    public string Title { get; set; } = string.Empty;
    public abstract string GetData(); // LSP: Must override
}

public class SalesReport : Report // LSP: Can substitute Report
{
    public override string GetData() => $"Sales Data for {Title}";
}

// ========== FORMATTERS - OCP ==========
public class PdfFormatter : IReportFormatter // OCP: Extend without modify
{
    public string Format(string data) => $"PDF Content: {data}";
}

public class ExcelFormatter : IReportFormatter // OCP: New format, no changes elsewhere
{
    public string Format(string data) => $"EXCEL Content: {data}";
}

// ========== SERVICES - SRP + DIP ==========
public class ReportGenerator : IReportGenerator // SRP: Only generates
{
    private readonly IReportFormatter _formatter;
    private readonly Report _report;

    // DIP: Depend on abstraction IReportFormatter
    public ReportGenerator(Report report, IReportFormatter formatter)
    {
        _report = report;
        _formatter = formatter;
    }

    public string Generate() => _formatter.Format(_report.GetData());
}

public class ReportSaver : IReportSaver // SRP: Only saves
{
    public void Save(string content, string filePath)
    {
        File.WriteAllText(filePath, content);
        Console.WriteLine($"Report saved to {filePath}");
    }
}

public class ReportService // DIP: High-level module
{
    private readonly IReportGenerator _generator;
    private readonly IReportSaver _saver;

    // DIP: Depends on abstractions, not concrete classes
    public ReportService(IReportGenerator generator, IReportSaver saver)
    {
        _generator = generator;
        _saver = saver;
    }

    public void ProcessReport(Report report, string path)
    {
        var content = _generator.Generate();
        _saver.Save(content, path);
    }
}

// ========== MAIN - DIP Wiring ==========
class Program
{
    static void Main()
    {
        // LSP: SalesReport substitutes Report
        Report report = new SalesReport { Title = "Q1 2024" };

        // OCP: Swap to new ExcelFormatter() without changing other code
        IReportFormatter formatter = new PdfFormatter();
        IReportGenerator generator = new ReportGenerator(report, formatter);
        IReportSaver saver = new ReportSaver();

        // DIP: Inject dependencies
        var service = new ReportService(generator, saver);
        service.ProcessReport(report, "report.txt");

        Console.WriteLine("SOLID Demo Complete. Check report.txt file.");
    }
}