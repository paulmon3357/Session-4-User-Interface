using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace User_Interface
    {
    public partial class FrmWallsFromLines : Form
        {
        public FrmWallsFromLines(List<string> wallTypes, List<String> lineStyles)
            {
            InitializeComponent();

            foreach (string wallType in wallTypes)
                {
                this.cmbWallTypes.Items.Add(wallType);
                }

            foreach (string lineStyle in lineStyles)
                {
                this.cmbLineStyles.Items.Add(lineStyle);
                }

            this.cmbWallTypes.SelectedIndex = 0;
            this.cmbLineStyles.SelectedIndex = 0;

            }

        private void btnCancel_Click(object sender, EventArgs e)
            {
            this.Close();
            }

        private void btnOk_Click(object sender, EventArgs e)
            {
            this.Close();
            }
        }

    public string GetSelectedWallType()
        {
        return cmbWallTypes.SelectedItem.ToString();
        }

    public string GetSelectedLineStyle()
        {
        return cmdLineStyles.SelectedItem.ToString();
        }

    public double GetWallHeight()
        {
        double returnValue = 20;

        double.TryParse(tbxWallHeight.Text, out returnValue);

        return returnValue;
        }

    }
