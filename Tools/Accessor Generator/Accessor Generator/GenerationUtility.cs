using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Accessor_Generator
{
    public class GenerationUtility : Task
    {

        #region private fields
        private string outputFiles;
        private ITaskItem[] inputFiles;
        #endregion

        #region public properties
        /// <summary>
        /// It's list of input .xaml files 
        /// that has an GenerateAccessor bild action.
        /// </summary>
        [Required]
        public ITaskItem[] InputFiles
        {
            get { return inputFiles; }
            set { inputFiles = value; }
        }

        /// <summary>
        /// Path to output .cs files.
        /// </summary>
        [Required]
        public string OutputFiles
        {
            get { return outputFiles; }
            set { outputFiles = value; }
        }
        #endregion

        #region override methods
        public override bool Execute()
        {
            List<string> items = InputFiles.Select(item => item.ItemSpec).ToList();
            if (!Directory.Exists(OutputFiles.Trim()))
            {
                Directory.CreateDirectory(OutputFiles.Trim());              
            }
            new AccessorGenerator(items, OutputFiles.Trim()).Generate();
            return true;
        }
        #endregion
    }
}
