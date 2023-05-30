using GbXmlDesign.Application.Models;
using GbXmlDesign.Shared.Constants;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using System;

namespace GbXmlDesign.Application.Services
{
    public interface IRecentProjectsDataService
    {
        string GetAppDataDirectory();
        void AddProjectToRecentProjects(ProjectModel projectModel);
        RecentProjectsModel LoadRecentProjects();
    }


    public class RecentProjectsDataService : IRecentProjectsDataService
    {
        private const string AppDataDirPathFormat = "{0}\\{1}\\{2}";
        public string GetAppDataDirectory()
        {
            string dirPath = string.Format(AppDataDirPathFormat,
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                HardCodedValues.ApplicationName);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            return dirPath;
        }


        #region // // // Deserialize/Load Recent Projects // // //
        public RecentProjectsModel LoadRecentProjects()
        {
            var recentProjectsModel = new RecentProjectsModel
            {
                RecentProjects = DeserializeXmlFileToList()
            };
            return recentProjectsModel;
        }

        private static List<ProjectModel> DeserializeXmlFileToList()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ProjectModel>));
            using (var reader = new StreamReader(@"C:\Users\peter\Documents\GitHub\GbXmlDesign\GbXmlDesign.Testing\RecentProjects.xml"))
            {
                var projects = (List<ProjectModel>)xmlSerializer.Deserialize(reader);
                return projects;
            }
        }
        #endregion



        #region // // // Serialize/Save Recent Projects // // //
        public void AddProjectToRecentProjects(ProjectModel projectModel)
        {
            var recentProjectsModel = LoadRecentProjects();
            recentProjectsModel.RecentProjects.Insert(0, projectModel);

            if (recentProjectsModel.RecentProjects.Count > HardCodedValues.RecentProjectsVisible)
            {
                recentProjectsModel.RecentProjects = recentProjectsModel.RecentProjects.Take(HardCodedValues.RecentProjectsVisible).ToList();
            }

            SerializeListToXmlFile(recentProjectsModel.RecentProjects);
        }

        private static void SerializeListToXmlFile(List<ProjectModel> recentProjects)
        {
            if(recentProjects.Count > 0)
            {
                var xmlSerializer = new XmlSerializer(typeof(List<ProjectModel>));
                using (var writer = new StreamWriter(@"C:\Users\peter\Documents\GitHub\GbXmlDesign\GbXmlDesign.Testing\RecentProjects.xml"))
                {
                    xmlSerializer.Serialize(writer, recentProjects);
                }
            }
        }
        #endregion

    }
}
