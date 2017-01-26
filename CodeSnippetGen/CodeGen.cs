using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace CodeSnippetGen
{
    public partial class CodeGen : Form
    {
        public CodeGen()
        {
            InitializeComponent();
        }

        private void CodeGen_Load(object sender, EventArgs e)
        {
            var targetType = typeof(Root);
            var constructedSnippet = SnippetGenerator.ConstructClassSnippet(targetType) + ";";
            generatedCode.Text = constructedSnippet;            
        }
    }

}
