using GbXmlDesign.Application.Models;
using Prism.Mvvm;

namespace GbXmlDesign.Presentation.ViewModels
{
    public class ProjectViewModel : BindableBase
    {
        private ProjectModel _projectModel;

        public ProjectModel ProjectModel
        {
            get { return _projectModel; }
            set { SetProperty(ref _projectModel, value); }
        }



        // Additional properties and methods for the UI go here
    }
}

