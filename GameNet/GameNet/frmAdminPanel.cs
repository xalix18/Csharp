using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameNet
{
    public partial class frmAdminPanel : Form
    {
        public frmAdminPanel()
        {
            InitializeComponent();
        }
        //توابع
        public string radcontrollervalue;
        public string sysnumcombovalue;


        private void AddSyscomboItem()
        {
            for (int i = 0; i <= 10; i++)
            {
                if (i == 0)
                {
                    sysnum_combo4.Items.Add("انتخاب کنید");
                    sysnum_combo4.Text = "انتخاب کنید";
                    sysnum_combo5.Items.Add("انتخاب کنید");
                    sysnum_combo5.Text = "انتخاب کنید";
                    sysnum_combopc.Items.Add("انتخاب کنید");
                    sysnum_combopc.Text = "انتخاب کنید";
                }
                else
                {
                    sysnum_combo4.Items.Add(i);
                    sysnum_combo5.Items.Add(i);
                    sysnum_combopc.Items.Add(i);

                }
            }
        }


        private void CheckSelectedItem_ComboSysNum()
        {
            if (sysnum_combo5.Items.Count == 11 && sysnum_combo4.Items.Count == 11 && sysnum_combopc.Items.Count == 11)
            {


                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1":
                        if (sysnum_combo5.SelectedItem.ToString() != "انتخاب کنید")
                        {
                            controller_grp5.Enabled = true;
                        }
                        else
                        {
                            controller_grp5.Enabled = false;
                            cost_grp5.Enabled = false;
                        }
                        break;
                    case "tabPage2":
                        if (sysnum_combo4.SelectedItem.ToString() != "انتخاب کنید")
                        {
                            controller_grp4.Enabled = true;
                        }
                        else
                        {
                            controller_grp4.Enabled = false;
                            cost_grp4.Enabled = false;
                        }
                        break;
                    case "tabPage3":
                        if (sysnum_combopc.SelectedItem.ToString() != "انتخاب کنید")
                        {
                            cost_grppc.Enabled = true;
                        }
                        else
                        {
                            cost_grppc.Enabled = false;
                        }
                        break;
                }
            }
        }


        private void addDataRow()
        {
            var categoryValues = new Dictionary<string, int>
            {
                { "تک دسته", 1 },
                { "دو دسته", 2 },
                { "سه دسته", 3 },
                { "چهار دسته", 4 }
            };

            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":

                    if (sysnum_combo5.SelectedItem.ToString() != "انتخاب کنید")
                    {
                        sysnumcombovalue = sysnum_combo5.SelectedItem.ToString();
                    }

                    foreach (Control control in controller_grp5.Controls)
                    {
                        if (control is RadioButton radioButton && radioButton.Checked)
                        {
                            radcontrollervalue = radioButton.Text;
                            break; // Exit the loop after finding the checked radio button
                        }
                    }

                    foreach (Control control in cost_grp5.Controls)
                    {
                        if (control is RadioButton radioButton && radioButton.Checked)
                        {
                            switch (radioButton.Name)
                            {
                                case "rad_csttime5":
                                    if (txb_csttime5.Text.Length > 0)
                                    {
                                        if (categoryValues.TryGetValue(radcontrollervalue, out int radcontrollervalueASnum))
                                        {
                                            foreach (DataGridViewRow row in dgv_5.Rows)
                                            {
                                                if (row.Cells[0].Value.ToString() == sysnumcombovalue.ToString()) // شماره سیستم در ستون اول
                                                {
                                                    MessageBox.Show("این شماره سیستم قبلاً وارد شده است.");
                                                    return; // جلوگیری از اضافه شدن ردیف
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case "rad_cstmoney5":
                                    if (txb_cstmoney5.Text.Length > 0)
                                    {
                                        //costmoneyvalue = int.Parse(txtbxmoney_cost.Text);
                                        
                                    }
                                    break;
                                case "rad_cstfree5":
                                    //costfreevalue = true;
                                    
                                    break;
                            }
                        }
                    }





                            break;
                case "tabPage2":
                    break;
                case "tabPage3":
                    break;

            }







        }












        private void sysnum_combo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedItem_ComboSysNum();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp5.Enabled = true;
        }

        private void rad_crt2_5_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp5.Enabled = true;
        }

        private void rad_crt3_5_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp5.Enabled = true;
        }

        private void rad_crt4_5_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp5.Enabled = true;
        }

        private void frmAdminPanel_Load(object sender, EventArgs e)
        {
            AddSyscomboItem();
        }
        private void sysnum_combopc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedItem_ComboSysNum();
        }
        
        private void sysnum_combo4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckSelectedItem_ComboSysNum();
        }

        private void rad_crt1_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;
        }

        private void rad_crt2_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;
        }

        private void rad_crt3_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;

        }

        private void rad_crt4_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;
        }

        private void rad_csttime_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_csttime4.Checked)
            {
                txb_csttime4.Enabled = true;
            }
            else
            {
                txb_csttime4.Enabled = false;
            }
        }

        private void rad_cstmoney_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_cstmoney4.Checked)
            {
                txb_cstmoney4.Enabled = true;
            }
            else
            {
                txb_cstmoney4.Enabled = false;
            }
        }

        private void btn_start5_Click(object sender, EventArgs e)
        {
            addDataRow();
        }
    }
}
