This project holds the custom form fields used for SalesForce account creation.
Compile this project and drop the DLL in the Sitefinity "/bin" directory.

The form handler should already be registered. If it is not do so by logging into 
Sitefinity as an admin and go to Administration/Settings/Advanced/Toolboxes/Toolboxes/PageControls/Sections/ContentToolboxSection/Tools/FormControl.
On the right there should be a textbox labeled "Control CLR Type or Virtual Path".
There enter "SalesForce.Fields.FormHandler.FormControl, SalesForce.Fields".

The custom fields also need to be registered and should be already. If they are not, go to Administration/Settings/Advanced/Toolboxes/Toolboxes/FormControls.
There under Sections there should be a SalesForceContactCreation under that are the individual SaleForce field registrations.
