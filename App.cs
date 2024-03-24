#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Windows.Markup;

#endregion

namespace RAB_Module_04_Challenge
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            // 1. Create ribbon tab
            string tabName = "Revit Add-in Bootcamp";
            try
            {
                app.CreateRibbonTab(tabName);
            }
            catch (Exception)
            {
                Debug.Print("Tab already exists.");
            }

            // 2. Create ribbon panel 
            RibbonPanel panel = Utils.CreateRibbonPanel(app, tabName, "Revit Tools");

            // 3. Create button data instances
            PushButtonData btnData1 = Command1.GetButtonData();
            PushButtonData btnData2 = Command2.GetButtonData();
            PushButtonData btnData3 = Command3.GetButtonData();
            PushButtonData btnData4 = Command4.GetButtonData();
            PushButtonData btnData5 = Command5.GetButtonData();
            PushButtonData btnData6 = Command6.GetButtonData();

            // 4. Create Push buttons
            PushButton myButton1 = panel.AddItem(btnData1) as PushButton;
            PushButton myButton2 = panel.AddItem(btnData2) as PushButton;

            // 5. Create Stacked Buttons (3 in total)
            panel.AddStackedItems(btnData3, btnData4, btnData5);

            // 6. Create a split Button containing Two Push buttons
            // create Split button data instance
            SplitButtonData splitBtnData1 = new SplitButtonData("split1", "Split Button");
            //create Split Button 
            SplitButton mySplitBtn1 = panel.AddItem(splitBtnData1) as SplitButton;
            // add Push-Buttons to Split-Button Instance
            mySplitBtn1.AddPushButton(btnData1);
            mySplitBtn1.AddPushButton(btnData2);


            // 7. Create Pulldown Button "More Tools" with 3 Push Buttons
            // create Pulldown button data instance
            PulldownButtonData pullBtnData1 = new PulldownButtonData("pulldown1", "More Tools");
            // give Button an Image
            pullBtnData1.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.tools_32);
            pullBtnData1.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.tools_16);
            // create Pulldown-Button
            PulldownButton myPullBtn1 = panel.AddItem(pullBtnData1) as PulldownButton;
            // add Push-Buttons to my Pulldown Button
            myPullBtn1.AddPushButton(btnData1);
            myPullBtn1.AddPushButton(btnData2);
            myPullBtn1.AddPushButton(btnData3);
            myPullBtn1.AddPushButton(btnData6);

            // NOTE:
            // To create a new tool, copy lines 35 and 39 and rename the variables to "btnData3" and "myButton3". 
            // Change the name of the tool in the arguments of line 

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }


    }
}
