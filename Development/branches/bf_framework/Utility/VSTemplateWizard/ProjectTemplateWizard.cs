using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;
using System.IO;
using Wang.Velika.Utility.GeneralLibrary;
using System.Xml;
using System.Reflection;

namespace Wang.Velika.Utility.VSTemplateWizard
{
    public class ProjectTemplateWizard : IWizard
    {
        private const string PARAMETER_NAME_DESTINATION_DIRECTORY = "$destinationdirectory$";
        private const string PARAMETER_NAME_WIZARD_DATA = "$wizarddata$";
        public const string PARAMETER_NAME_PROJECT_NAME = "$ProjectName$";
        public const string PARAMETER_NAME_NAMESPACE = "$DefaultNamespace$";

        private ProjectExtension extensionConfiguration;
        private Dictionary<string, Dictionary<string, FileSearchItem>> searchedFiles;
        private string projectName;
        private string solutionPath;


        public ProjectTemplateWizard()
        {
            this.searchedFiles = new Dictionary<string, Dictionary<string, FileSearchItem>>();
        }


        #region IWizard Members

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
            if (this.extensionConfiguration != null)
            {
                this.RecursiveIterateProjectItems(project.ProjectItems, Path.DirectorySeparatorChar.ToString());
            }
            if (!String.IsNullOrEmpty(this.projectName))
            {
                project.Name = this.projectName;
            }
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            if (runKind == WizardRunKind.AsNewProject)
            {
                this.Initialize((_DTE)automationObject, replacementsDictionary);
                if (this.extensionConfiguration != null)
                {
                    this.SearchFilesAddingToParameters(replacementsDictionary);
                }

                replacementsDictionary.TryGetValue(PARAMETER_NAME_PROJECT_NAME, out this.projectName);
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        #endregion


        private void Initialize(_DTE dte,  Dictionary<string, string> parameters)
        {
            string wizardData = null;
            if (parameters.TryGetValue(PARAMETER_NAME_WIZARD_DATA, out wizardData))
            {
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(wizardData);
                this.extensionConfiguration = XMLHelper.ConvertToObject<ProjectExtension>(xd, Assembly.GetExecutingAssembly(), String.Format("{0}.Schema.ExtensionData.xsd", this.GetType().Namespace));
            }

            Solution s = dte.Solution;
            string path = s.FileName;
            if (!String.IsNullOrEmpty(path))
            {
                this.solutionPath = Path.GetDirectoryName(path);
            }
        }

        private void SearchFilesAddingToParameters(Dictionary<string, string> parameters)
        {
            string destinationDirectory = null;
            if (parameters.TryGetValue(PARAMETER_NAME_DESTINATION_DIRECTORY, out destinationDirectory))
            {
                if (this.extensionConfiguration.fileSearchItems != null)
                {
                    foreach (FileSearchItem item in this.extensionConfiguration.fileSearchItems)
                    {
                        string fullPath;
                        string path = this.SearchFilePath(destinationDirectory, item.searchSuffix, out fullPath);
                        if (!String.IsNullOrEmpty(path) && !String.IsNullOrEmpty(fullPath))
                        {
                            string name = Path.GetFileName(path);

                            string folderPath = this.NormalizeFolderPath(item.folderPath);
                            if (!this.searchedFiles.ContainsKey(folderPath))
                            {
                                this.searchedFiles.Add(folderPath, new Dictionary<string, FileSearchItem>());
                            }
                            this.searchedFiles[folderPath].Add(fullPath, item);

                            if (!String.IsNullOrEmpty(item.nameParameter))
                            {
                                parameters[item.nameParameter] = name;
                            }
                            if (!String.IsNullOrEmpty(item.pathParameter))
                            {
                                parameters[item.pathParameter] = path;
                            }
                        }
                    }
                }

                if (!String.IsNullOrEmpty(this.solutionPath))
                {
                    if (destinationDirectory.StartsWith(this.solutionPath, StringComparison.OrdinalIgnoreCase))
                    {
                        string subPath = destinationDirectory.Substring(this.solutionPath.Length);
                        if (!String.IsNullOrEmpty(subPath))
                        {
                            string[] segs = subPath.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                            if (segs.Length > 0)
                            {
                                string extension = String.Join(Type.Delimiter.ToString(), segs);
                                string projectName;
                                if (parameters.TryGetValue(PARAMETER_NAME_PROJECT_NAME, out projectName))
                                {
                                    if (!String.IsNullOrEmpty(projectName))
                                    {
                                        projectName += Type.Delimiter;
                                    }
                                    projectName += extension;
                                    parameters[PARAMETER_NAME_PROJECT_NAME] = projectName;
                                }
                                string nspace;
                                if (parameters.TryGetValue(PARAMETER_NAME_NAMESPACE, out nspace))
                                {
                                    if (!String.IsNullOrEmpty(nspace))
                                    {
                                        nspace += Type.Delimiter;
                                    }
                                    nspace += extension;
                                    parameters[PARAMETER_NAME_NAMESPACE] = nspace;
                                }
                            }
                        }
                    }
                }
            }
        }

        private string NormalizeFolderPath(string rawFolderPath)
        {
            string ret = rawFolderPath;
            if (ret == null)
            {
                ret = String.Empty;
            }
            ret = ret.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            ret = ret.Trim(Path.DirectorySeparatorChar);
            ret = Path.DirectorySeparatorChar.ToString() + ret;

            return ret;
        }

        private string SearchFilePath(string basePath, string suffix, out string fullPath)
        {
            string ret = null;
            fullPath = null;
            if (!String.IsNullOrEmpty(suffix))
            {
                ret = suffix;
                string path = basePath;
                while (true)
                {
                    fullPath = Path.Combine(path, suffix);
                    if (File.Exists(fullPath))
                    {
                        break;
                    }
                    string[] segs = path.Split(Path.DirectorySeparatorChar);
                    if (segs.Length > 1)
                    {
                        path = String.Join(Path.DirectorySeparatorChar.ToString(), segs, 0, segs.Length - 1);
                        ret = Path.Combine("..", ret);
                    }
                    else
                    {
                        ret = null;
                        fullPath = null;
                        break;
                    }
                }
            }

            return ret;
        }

        private void RecursiveIterateProjectItems(ProjectItems items, string folderPath)
        {
            Dictionary<string, FileSearchItem> files;
            if (this.searchedFiles.TryGetValue(folderPath, out files))
            {
                foreach (KeyValuePair<string, FileSearchItem> file in files)
                {
                    ProjectItem item = items.AddFromFile(file.Key);
                    this.SetItemProperties(item, file.Value);
                }
            }
            foreach (ProjectItem item in items)
            {
                this.RecursiveIterateProjectItems(item.ProjectItems, this.NormalizeFolderPath(folderPath + Path.DirectorySeparatorChar + item.Name));
            }
        }

        private void SetItemProperties(ProjectItem item, FileSearchItem fileSearch)
        {
            if (fileSearch.properties != null)
            {
                foreach (ItemProperty ip in fileSearch.properties)
                {
                    this.SetPropertyValue(item.Properties, ip.name, ip.value);
                }
            }
        }

        private void SetPropertyValue(Properties ps, string name, object v)
        {
            foreach (Property p in ps)
            {
                if (String.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    p.Value = v;
                    break;
                }
            }
        }
    }
}
