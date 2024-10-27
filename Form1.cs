using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Cosmetics_Store
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();

            string conStr = "Data Source=localhost:1521/XE;User Id=COSMETIC;Password=9910;";
            conn = new OracleConnection(conStr);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            recordpanel.Visible = false;
            viewallpanel.Visible = false;
            updateproductspanel.Visible = false;
            addProductspanel.Visible = false;
            billcheckpanel.Visible = false;
            returnpanel.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            mainpanel.Visible=false;
            recordpanel.Visible=false;
            returnpanel.Visible = false;
            viewallpanel.Visible=false;
            updateproductspanel.Visible=false;
            billcheckpanel.Visible=false;
            addProductspanel.Visible=true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            recordpanel.Visible = false;
            returnpanel.Visible = false;
            viewallpanel.Visible = false;
            addProductspanel.Visible = false;
            billcheckpanel.Visible = false;
            updateproductspanel.Visible=true;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            recordpanel.Visible = false;
            returnpanel.Visible = false;
            updateproductspanel.Visible = false;
            addProductspanel.Visible = false;
            billcheckpanel.Visible = false;
            viewallpanel.Visible = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            returnpanel.Visible = false;
            viewallpanel.Visible = false;
            updateproductspanel.Visible = false;
            addProductspanel.Visible = false;
            billcheckpanel.Visible = false;
            recordpanel.Visible=true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            recordpanel.Visible = false;
            returnpanel.Visible = false;
            viewallpanel.Visible = false;
            updateproductspanel.Visible = false;
            addProductspanel.Visible = false;
            billcheckpanel.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            recordpanel.Visible = false;
            mainpanel.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            returnpanel.Visible = false;
            mainpanel.Visible=true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            viewallpanel.Visible=false;
            mainpanel.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            updateproductspanel.Visible=false;
            mainpanel.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addProductspanel.Visible=false;
            mainpanel.Visible=true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            billcheckpanel.Visible=false;
            mainpanel.Visible=true;
        }

        private void pricebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void discount_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void r_pricebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void unitbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void unitequalsbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearaddproducts();
        }
        
        public void clearaddproducts()
        {
            namebox.Text = "";
            pricebox.Text = "";
            r_pricebox.Text = "";
            discount_box.Text = "";
            unitbox.Text = "";
            unitequalsbox.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = int.Parse(unitbox.Text) * int.Parse(unitequalsbox.Text);
                decimal totalPrice = decimal.Parse(pricebox.Text) * quantity;
                string name = namebox.Text;
                decimal retailPrice = decimal.Parse(r_pricebox.Text);
                decimal discount = decimal.Parse(discount_box.Text);
                decimal salePrice =retailPrice*discount/100; 

                if (conn.State != ConnectionState.Open) { conn.Open(); };
                string insertQuery = "INSERT INTO COSMETICS_STORE (NAME, QUANTITY, TOTALPRICE, RETAILPRICE, SALEPRICE, DISCOUNT, TOTALUNIT, PERUNITEQUALS) " +
                                "VALUES (:name, :quantity, :totalPrice, :retailPrice, :salePrice, :discount, :totalUnit, :perUnitEquals)";

                using (OracleCommand command = new OracleCommand(insertQuery, conn))
                {
                    // Add parameters to prevent SQL Injection
                    command.Parameters.Add(new OracleParameter("name", name));
                    command.Parameters.Add(new OracleParameter("quantity", quantity));
                    command.Parameters.Add(new OracleParameter("totalPrice", totalPrice));
                    command.Parameters.Add(new OracleParameter("retailPrice", retailPrice));
                    command.Parameters.Add(new OracleParameter("salePrice", salePrice)); // Set as needed
                    command.Parameters.Add(new OracleParameter("discount", discount));
                    command.Parameters.Add(new OracleParameter("totalUnit", int.Parse(unitbox.Text))); // Adjust as needed
                    command.Parameters.Add(new OracleParameter("perUnitEquals", int.Parse(unitequalsbox.Text)));

                    // Execute the query
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Data stored successfully!");
                clearaddproducts();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void quantitybox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void receivedbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void discountbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }
    }
}
