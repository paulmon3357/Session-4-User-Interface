#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;


#endregion

namespace User_Interface
    {
    [Transaction(TransactionMode.Manual)]
    public class cmdWallsFromLines : IExternalCommand
        {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
            {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            TaskDialog.Show("User Interface Exercise", "Walls From lines");

            List<string> wallTypes = GetAllWallTypeNames(doc);
            List<string> lineStyle = GetAllLineStyleNames(doc);

            FrmWallsFromLines curForm = new FrmWallsFromLines(wallTypes, lineStyle);
            curForm.Height = 550;
            curForm.Width = 1218;
            curForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            if (curForm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                /*//do something here
                TaskDialog.Show("Test","Do some work");*/


                //declear variables
                string selectedWallType = "";
                string selectedLineType = "";
                string wallHeight = "";
                bool isStructural = false;



            }

            return Result.Succeeded;
            }



        private List<string> GetAllLineStyleNames(Document doc)
        {
            List<string> results = new List<string>();

            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collector.OfClass(typeof(CurveElement));

            foreach (CurveElement element in collector)
            {
                GraphicsStyle curGS = element.LineStyle as GraphicsStyle;
                if (results.Contains(curGS.Name) == false)
                {
                    results.Add(curGS.Name);
                }
            }

            return results;
        }

        private List<string> GetAllWallTypeNames(Document doc)
        {
            List<string> results = new List<string>();

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(WallType));

            foreach (WallType wallType in collector)
            {
                results.Add(wallType.Name);
            }

            return results;
        }


        }
}