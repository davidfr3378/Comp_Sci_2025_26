using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Me_siento_agotado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Initializes all form controls
            this.FormClosing += Form1_FormClosing;
        }
        // This MUST be outside the constructor
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Delete the customers.txt file when the form closes
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch
            {
                MessageBox.Show("Could not delete customers.txt.");
            }
        }

        // Customer class storing all customer details
        public class Customer
        {
            public string Name { get; set; }         // Customer's full name
            public string Address { get; set; }      // Street address
            public string City { get; set; }         // City name
            public string Province { get; set; }     // Province abbreviation or name
            public string PostalCode { get; set; }   // Postal code string

            // Converts the customer data into a CSV line
            public override string ToString()
            {
                // Returns a single line formatted as CSV
                return $"{Name},{Address},{City},{Province},{PostalCode}";
            }
        }

        // Stores newly added customers until saved
        List<Customer> customerList = new List<Customer>();

        // Text file used for saving customer data
        string filePath = "customers.txt";

        // Validates the Canadian postal code format: L#L #L#
        private bool IsValidPostalCode(string postalCode)
        {
            // Regex enforces alternating letter-digit pattern with space in middle
            return Regex.IsMatch(postalCode, @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$");
        }

        // Loads existing customers from the file into the ListBox
        private void LoadData_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();   // Clear the list box for fresh data
            customerList.Clear();     // Clear unsaved customers in memory

            if (!File.Exists(filePath))
            {
                // Create the file so it exists immediately
                File.Create(filePath).Close();
                MessageBox.Show("File not found. A new customers.txt file has been created.");
                return;
            }

            try
            {
                // Read each line from the file
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split(',');

                    // Ensure the line contains exactly 5 fields
                    if (parts.Length == 5)
                    {
                        // Reconstruct customer from stored data
                        Customer c = new Customer
                        {
                            Name = parts[0],
                            Address = parts[1],
                            City = parts[2],
                            Province = parts[3],
                            PostalCode = parts[4]
                        };

                        // Display the customer in the ListBox
                        listBox1.Items.Add(c.ToString());
                    }
                }
            }
            catch
            {
                // If something goes wrong while reading the file
                MessageBox.Show("Error reading file.");
            }
        }

        // Adds a new customer after validating the input
        private void AddCustomer_Click(object sender, EventArgs e)
        {
            // Validates that all text fields are filled and postal code is valid
            if (string.IsNullOrWhiteSpace(NameTB.Text) ||
                string.IsNullOrWhiteSpace(AddressTB.Text) ||
                string.IsNullOrWhiteSpace(CityTB.Text) ||
                string.IsNullOrWhiteSpace(ProvinceTB.Text) ||
                !IsValidPostalCode(PC_TB.Text))
            {
                // Basic validation failed
                MessageBox.Show("Invalid input. Make sure all fields are filled and postal code is in L#L #L# format.");
                return;
            }

            // Creates a new customer object from the entered data
            Customer c = new Customer
            {
                Name = NameTB.Text,
                Address = AddressTB.Text,
                City = CityTB.Text,
                Province = ProvinceTB.Text,
                PostalCode = PC_TB.Text
            };

            // Add to in-memory list
            customerList.Add(c);

            // Add to ListBox for visual confirmation
            listBox1.Items.Add(c.ToString());

            MessageBox.Show("Customer added.");
        }

        // Saves new customers by appending them to the file
        private void SaveData_Click(object sender, EventArgs e)
        {
            // Ensure file exists before saving
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            if (customerList.Count == 0)
            {
                MessageBox.Show("No new customers to save.");
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    foreach (Customer c in customerList)
                    {
                        sw.WriteLine(c.ToString());
                    }
                }

                MessageBox.Show("Data saved successfully.");
                customerList.Clear();
            }
            catch
            {
                MessageBox.Show("Error saving data.");
            }
        }


        // Auto-generated empty event handlers (unused placeholders)
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}
