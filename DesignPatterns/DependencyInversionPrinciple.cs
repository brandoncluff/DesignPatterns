using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns {
    // HIGH-LEVEL MODULES SHOULD NOT DEPEND ON LOW-LEVEL -- BOTH SHOULD DEPEND ON ABSTRACTIONS
    // ABSTRACTIONS SHOULD NOT DEPEND ON DETAILS -- DETAILS SHOULD DEPEND ON ABSTRACTIONS

    public enum Relationship {
        Parent,
        Child,
        Sibling
    }

    public class Person {
        public string Name;
        // public DateTime DateOfBirth;
    }

    public interface IRelationshipBrowser {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // LOW-LEVEL EXAMPLE
    public class Relationships : IRelationshipBrowser 
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child) {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Person> FindAllChildrenOf(string name) {
            return relations
              .Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    // HIGH-LEVEL EXAMPLE
    public class Research {
        // THE FOLLOWING METHOD VIOLATES THE DEPENDENCY INVERSION PRINCIPLE
        /*
        public Research(Relationships relationships) {
            var relations = relationships.Relations;

            foreach (var r in relations
              .Where(x => x.Item1.Name == "John"
                          && x.Item2 == Relationship.Parent)) {
              WriteLine($"John has a child called {r.Item3.Name}");
            }
        }
        */

        public Research(IRelationshipBrowser browser) {
            foreach (var p in browser.FindAllChildrenOf("John")) {
                WriteLine($"John has a child called {p.Name}");
            }
        }
    }

    class DependencyInversionPrinciple {
        public static void Test() {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Matt" };

            // THIS IS AN EXAMPLE OF A LOW-LEVEL MODULE
            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
