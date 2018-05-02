using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Configuration;

namespace SalesForce.Fields
{
    public class Installer
    {
        public Installer() { }

        public void Install()
        {
            Boolean saveSection = false;
            var configManager = ConfigManager.GetManager();
            var config = configManager.GetSection<ToolboxesConfig>();

            var controls = config.Toolboxes["FormControls"];
            var sectionName = "SalesForceFields";
            var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

            if (section == null)
            {
                section = new ToolboxSection(controls.Sections)
                {
                    Name = sectionName,
                    Title = sectionName,
                    Description = sectionName,
                    ResourceClassId = typeof(PageResources).Name
                };
                controls.Sections.Add(section);
                saveSection = true;
            }

            var controlName = "SalesForceDropDown";
            var controlType = typeof(Fields.DropDown);
            if (!section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = controlName,
                    Title = controlName,
                    Description = controlName,
                    ControlType = controlType.AssemblyQualifiedName,
                    CssClass = "sfDropdownIcn"
                };
                section.Tools.Add(tool);
                saveSection = true;
            }

            controlName = "SalesForceTextBox";
            controlType = typeof(Fields.TextBox);
            if (!section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = controlName,
                    Title = controlName,
                    Description = controlName,
                    ControlType = controlType.AssemblyQualifiedName,
                    CssClass = "sfTextboxIcn"
                };
                section.Tools.Add(tool);
                saveSection = true;
            }

            controlName = "SalesForceAutoComplete";
            controlType = typeof(Fields.AutoCompleteTextBox);
            if (!section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = controlName,
                    Title = controlName,
                    Description = controlName,
                    ControlType = controlType.AssemblyQualifiedName,
                    CssClass = "sfTextboxIcn"
                };
                section.Tools.Add(tool);
                saveSection = true;
            }

            if (saveSection == true)
            {
                configManager.SaveSection(config);
            }
        }
        public void Uninstall()
        {
            throw new NotImplementedException();
        }
    }
}
