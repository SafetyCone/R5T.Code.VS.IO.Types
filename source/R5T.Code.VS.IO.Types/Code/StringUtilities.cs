using System;

using PathUtilities = R5T.NetStandard.IO.Paths.Utilities;


namespace R5T.Code.VisualStudio.IO
{
    public static class StringUtilities
    {
        public static string GetProjectName(string projectFilePath)
        {
            var projectName = PathUtilities.GetFileNameWithoutExtension(projectFilePath);
            return projectName;
        }

        public static string GetProjectFileRelativeToSolutionDirectoryPath(string solutionFilePath, string projectFilePath)
        {
            var solutionDirectoryPath = PathUtilities.GetDirectoryPath(solutionFilePath);

            var solutionDirectoryToDependencyProjectRelativeFilePath = PathUtilities.GetRelativePathDirectoryToFile(solutionDirectoryPath, projectFilePath);
            return solutionDirectoryToDependencyProjectRelativeFilePath;
        }

        public static string GetProjectFilePath(string solutionFilePath, string projectRelativeToSolutionDirectoryFilePath)
        {
            var solutionDirectoryPath = PathUtilities.GetDirectoryPath(solutionFilePath);

            var projectFileUnresolvedPath = PathUtilities.Combine(solutionDirectoryPath, projectRelativeToSolutionDirectoryFilePath);

            var projectFilePath = PathUtilities.ResolveFilePath(projectFileUnresolvedPath);
            return projectFilePath;
        }
    }
}
