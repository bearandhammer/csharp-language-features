using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Language.Features.V7.UtilityDemo
{
    /// <summary>
    /// Utility class to illustrate the usage of <see cref="ValueTask"/>.
    /// </summary>
    internal sealed class DirectoryInspector
    {
        /// <summary>
        /// Gets the size of the directory using a <see cref="Task"/>.
        /// </summary>
        /// <param name="targetDirectory">The target directory to inspect.</param>
        /// <returns>The size of the files (recursively) in the target directory.</returns>
        internal async Task<long> GetDirectorySize(string targetDirectory)
        {
            if (!Directory.EnumerateFileSystemEntries(targetDirectory).Any())
            {
                // We have a specific return value here, this short-circuit means the usage of a task still
                return 0;
            }

            return await Task.Run(() =>
                Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories)
                    .Sum(file => new FileInfo(file).Length));
        }

        /// <summary>
        /// Gets the size of the directory using a <see cref="ValueTask"/>.
        /// </summary>
        /// <param name="targetDirectory">The target directory to inspect.</param>
        /// <returns>The size of the files (recursively) in the target directory.</returns>
        internal async ValueTask<long> GetDirectorySizeWithValueTask(string targetDirectory)
        {
            if (!Directory.EnumerateFileSystemEntries(targetDirectory).Any())
            {
                // ValueTask - avoid creation of a fully-fledged task when it is not required (useful when invoked frequently and this short-circuit may be the 'hot path'
                // - in particular - result to be available synchronously). Useful details: https://stackoverflow.com/questions/43000520/why-would-one-use-taskt-over-valuetaskt-in-c
                // So...it's not entirely black and white (a degree of grey exists) - in depth, case-by-case assessment is probably useful (e.g. hot path, size of struct, etc.)
                return 0;
            }

            return await Task.Run(() =>
                Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories)
                    .Sum(file => new FileInfo(file).Length));
        }
    }
}
