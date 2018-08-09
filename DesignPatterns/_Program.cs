﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns {
    class SolidDesignPrinciples {
        public static void Notes() {
            // S.O.L.I.D. DESIGN PRINCIPLES
            WriteLine("*** S.O.L.I.D. DESIGN PRINCIPLES ***");
            WriteLine();

            // SINGLE RESPONSIBILITY PRINCIPLE
            WriteLine("SINGLE RESPONSIBILITY PRINCIPLE: ");
            WriteLine(" * A class should only have one reason to change");
            WriteLine(" * Sepration of concerns - different classes handling different, independent tasks/problems");
            WriteLine();
            //SingleResponsibilityPrinciple.Test();

            // OPEN CLOSED PRINCIPLE
            WriteLine("OPEN CLOSED PRINCIPLE: ");
            WriteLine(" * Classes should be open for extension but closed for modification");
            WriteLine(" * If a class has already been written, tested, and works, it should be extended - not modified");
            WriteLine();
            //OpenClosedPrinciple.Test();

            // LISKOV SUBSTITUTION PRINCIPLE
            WriteLine("LISKOV SUBSTITUTION PRINCIPLE: ");
            WriteLine(" * You should be able to substitute a base type for a subtype");
            WriteLine(" * Object-oriented design requires that a descendant should be cast to a base and operate correctly");
            WriteLine();
            //LiskovSubstitutionPrinciple.Test();

            // INTERFACE SEGREGATION PRINCIPLE
            WriteLine("INTERFACE SEGREGATION PRINCIPLE: ");
            WriteLine(" * Don't put too much into an interface - split it into separate interfaces");
            WriteLine(" * YAGNI - Ya Ain't Gunna Need It");
            WriteLine();
            //InterfaceSegregationPrinciple.Test();

            // DEPENDENCY INVERSION PRINCIPLE
            WriteLine("DEPENDENCY INVERSION PRINCIPLE: ");
            WriteLine(" * High-level modules should not depend upon low-level ones - use abstractions where possible");
            WriteLine(" * If you have implementation details, then don't expose them directly");
            WriteLine();
            //DependencyInversionPrinciple.Test();
        }
    }

    class _Program {
        static void Main(string[] args) {
            SolidDesignPrinciples.Notes();
            Console.ReadLine();
        }
    }
}
