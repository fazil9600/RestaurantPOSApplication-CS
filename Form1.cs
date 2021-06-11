using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Start Function////////////////
        public double Cost_of_items()
        {
            Double sum = 0;
            int i = 0;

            for (i = 0; i < (dataGridView1.Rows.Count);
            i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[1].Cells[2].Value);
            }
            return sum;
        }
        //End Function////////////////



        private void Addcost()
        {
            Double tax, q;
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                lb_tax.Text = String.Format("{0:c2}", (((Cost_of_items() * tax) / 100)));
                lb_subtotal.Text = String.Format("{0:c2}", (Cost_of_items()));
                q = ((Cost_of_items() * tax) / 100);
                lb_total.Text = String.Format("{0:c2}", ((Cost_of_items() + q)));
                //Start Function////////////////

            }
        }
        //End Function////////////////



        //Start Function////////////////

        private void Change()
        {
            Double tax, q, c;
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                q = ((Cost_of_items() * tax) / 100) + Cost_of_items();
                c = Convert.ToInt32(lb_cost.Text);
                lb_change.Text = String.Format("{0:c2}, c - q ");
            }
        }


        //End Function////////////////



        Bitmap bitmap;

        private void bt_print_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {

            try
            {
                lb_total.Text = "";
                lb_subtotal.Text = "";
                lb_tax.Text = "";
                lb_cost.Text = "0";
                lb_change.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cb_payment.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_payment.Items.Add("Cash");
            cb_payment.Items.Add("Visa Card");
            cb_payment.Items.Add("Master Card");
            //lb_cost.Text = "0";

        }

        private void panel1_Click_1(object sender, EventArgs e)
        {

        }

        private void NewNumbersOnly(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (lb_cost.Text == "0")
            {
                lb_cost.Text = "";
                lb_cost.Text = b.Text;
            }
            else if (b.Text == ".")
            {
                if (!lb_cost.Text.Contains("."))
                {
                    lb_cost.Text = lb_cost.Text + b.Text;
                }
            }
            else
                lb_cost.Text = lb_cost.Text + b.Text;
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            lb_cost.Text = "0";
        }

        private void bt_pay_Click(object sender, EventArgs e)
        {
            if(cb_payment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lb_change.Text = "";
                lb_cost.Text = "0";
            }
        }

        private void bt_removeitem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            Addcost();
            if (cb_payment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lb_change.Text = "";
                lb_cost.Text = "0";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Double CostOfItems = 180.00;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if((bool)(row.Cells[0].Value= "Iguru Tea"))
                        {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostOfItems;
                    Addcost();


                }
            }
            dataGridView1.Rows.Add("Iguru Tea", "1", CostOfItems);
            Addcost();


        }

        private void button23_Click(object sender, EventArgs e)
        {
            Double CostOfItems = 80.00;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Vanila Tea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostOfItems;
                    Addcost();


                }
            }
            dataGridView1.Rows.Add("Vanila Tea", "1", CostOfItems);
            Addcost();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Double CostOfItems = 75.00;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Masala Tea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostOfItems;
                    Addcost();


                }
            }
            dataGridView1.Rows.Add("Masala Tea", "1", CostOfItems);
            Addcost();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Double CostOfItems = 95.00;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Gram Tea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostOfItems;
                    Addcost();


                }
            }
            dataGridView1.Rows.Add("Gram Tea", "1", CostOfItems);
            Addcost();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Double CostOfItems = 195.00;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Oroppu Tea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostOfItems;
                    Addcost();


                }
            }
            dataGridView1.Rows.Add("Oroppu Tea", "1", CostOfItems);
            Addcost();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Double CostOfItems = 275.00;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Orange Tea"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostOfItems;
                    Addcost();


                }
            }
            dataGridView1.Rows.Add("Orange Tea", "1", CostOfItems);
            Addcost();
        }
    }
}
