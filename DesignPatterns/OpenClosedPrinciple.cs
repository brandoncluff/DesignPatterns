using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns {
    public enum Color { RED, GREEN, BLUE }

    public enum Size { SMALL, MEDIUM, LARGE }

    public class Product {
        public string Name;
        public Color Color;
        public Size Size; 

        public Product(string name, Color color, Size size) {
            if (name == null) {
                throw new ArgumentNullException(paramName: nameof(name));
                Name = name;
                Color = color;
                Size = size; 
            }
        }
    }

    //THE FOLLOWING CLASS AND METHODS VIOLATE THE OPEN CLOSED PRINCIPLE

    public class ProductFilter {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size) {
            foreach (var p in products) {
                if (p.Size == size) {
                    yield return p; 
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color) {
            foreach (var p in products) {
                if (p.Color == color) {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color) {
            foreach (var p in products) {
                if (p.Size == size && p.Color == color) {
                    yield return p;
                }
            }
        }
    }

    // INSTEAD, USE THE SPECIFICATION PATTERN AND OVERRIDE (ENTERPRISE PATTERN)

    public interface ISpecification<T> {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T> {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product> {
        private Color color; 

        public ColorSpecification(Color color) {
            this.color = color; 
        }

        public bool IsSatisfied(Product t) {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product> {
        private Size size;

        public SizeSpecification(Size size) {
            this.size = size;
        }

        public bool IsSatisfied(Product t) {
            return t.Size == size;
        }
    }

    public class AndSpecification<T> : ISpecification<T> {
        ISpecification<T> first, second; 

        public AndSpecification(ISpecification<T> first, ISpecification<T> second) {
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second)); 
        }

        public bool IsSatisfied(T t) {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product> {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec) {
            foreach (var i in items) {
                if (spec.IsSatisfied(i)) {
                    yield return i; 
                }
            }
        }
    }

    class OpenClosedPrinciple {
        static void Main(string[] args) {
            var apple = new Product("Apple", Color.RED, Size.SMALL);
            var tree = new Product("Tree", Color.GREEN, Size.LARGE);
            var house = new Product("House", Color.BLUE, Size.LARGE);

            Product[] products = { apple, tree, house };

            // INCORRECT IMPLEMENTATION
            var pf = new ProductFilter();
            WriteLine("Green products (incorrect):");

            foreach (var p in pf.FilterByColor(products, Color.GREEN)) {
                WriteLine($" - {p.Name} is green");
            }

            // CORRECT IMPLEMENTATION
            var bf = new BetterFilter();
            WriteLine("Green products (correct):");

            foreach (var p in bf.Filter(products, new ColorSpecification(Color.GREEN))) {
                WriteLine($" - {p.Name} is green");
            }

            WriteLine("Large blue items");
            foreach (var p in bf.Filter(
                products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.BLUE),
                    new SizeSpecification(Size.LARGE)
                ))) {
                WriteLine($" - {p.Name} is big and blue");
            }
        }
    }
}
