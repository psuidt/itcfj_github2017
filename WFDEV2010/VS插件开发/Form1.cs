
using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS插件开发
{
    public partial class Form1 : Form
    {
        private EnvDTE80.DTE2 applicationObject;

        public Form1()
        {
            InitializeComponent();
            applicationObject = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.
  GetActiveObject("VisualStudio.DTE.12.0");

            //   EnvDTE80.DTE2 dte;
            //   object obj = null;
            //  System.Type t = null;

            // Get ProgID for DTE 8.0
            // NOTE: Do not put this call in a try block because it 
            // will cause Visual Studio to fail to respond.
            //   t = System.Type.GetTypeFromProgID("VisualStudio.DTE.12.0",
            //  true);

            // Attempt to create an instance of envDTE. 
            //   obj = System.Activator.CreateInstance(t, true);

            // Cast to DTE2.
            //  dte = (EnvDTE80.DTE2)obj;
            //       string sn = applicationObject.Solution;
        }
        private void FindAllprjName(Project prj, ref List<Project> lstPrj)
        {
            if (prj.Kind == "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}")
            {
                lstPrj.Add(prj);
            }
            else
            {
                for (int i = 1; i <= prj.ProjectItems.Count; i++)
                {
                    if (prj.ProjectItems.Item(i).SubProject != null)
                    {
                        this.FindAllprjName(prj.ProjectItems.Item(i).SubProject, ref lstPrj);
                    }
                }
            }
        }






        private List<Project> FindAllPrj(DTE2 _applicationObject)
        {
            List<Project> lstPrj = new List<Project>();
            Solution solution = _applicationObject.Solution;
            for (int i = 1; i <= solution.Projects.Count; i++)
            {
                this.FindAllprjName(solution.Projects.Item(i), ref lstPrj);
            }
            return lstPrj;
        }








        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //FindAllPrj(applicationObject);
            //foreach (var item in  FindAllPrj(applicationObject))
            //{
            //   listBoxControl1.Items.Add(item.Name);
            //}

            EnvDTE.Project proj;
            EnvDTE.Configuration config;
            EnvDTE.Properties configProps;
            EnvDTE.Property prop;
            List<Project> lstPrj = new List<Project>();
            Solution sl = applicationObject.Solution;
            int projectCount = sl.Projects.Count;
            for (int i = 1; i <= projectCount; i++)
            {
                this.FindAllprjName(sl.Projects.Item(i), ref lstPrj);
            }
            List<Project> list = this.FindAllPrj(this.applicationObject);
            foreach (var project in list)
            {
                if (project.Name == "换肤")
                {
             //       proj = project;
             //       config = proj.ConfigurationManager.ActiveConfiguration;
             //       configProps = config.Properties;
             //       configProps.Item("OutputPath").Value = @"D:\";
             //       prop = configProps.Item("OutputPath");
             //       MessageBox.Show("The platform target for this project is: "
             //+ prop.Value.ToString());
                    //listBoxControl1.Items.Add(project.ConfigurationManager.Item(1, "").Properties);
                    //listBoxControl1.Items.Add(project.ConfigurationManager.Item(2, "").ConfigurationName);
                    //// listBoxControl1.Items.Add(project.ConfigurationManager.Item(3, "").ConfigurationName);
                    //listBoxControl1.Items.Add(project.ConfigurationManager.Item(1, "").Properties.Item(14).Value);
                    //listBoxControl1.Items.Add(project.ConfigurationManager.Item(2, "").Properties.Item(14).Value);
                    //listBoxControl1.Items.Add(project.ConfigurationManager.Item(1, "").Properties.Item(0x29).Value);
                    //listBoxControl1.Items.Add(project.Properties.Item(0x3a).Value);
                  //  project.Properties.Item(0x10).Value = @"D:\FrameWork\5.0\Debug";
             //       listBoxControl1.Items.Add(project.Properties.Item(0x10).Value);
                       
                    break;
                }
                continue;
                // listBoxControl1.Items.Add(project.Name);
            }


            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                MessageBox.Show("dfasdfdsafsf");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
