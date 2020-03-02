using System;

namespace LoadVsProjectMsBuild2019
{
    class Program
    {
        static int Main()
        {
            return LoadProject("NewProjectFormat.csproj") | LoadProject("OldProjectFormat.csproj");
        }

        static int LoadProject(string filename)
        {
            try
            {
                var proj = Microsoft.Build.Evaluation.Project.FromFile(filename, new Microsoft.Build.Definition.ProjectOptions());
                Console.WriteLine(proj.GetProperty("Message").EvaluatedValue);
                return 0;
            }
            catch (Microsoft.Build.Exceptions.InvalidProjectFileException invex)
            {
                Console.WriteLine(invex.Message);
                return 1;
            }
        }
    }
}
