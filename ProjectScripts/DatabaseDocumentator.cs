using JobsApp.Models;
using System.Reflection;
using System.Text;
namespace JobsApp.ProjectScripts
{
    public class DatabaseDocumentator
    {
        private AppConfig _appConfig;
        public DatabaseDocumentator(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public void DocumentDatabase()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string namespaceFilter = _appConfig.DatabaseDocumentator.DatabaseNamespace;
            string cominedPath = Path.Combine(baseDirectory, _appConfig.DatabaseDocumentator.OutputPath);
            string outputPath = Path.GetFullPath(cominedPath);


            var entities = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.IsClass && t.Namespace == namespaceFilter)
    .ToList();

            var mermaid = new StringBuilder();
            mermaid.AppendLine("```mermaid");
            mermaid.AppendLine("erDiagram");

            foreach (var type in entities)
            {
                var className = type.Name;
                mermaid.AppendLine($"    {className} {{");

                foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    // Simple mapping of C# types to Mermaid labels
                    string typeName = prop.PropertyType.Name.ToLower();
                    mermaid.AppendLine($"        {typeName} {prop.Name}");
                }
                mermaid.AppendLine("    }");
            }

            mermaid.AppendLine(@"
```");

            // 3. Write to the specific location
            File.WriteAllText(outputPath, mermaid.ToString());

        }

    }
}
