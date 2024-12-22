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
                }
                else
                {
                    sysnum_combo4.Items.Add(i);
                    sysnum_combo5.Items.Add(i);
                }
            }
        }


        private void CheckSelectedItem_ComboSysNum()
        {
            if (sysnum_combo5.SelectedItem.ToString() != "انتخاب کنید")
            {
                controller_grp5.Enabled = true;
                //sysnumcombovalue = sysnum_combo.SelectedItem.ToString();
            }
            else
            {
                //sysnumcombovalue = sysnum_combo.SelectedItem.ToString();
                controller_grp5.Enabled = false;
                cost_grp5.Enabled = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
