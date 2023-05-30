using System;

namespace GbXmlDesign.Application.Models
{
    [Serializable]
    public class ProjectModel
    {
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDirectoryPath { get; set; }
        public string ProjectPicturePath { get; set; }

        public DateTime ProjectDateCreated { get; set; }
        public DateTime ProjectDateModified { get; set; }
    }
}
