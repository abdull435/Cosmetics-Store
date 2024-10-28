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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void button30_Click(object sender, EventArgs e)
        {
            returnSearch();
        }

        private void returnSearch()
        {
            string Name = returnsearch.Text;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Update the query to use the LIKE operator for partial matches
                string qu = "SELECT id, name, quantity FROM cosmetics_store WHERE LOWER(name) LIKE :Name";

                using (OracleCommand cmd = new OracleCommand(qu, conn))
                {
                    // Use parameter binding with lowercase conversion for case-insensitive matching
                    cmd.Parameters.Add(new OracleParameter("Name", "%" + Name.ToLower() + "%"));

                    // Execute the command and fill the DataGridView
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear existing rows before adding new ones
                        dataGridView2.Rows.Clear();

                        // Check if any data is returned
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Add data to each column in the DataGridView
                                int rowIndex = dataGridView2.Rows.Add();
                                dataGridView2.Rows[rowIndex].Cells[0].Value = reader["id"].ToString();
                                dataGridView2.Rows[rowIndex].Cells[1].Value = reader["name"].ToString();
                                dataGridView2.Rows[rowIndex].Cells[2].Value = reader["quantity"].ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No matching records found.");
                        }
                    }
                }

                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            
            if (button28.Text.Equals("Edit"))
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Get the selected row (assuming only one row is selected due to MultiSelect = false)
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    // Retrieve data from specific columns in the selected row
                    String id = selectedRow.Cells[0].Value?.ToString();
                    string name = selectedRow.Cells[1].Value?.ToString();
                    string quantity = selectedRow.Cells[2].Value?.ToString();

                    rid.Text = id;
                    returnname.Text = name;
                    //returnquantity.Text = quantity;

                    button28.Text = "Update";

                }
                else
                {
                    MessageBox.Show("Please select a row first.");
                }
            }
            else if (button28.Text.Equals("Update"))
            {
                int addQty;
                if (!int.TryParse(returnquantity.Text, out addQty))
                {
                    MessageBox.Show("Please enter a valid number for the quantity.");
                    return;
                }

                int ids;
                if (!int.TryParse(rid.Text, out ids))
                {
                    MessageBox.Show("Invalid ID format.");
                    return;
                }

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    // Oracle query to update quantity by adding the input value to the existing quantity
                    string query = "UPDATE cosmetics_store SET quantity = quantity + :additionalQuantity WHERE id = :id";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":additionalQuantity", addQty);
                        cmd.Parameters.Add(":id", ids);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute the query

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Quantity updated successfully!");
                            button28.Text = "Edit";
                            rid.Text = "";
                            returnname.Text = "";
                            returnquantity.Text = "";
                            returnSearch();
                        }
                        else
                        {
                            MessageBox.Show("No matching record found for the specified ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void returnquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            button28.Text = "Edit";
            rid.Text = "";
            returnname.Text = "";
            returnquantity.Text = "";
            dataGridView2.Rows.Clear();
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void unitbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void unitequalsbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
