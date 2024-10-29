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
            mainpanel.Visible = false;
            recordpanel.Visible = false;
            returnpanel.Visible = false;
            viewallpanel.Visible = false;
            updateproductspanel.Visible = false;
            billcheckpanel.Visible = false;
            addProductspanel.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            recordpanel.Visible = false;
            returnpanel.Visible = false;
            viewallpanel.Visible = false;
            addProductspanel.Visible = false;
            billcheckpanel.Visible = false;
            updateproductspanel.Visible = true;
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
            viewAll();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            returnpanel.Visible = false;
            viewallpanel.Visible = false;
            updateproductspanel.Visible = false;
            addProductspanel.Visible = false;
            billcheckpanel.Visible = false;
            recordpanel.Visible = true;
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
            button28.Text = "Edit";
            rid.Text = "";
            returnname.Text = "";
            returnquantity.Text = "";
            dataGridView2.Rows.Clear();
            mainpanel.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            viewallpanel.Visible = false;
            viewsearch.Text = "";
            mainpanel.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            updateproductspanel.Visible = false;
            updateclear();
            updatesearch.Text = "";
            dataGridView3.Rows.Clear();
            mainpanel.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addProductspanel.Visible = false;
            clearaddproducts();
            mainpanel.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            billcheckpanel.Visible = false;
            mainpanel.Visible = true;
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
            p_pricebox.Text = "";
            r_pricebox.Text = "";
            unitbox.Text = "";
            unitequalsbox.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                string name = namebox.Text;
                int quantity = int.Parse(unitbox.Text) * int.Parse(unitequalsbox.Text);
                decimal purchasePrice = decimal.Parse(p_pricebox.Text);
                decimal retailPrice = decimal.Parse(r_pricebox.Text);
                decimal totalPrice = decimal.Parse(p_pricebox.Text) * quantity;

                if (conn.State != ConnectionState.Open) { conn.Open(); };
                string insertQuery = "INSERT INTO COSMETICS_STORE (NAME, QUANTITY, PURCHASEPRICE, RETAILPRICE, TOTALUNIT, PERUNITEQUALS, TOTALPRICE) " +
                                "VALUES (:name, :quantity, :purchasePrice, :retailPrice, :totalUnit, :perUnitEquals, :totalPrice)";

                using (OracleCommand command = new OracleCommand(insertQuery, conn))
                {
                    // Add parameters to prevent SQL Injection
                    command.Parameters.Add(new OracleParameter("name", name));
                    command.Parameters.Add(new OracleParameter("quantity", quantity));
                    command.Parameters.Add(new OracleParameter("purchasePrice", purchasePrice));
                    command.Parameters.Add(new OracleParameter("retailPrice", retailPrice));
                    command.Parameters.Add(new OracleParameter("totalUnit", int.Parse(unitbox.Text))); // Adjust as needed
                    command.Parameters.Add(new OracleParameter("perUnitEquals", int.Parse(unitequalsbox.Text)));
                    command.Parameters.Add(new OracleParameter("totalPrice", totalPrice));

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
            if (char.IsControl(e.KeyChar))
            {
                return; // Allow control keys
            }

            // Check if the character is a digit
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress non-digit characters
                return;
            }

            // Allow only digits greater than 0
            if (quantitybox.Text.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = true; // Suppress '0' as the first character
            }

            // Additional check to ensure only valid numbers are allowed
            if (quantitybox.Text == "0" && e.KeyChar != '\0')
            {
                e.Handled = true; // Suppress any character after '0'
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

                    string query = "UPDATE cosmetics_store SET quantity = quantity + :additionalQuantity WHERE id = :id";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":additionalQuantity", addQty);
                        cmd.Parameters.Add(":id", ids);

                        int rowsAffected = cmd.ExecuteNonQuery();

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

        private void button21_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(updatesearch.Text))
            {
                MessageBox.Show("Search box is empty");
                return;
            }
            updateSearch();
        }

        private void updateSearch()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Get the search term from the updatesearch TextBox
                string searchTerm = updatesearch.Text;

                // SQL query to fetch records where the name partially matches the search term
                string query = "SELECT ID, NAME, QUANTITY, PURCHASEPRICE, RETAILPRICE, TOTALUNIT, PERUNITEQUALS, TOTALPRICE " +
                               "FROM COSMETICS_STORE WHERE LOWER(NAME) LIKE :searchTerm";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Use wildcard search with LIKE operator
                    cmd.Parameters.Add(":searchTerm", OracleDbType.Varchar2).Value = "%" + searchTerm + "%";

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear existing rows in dataGridView3
                        dataGridView3.Rows.Clear();

                        // Loop through the results and add each row to dataGridView3
                        while (reader.Read())
                        {
                            int rowIndex = dataGridView3.Rows.Add(); // Add a new row and get its index
                            dataGridView3.Rows[rowIndex].Cells[0].Value = reader["ID"];
                            dataGridView3.Rows[rowIndex].Cells[1].Value = reader["NAME"];
                            dataGridView3.Rows[rowIndex].Cells[2].Value = reader["QUANTITY"];
                            dataGridView3.Rows[rowIndex].Cells[3].Value = reader["PURCHASEPRICE"];
                            dataGridView3.Rows[rowIndex].Cells[4].Value = reader["RETAILPRICE"];
                            dataGridView3.Rows[rowIndex].Cells[5].Value = reader["TOTALUNIT"];
                            dataGridView3.Rows[rowIndex].Cells[6].Value = reader["PERUNITEQUALS"];
                            dataGridView3.Rows[rowIndex].Cells[7].Value = reader["TOTALPRICE"];
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
        private void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                updateid.Text = selectedRow.Cells[0].Value?.ToString();
                updatename.Text = selectedRow.Cells[1].Value?.ToString();
                update_p_p.Text = selectedRow.Cells[3].Value?.ToString();
                update_r_price.Text = selectedRow.Cells[4].Value?.ToString();
                updateunits.Text = selectedRow.Cells[5].Value?.ToString();
                updateperunit.Text = selectedRow.Cells[6].Value?.ToString();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private Boolean updateCheck()
        {
            if (string.IsNullOrEmpty(updateid.Text))
            {
                MessageBox.Show("Search and then select row first!");
                return false;
            }

            if (string.IsNullOrEmpty(updatename.Text))
            {
                MessageBox.Show("Name is empty!");
                return false;
            }

            if (string.IsNullOrEmpty(update_p_p.Text))
            {
                MessageBox.Show("Purchase Price is empty!");
                return false;
            }

            if (string.IsNullOrEmpty(update_r_price.Text))
            {
                MessageBox.Show("Retail Price is empty!");
                return false;
            }

            if (string.IsNullOrEmpty(updateunits.Text))
            {
                MessageBox.Show("Total Units is empty!");
                return false;
            }

            if (string.IsNullOrEmpty(updateperunit.Text))
            {
                MessageBox.Show("Per Units equal is empty");
                return false;
            }
            return true;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (!updateCheck())
            {
                return;
            }

            int id = int.Parse(updateid.Text);
            string name = updatename.Text;
            decimal purchasePrice = decimal.Parse(update_p_p.Text);
            decimal retailPrice = decimal.Parse(update_r_price.Text);
            decimal totalUnits = decimal.Parse(updateunits.Text);
            decimal perUnit = decimal.Parse(updateperunit.Text);

            int quantity = ((int)totalUnits) * ((int)perUnit);
            decimal totalPrice = quantity * purchasePrice;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = @"UPDATE cosmetics_store
                     SET name = :name,
                         quantity = :quantity,
                         purchaseprice = :purchasePrice,
                         retailprice = :retailPrice,
                         totalunit = :totalUnit,
                         perunitequals = :perUnitEquals,
                         totalprice = :totalPrice
                     WHERE id = :id";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Add parameters to avoid SQL injection and properly assign values
                    cmd.Parameters.Add(":name", name);
                    cmd.Parameters.Add(":quantity", quantity);
                    cmd.Parameters.Add(":purchasePrice", purchasePrice);
                    cmd.Parameters.Add(":retailPrice", retailPrice);
                    cmd.Parameters.Add(":totalUnit", totalUnits);
                    cmd.Parameters.Add(":perUnitEquals", perUnit);
                    cmd.Parameters.Add(":totalPrice", totalPrice);
                    cmd.Parameters.Add(":id", id);

                    // Execute the update command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Confirm if the update was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!");
                        updateclear();
                        updateSearch();
                    }
                    else
                    {
                        MessageBox.Show("No record found with the specified ID.");
                    }

                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            updateclear();
            updatesearch.Text = "";
            dataGridView3.Rows.Clear();
        }

        private void updateclear()
        {
            updateid.Text = "";
            updatename.Text = "";
            update_p_p.Text = "";
            update_r_price.Text = "";
            updateunits.Text = "";
            updateperunit.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the database connection is open
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                if (dataGridView3.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                    string ids = selectedRow.Cells[0].Value?.ToString();



                    int id = int.Parse(ids);

                    // SQL query to delete the row where the ID matches
                    string query = "DELETE FROM cosmetics_store WHERE id = :id";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Add the ID parameter to the command
                        cmd.Parameters.Add(":id", id);

                        // Execute the delete command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Confirm if the deletion was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully!");
                            updateSearch();
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified ID.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row first.");
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

        private void viewAll()
        {
            try
            {
                // Ensure the database connection is open
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // SQL query to retrieve data from COSMETICS_STORE
                string query = "SELECT ID, NAME, QUANTITY, PURCHASEPRICE, RETAILPRICE, TOTALUNIT, PERUNITEQUALS, TOTALPRICE FROM COSMETICS_STORE";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear existing rows in dataGridView5
                        dataGridView5.Rows.Clear();

                        // Loop through each row in the data reader
                        while (reader.Read())
                        {
                            // Create a new row for each record
                            int rowIndex = dataGridView5.Rows.Add();

                            // Set each cell in the row manually
                            dataGridView5.Rows[rowIndex].Cells[0].Value = reader["ID"];
                            dataGridView5.Rows[rowIndex].Cells[1].Value = reader["NAME"];
                            dataGridView5.Rows[rowIndex].Cells[2].Value = reader["QUANTITY"];
                            dataGridView5.Rows[rowIndex].Cells[3].Value = reader["PURCHASEPRICE"];
                            dataGridView5.Rows[rowIndex].Cells[4].Value = reader["RETAILPRICE"];
                            dataGridView5.Rows[rowIndex].Cells[5].Value = reader["TOTALUNIT"];
                            dataGridView5.Rows[rowIndex].Cells[6].Value = reader["PERUNITEQUALS"];
                            dataGridView5.Rows[rowIndex].Cells[7].Value = reader["TOTALPRICE"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection if it's open
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

        }
        private void button43_Click(object sender, EventArgs e)
        {
           
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SearchAndLoadData();
        }

        private void SearchAndLoadData()
        {
            string searchInput = viewsearch.Text.Trim(); // Trim whitespace from input

            // Clear existing rows in DataGridView
            dataGridView5.Rows.Clear();

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Determine whether the input is numeric (ID) or text (name)
                bool isNumeric = int.TryParse(searchInput, out int id);

                // Choose the query based on the input type
                string query;
                if (isNumeric)
                {
                    // Query by ID
                    query = "SELECT ID, NAME, QUANTITY, PURCHASEPRICE, RETAILPRICE, TOTALUNIT, PERUNITEQUALS, TOTALPRICE " +
                            "FROM COSMETICS_STORE WHERE ID = :id";
                }
                else
                {
                    // Query by Name (partial match using LIKE)
                    query = "SELECT ID, NAME, QUANTITY, PURCHASEPRICE, RETAILPRICE, TOTALUNIT, PERUNITEQUALS, TOTALPRICE " +
                            "FROM COSMETICS_STORE WHERE NAME LIKE :name";
                }

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Set the appropriate parameter based on the input type
                    if (isNumeric)
                    {
                        cmd.Parameters.Add(new OracleParameter(":id", id));
                    }
                    else
                    {
                        cmd.Parameters.Add(new OracleParameter(":name", $"%{searchInput}%"));
                    }

                    // Execute the query with a DataReader
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // Loop through each row in the result set
                        while (reader.Read())
                        {
                            // Add a new row to DataGridView with values from the reader
                            int rowIndex = dataGridView5.Rows.Add();
                            dataGridView5.Rows[rowIndex].Cells[0].Value = reader["ID"];
                            dataGridView5.Rows[rowIndex].Cells[1].Value = reader["NAME"];
                            dataGridView5.Rows[rowIndex].Cells[2].Value = reader["QUANTITY"];
                            dataGridView5.Rows[rowIndex].Cells[3].Value = reader["PURCHASEPRICE"];
                            dataGridView5.Rows[rowIndex].Cells[4].Value = reader["RETAILPRICE"];
                            dataGridView5.Rows[rowIndex].Cells[5].Value = reader["TOTALUNIT"];
                            dataGridView5.Rows[rowIndex].Cells[6].Value = reader["PERUNITEQUALS"];
                            dataGridView5.Rows[rowIndex].Cells[7].Value = reader["TOTALPRICE"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void medicinebox_TextChanged(object sender, EventArgs e)
        {
            LoadMatchingNames(medicinebox.Text);
        }

        private void LoadMatchingNames(string searchName)
        {
            // Clear existing rows in DataGridView
            dataGridView1.Rows.Clear();

            if (string.IsNullOrWhiteSpace(searchName))
            {
                return; // If the search box is empty, don't perform any search
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // SQL query for partial match on the NAME column
                string query = "SELECT NAME FROM COSMETICS_STORE WHERE NAME LIKE :name and quantity>0";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Set the parameter with the search term, using '%' for partial match
                    cmd.Parameters.Add(new OracleParameter(":name", $"%{searchName}%"));

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // Loop through each row in the result set
                        while (reader.Read())
                        {
                            // Add a new row in DataGridView and set the NAME in the first column (index 0)
                            int rowIndex = dataGridView1.Rows.Add();
                            dataGridView1.Rows[rowIndex].Cells[0].Value = reader["NAME"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the value from the clicked cell
                string cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Copy the cell value to the TextBox
                medicinebox.Text = cellValue;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(medicinebox.Text))
            {
                MessageBox.Show("Please enter a Name.");
                return;
            }

            if (string.IsNullOrEmpty(quantitybox.Text))
            {
                MessageBox.Show("Please enter a Quantity.");
                return;
            }
                string name = medicinebox.Text;
                int qty=int.Parse(quantitybox.Text);

                // Retrieve the name and quantity from textboxes
                string searchName = medicinebox.Text;
                int specifiedQuantity= int.Parse(quantitybox.Text);

                try
                {
                    // Open the connection if it's not already open
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    // Query to retrieve the quantity based on the name
                    string query = "SELECT quantity FROM cosmetics_store WHERE name = :name";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":name", searchName);

                        // Execute the query and retrieve the quantity
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int existingQuantity = Convert.ToInt32(result);

                            // Check if the existing quantity is equal to or less than the specified quantity
                            if (specifiedQuantity <= existingQuantity)
                            {
                                AddToDataGrid();
                            }
                            else
                            {
                                MessageBox.Show("Availale quantity is: " + existingQuantity);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified name.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
        }

        private void AddToDataGrid()
        {
            // Get the name and quantity from the text boxes
            string name = medicinebox.Text;
            int quantity;

            // Validate that quantity is a positive integer
            if (!int.TryParse(quantitybox.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.");
                return;
            }

            decimal price = 0;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Retrieve the retail price for the product name from the database
                string query = "SELECT RETAILPRICE FROM cosmetics_store WHERE NAME = :name";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(":name", name);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        price = Convert.ToDecimal(result); // Get the retail price
                    }
                    else
                    {
                        MessageBox.Show("No record found for the specified name.");
                        return;
                    }
                }

                // Calculate the total cost
                decimal total = price * quantity;

                // Generate the serial number based on the current number of rows
                int serialNumber = dataGridView4.Rows.Count + 1;

                // Add data to the DataGridView
                int rowIndex = dataGridView4.Rows.Add();
                dataGridView4.Rows[rowIndex].Cells[0].Value = serialNumber;  // Serial Number
                dataGridView4.Rows[rowIndex].Cells[1].Value = name;          // Name
                dataGridView4.Rows[rowIndex].Cells[2].Value = price;         // Price
                dataGridView4.Rows[rowIndex].Cells[3].Value = quantity;      // Quantity
                dataGridView4.Rows[rowIndex].Cells[4].Value = total;         // Total

                // Clear the input fields for the next entry
                medicinebox.Text = "";
                quantitybox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void setStock()
        {

        }
    }
}