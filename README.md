# AutoCodeSnippetGenerator
Creating Object initializer for class in C#


1. Where you can this tool:-

      When you have to write a lot of prop names in the object initializer, then at that place you can use this.
	  
2. What this tool will give you:-

      Currently, this will give only the default object initializer code snippet with the default values. If any recursion is found on the class, then that property will be assigned with null. 

3. How to consume this:-
      
	  Currently, this is built as Win Form application. You will see a sample C# object initializer code after running this application. However, we can change this to a Console application or a Windows Library too to fit into your requirment.

4. How to get the final required code:-
 <xmp>
          Thats very simple. Call this statement with the target type, on which you want to construct the C# Object Code Initializer.	  SnippetGenerator.ConstructClassSnippet(typeof(Target Type Goes Here));This returns a string data which is the required code for you!
</xmp>

5. Oh, Really will it produce?
    
     Ok. Lets take an example of the following class structure.
	 
    <pre>	 
    <code>	 
    public class Root
    {
        public int Prop_A { get; set; }
        public float Prop_B { get; set; }
        public string Prop_C { get; set; }
        public bool Prop_D { get; set; }
        <code>public List&ltChild&gt Prop_E { get; set; }</code>
        <code>public List&ltRoot&gt Prop_F { get; set; } </code>
        public string[] Prop_H { get; set; }
        public Child Prop_I { get; set; }
        <code>public List&ltint&gt Prop_J { get; set; }</code>
        public Child[] Prop_K { get; set; }
        <code>public List&ltRoot&gt ChildList { get; set; }</code>
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
   </code>	
   </pre>
	
	by passing the type of Root class to the statement as SnippetGenerator.ConstructClassSnippet(typeof(Root)), will produce the result as follows:-
	
	<pre>
	<code>
            new CodeSnippetGen.Root() {
     Prop_A = 0,
      Prop_B = 0 f,
      Prop_C = String.Empty,
      Prop_D = true,
      Prop_E = new List < CodeSnippetGen.Child > () {
       new CodeSnippetGen.Child() {
        Name = String.Empty,
         Child2Data = new CodeSnippetGen.Child_2() {
          GH = 0
         }
       }
      },
      Prop_F = null, //Causing self recursion will result to null
      Prop_H = new System.String[] {},
      Prop_I = new CodeSnippetGen.Child() {
       Name = String.Empty,
        Child2Data = new CodeSnippetGen.Child_2() {
         GH = 0
        }
      },
      Prop_J = new List < System.Int32 > () {},
      Prop_K = new CodeSnippetGen.Child[] {
       new CodeSnippetGen.Child() {
        Name = String.Empty,
         Child2Data = new CodeSnippetGen.Child_2() {
          GH = 0
         }
       }
      },
      ChildList = null //Causing self recursion will result to null
    };
    
  </code>
  </pre>
  
6. Why Causing self recursion will result to null?

	While constructing the snippet, it will result non ending self recusion, which will lead to the Stack Overflow Exception. Thats why made it as null.
	
7. What may be a further update?

	<xmp> Working on auto C# sytle snippet in producing the output and much more to go. </xmp> 
  

Thanks for giving a try. 
