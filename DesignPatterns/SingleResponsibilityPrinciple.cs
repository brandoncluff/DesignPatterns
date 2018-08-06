using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns {

    public class Journal {
        private readonly List<string> entries = new List<string>();
        private static int count = 0; 

        public int AddEntry(string text) {
            // MEMENTO PATTERN
            entries.Add($"{++count}: {text}");
            return count; 
        }

        public void RemoveEntry(int index) {
            entries.RemoveAt(index);
        }

        public override string ToString() {
            return string.Join(Environment.NewLine, entries);
        }

        // THE FOLLOWING METHODS VIOLATE THE SINGLE RESPONSIBILITY PRINCIPAL
        public void Save(string filename) {}
        public void Load(string filename) {}
        public void Load(Uri uri) {}
    }

    public class Persistence {
        // A PERSISTENCE CLASS SHOULD BE USED FOR FILE MANAGEMENT INSTEAD
        public void SaveToFile(Journal j, string filename, bool overwrite = false) {
            if (overwrite || !File.Exists(filename)) {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    class SingleResponsibilityPrinciple {
        //static void Main(string[] args) {
        static void Test() { 
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}
