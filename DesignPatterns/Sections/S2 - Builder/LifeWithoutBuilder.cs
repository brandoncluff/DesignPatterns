using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns {
    public class LifeWithoutBuilder {
        public static void Test() {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            WriteLine(sb);

            var words = new[] {"hello", "world"};
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words) {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
        }
    }
}