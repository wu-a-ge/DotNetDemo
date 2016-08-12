using System.Linq;
using System;
using ExpressionTreeViewer;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Linq.Expressions;
namespace TestApp
{
    class Program
    {
        static void Main()
        {
            //这个visualizer写得很垃圾
            var languages = new[] { "C#", "J#", "VB", "Delphi", "F#", "COBOL", "Python" };
            var queryable = languages.AsQueryable().Where(l => l.EndsWith("#") && l != "j#");
            new VisualizerDevelopmentHost(queryable.Expression, typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource)).ShowVisualizer();
        }
    }
}
