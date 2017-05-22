using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippetGen
{
    public class Root
    {
        public int Prop_A { get; set; }
        public float Prop_B { get; set; }
        public string Prop_C { get; set; }
        public bool Prop_D { get; set; }
        public List<Child> Prop_E { get; set; }
        // public List<Root> Prop_F { get; set; } Will Not Work, Stack Overflow
        public string[] Prop_H { get; set; }
        public Child Prop_I { get; set; }
        public List<int> Prop_J { get; set; }
        public Child[] Prop_K { get; set; }
        public List<Root> ChildList { get; set; }
    }

    public class Child
    {
        public string Name { get; set; }
        public Child_2 Child2Data { get; set; }
    }

    public class Child_2
    {
        public int GH { get; set; }
    }
}
