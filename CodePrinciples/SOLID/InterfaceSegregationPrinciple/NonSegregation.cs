using System;
using System.Collections.Generic;
using System.Text;

namespace CodePrinciples.SOLID.InterfaceSegregationPrinciple
{
    public interface IPrinterTasksNonSegregated
    {
        void Print(string PrintContent);

        void Scan(string ScanContent);

        void Fax(string FaxContent);

        void PrintDuplex(string PrintDuplexContent);
    }

    public class HPLaserJetPrinterNonSegregated : IPrinterTasksNonSegregated
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine("Print Done");
        }

        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }

        public void Fax(string FaxContent)
        {
            Console.WriteLine("Fax content");
        }

        public void PrintDuplex(string PrintDuplexContent)
        {
            Console.WriteLine("Print Duplex content");
        }
    }

    class LiquidInkjetPrinterNonSegregated : IPrinterTasksNonSegregated
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine("Print Done");
        }

        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }

        public void Fax(string FaxContent)
        {
            throw new NotImplementedException();
        }

        public void PrintDuplex(string PrintDuplexContent)
        {
            throw new NotImplementedException();
        }
    }
}