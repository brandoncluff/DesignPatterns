using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns {
    public class Document {
    }

    public interface IMachine {
        void Print(Document d);
        void Fax(Document d);
        void Scan(Document d);
    }

    // THIS IS ACCEPTABLE IF A MULTIFUNCTION MACHINE IS NEEDED
    public class MultiFunctionPrinter : IMachine {
        public void Print(Document d) {
            // PRINT IMPLEMENTATION
        }

        public void Fax(Document d) {
            // FAX IMPLEMENTATION
        }

        public void Scan(Document d) {
            // SCAN IMPLEMENTATION
        }
    }

    public class OldFashionedPrinter : IMachine {
        public void Print(Document d) {
            // PRINT IMPLEMENTATION
        }

        public void Fax(Document d) {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d) {
            throw new System.NotImplementedException();
        }
    }

    public interface IPrinter {
        void Print(Document d);
    }

    public interface IScanner {
        void Scan(Document d);
    }

    public class Printer : IPrinter {
        public void Print(Document d) {

        }
    }

    public class Photocopier : IPrinter, IScanner {
        public void Print(Document d) {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d) {
            throw new System.NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner {
        // CAN INHERIT FROM MULTIPLE INTERFACES
    }

    public struct MultiFunctionMachine : IMultiFunctionDevice {
        // COMPOSE THIS OUT OF SEVERAL MODULES
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner) {
            this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
        }

        public void Print(Document d) {
            printer.Print(d);
        }

        public void Scan(Document d) {
            // THIS IS AN EXAMPLE OF THE DECORATOR PATTERN
            scanner.Scan(d);
        }
    }

    class InterfaceSegregationPrinciple {
        public static void Test() {
            WriteLine("Read the InterfaceSegregationPrinciple.cs for an example of implemenation");
        }
    }
}
