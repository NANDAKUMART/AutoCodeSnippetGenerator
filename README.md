# AutoCodeSnippetGenerator
Creating Object initializer for class in C#

1. Where you can this tool:-

      When you have to write a lot of prop names in the object initializer, then at that place you can use this.
	  
2. What this tool will give you:-

      Currently, this will give only the default object initializer code snippet with the default values. If any recursion is found on the class, then that property will be assigned with null. 

3. How to consume this:-
      
	  Currently, this is built as Win Form application. You will see a sample C# object initializer code after running this application. However, we can change this to a Console application or a Windows Library too to fit into your requirment.

4. How to get the final required code:-
    
          Thats very simple.	  
Call this statement with the target type, on which you want to construct the C# Object Code Initializer.	  
SnippetGenerator.ConstructClassSnippet(typeof(<Target Type Goes Here));This returns a string data which is the required code for you!


5. Oh, Really will it produce?
    
     Ok. Lets take an example of the following class structure.
	 	 
    public class Root
    {
        public int Prop_A { get; set; }
        public float Prop_B { get; set; }
        public string Prop_C { get; set; }
        public bool Prop_D { get; set; }
        public List<Child> Prop_E { get; set; }
        public List<Root> Prop_F { get; set; } 
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
	
	by passing the type of Root class to the statement as SnippetGenerator.ConstructClassSnippet(typeof(Root)), will produce the result as follows:-
	
            new CodeSnippetGen.Root()
            {
                Prop_A = 0,
                Prop_B = 0f,
                Prop_C = String.Empty,
                Prop_D = true,
                Prop_E = new List<CodeSnippetGen.Child>(){
	    new CodeSnippetGen.Child() 
{ 
Name =  String.Empty  , 
 Child2Data = new CodeSnippetGen.Child_2() 
{ 
GH = 0 
 }  
 } 
 },
                Prop_F = null,
                Prop_H = new System.String[] { },
                Prop_I = new CodeSnippetGen.Child()
                {
                    Name = String.Empty,
                    Child2Data = new CodeSnippetGen.Child_2()
                    {
                        GH = 0
                    }
                },
                Prop_J = new List<System.Int32>() { },
                Prop_K = new CodeSnippetGen.Child[] { 
	new CodeSnippetGen.Child() 
{ 
Name =  String.Empty  , 
 Child2Data = new CodeSnippetGen.Child_2() 
{ 
GH = 0 
 }  
 } 
 },
                ChildList = null
            };
  
6. What may be a further update?
 
	Working on auto C# sytle snippet in producing the output and much more to go.

  

        If you have any suggestions/ideas pls feel to reach out.
	
	Thanks in advance for giving a try. 
	
	Have a good day.
    
