using System;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySqlConnector;

namespace LogIn_HiveStock
{
    public partial class LogIn_Register : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["HiveStockDb"].ConnectionString;

        // Default Guna Button Navy Color
        private readonly Color defaultButtonColor = Color.FromArgb(9, 28, 64);
        private readonly Color verifiedButtonColor = Color.FromArgb(18, 77, 28);

        // VERIFICATION FLAGS
        private bool isPersonalInfoVerified = false;
        private bool isAccountInfoVerified = false;

        public LogIn_Register()
        {
            InitializeComponent();
        }

        private void LogIn_Register_Load(object sender, EventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void ShowPanel(Panel panel)
        {
            LogIn_Panel.Visible = false;
            Register_Panel.Visible = false;

            panel.Visible = true;
            panel.BringToFront();

            if (panel == Register_Panel)
            {
                ResetRegistrationForm();
            }
        }

        private void ResetRegistrationForm()
        {
            isPersonalInfoVerified = false;
            isAccountInfoVerified = false;

            // STEP 1: Personal Info Enabled
            LastName_Input.Enabled = true;
            FirstName_Input.Enabled = true;
            PhoneNumber_Input.Enabled = true;
            PersonalInfo_Button.Enabled = true;
            PersonalInfo_Button.Text = "Verify";
            PersonalInfo_Button.FillColor = defaultButtonColor;
            PersonalInfo_Button.HoverState.FillColor = defaultButtonColor;

            // STEP 2: Account Info Disabled
            Username_Input.Enabled = false;
            IDNumber_Input.Enabled = false;
            Email_Input.Enabled = false;
            AccountInfo_Button.Enabled = false;
            AccountInfo_Button.Text = "Verify";
            AccountInfo_Button.FillColor = defaultButtonColor;
            AccountInfo_Button.HoverState.FillColor = defaultButtonColor;

            // STEP 3: Passwords & Register Disabled
            Password_Input.Enabled = false;
            ConfirmPassword_Input.Enabled = false;
            Register_Button.Enabled = false;
        }

        private void CheckRegisterButtonState()
        {
            Register_Button.Enabled = isPersonalInfoVerified && isAccountInfoVerified;
        }

        private void SignUp_Hyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPanel(Register_Panel);
        }

        private void LogIn_Hyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            UserView_ProductCatalog catalog = new UserView_ProductCatalog();
            catalog.Show();
            this.Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void R_Back_Button_Click(object sender, EventArgs e)
        {
            ShowPanel(LogIn_Panel);
        }

        private void LogIn_Button_Click(object sender, EventArgs e)
        {
            string userIdInput = Input_UserID.Text.Trim();
            string passwordInput = Input_Password.Text.Trim();

            if (string.IsNullOrEmpty(userIdInput) || string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Please enter both your User ID / Username and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM users 
                            WHERE (id_number = @userId OR username = @userId) 
                            AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userIdInput);
                        cmd.Parameters.AddWithValue("@password", passwordInput);

                        long count = Convert.ToInt64(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            UserView_ProductCatalog catalog = new UserView_ProductCatalog();
                            catalog.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User ID / Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AdminSide adminside = new AdminSide();
            adminside.Show();
            this.Hide();
        }

        private void ForgotPassword_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot_Panel.Visible = true;
            ForgotPassword_Label.Visible = true;
        }

        private void ForgotCancel_Button_Click(object sender, EventArgs e)
        {
            Forgot_Panel.Visible = false;
            ForgotPassword_Label.Visible = false;
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
            Forgot_Panel.Visible = false;
            ForgotPassword_Label.Visible = false;
        }

        // ==========================================
        // 1. VERIFY PERSONAL INFORMATION
        // ==========================================
        private void PersonalInfo_Button_Click_1(object sender, EventArgs e)
        {
            string lastName = LastName_Input.Text.Trim();
            string firstName = FirstName_Input.Text.Trim();
            string phone = PhoneNumber_Input.Text.Trim();

            // Check Empty Fields
            if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please complete all Personal Information fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InvalidateStep1();
                return;
            }

            // Name Validation (No numbers allowed)
            Regex nameRegex = new Regex(@"^[a-zA-Z\s'-]+$");
            if (!nameRegex.IsMatch(firstName) || !nameRegex.IsMatch(lastName))
            {
                MessageBox.Show("Names cannot contain numbers or special characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InvalidateStep1();
                return;
            }

            // Phone Number Validation (Only digits and optional leading '+')
            Regex phoneRegex = new Regex(@"^\+?[0-9]+$");
            if (!phoneRegex.IsMatch(phone))
            {
                MessageBox.Show("Phone number can only contain numbers (and an optional '+' prefix).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InvalidateStep1();
                return;
            }

            // SUCCESS - UPDATE UI AND GUNA BUTTON STYLE
            isPersonalInfoVerified = true;
            PersonalInfo_Button.Text = "Verified";
            PersonalInfo_Button.FillColor = verifiedButtonColor;
            PersonalInfo_Button.HoverState.FillColor = verifiedButtonColor;
            PersonalInfo_Button.ForeColor = Color.White;

            Username_Input.Enabled = true;
            IDNumber_Input.Enabled = true;
            Email_Input.Enabled = true;
            AccountInfo_Button.Enabled = true;

            CheckRegisterButtonState();
        }

        private void InvalidateStep1()
        {
            isPersonalInfoVerified = false;
            PersonalInfo_Button.Text = "Verify";
            PersonalInfo_Button.FillColor = defaultButtonColor;
            PersonalInfo_Button.HoverState.FillColor = defaultButtonColor;
            PersonalInfo_Button.ForeColor = Color.White;

            Username_Input.Enabled = false;
            IDNumber_Input.Enabled = false;
            Email_Input.Enabled = false;
            AccountInfo_Button.Enabled = false;
            CheckRegisterButtonState();
        }

        // ==========================================
        // 2. VERIFY ACCOUNT INFORMATION
        // ==========================================
        private void AccountInfo_Button_Click(object sender, EventArgs e)
        {
            string username = Username_Input.Text.Trim();
            string idNumber = IDNumber_Input.Text.Trim();
            string email = Email_Input.Text.Trim();

            // Check Empty Fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(idNumber) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please complete all Account Information fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InvalidateStep2();
                return;
            }

            // ID Number Validation (Digits and hyphens only)
            Regex idRegex = new Regex(@"^[0-9-]+$");
            if (!idRegex.IsMatch(idNumber))
            {
                MessageBox.Show("ID Number can only contain digits and hyphens (e.g., 123-1234-1).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InvalidateStep2();
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE id_number = @id_number OR username = @username OR email_address = @email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@id_number", idNumber);
                        checkCmd.Parameters.AddWithValue("@username", username);
                        checkCmd.Parameters.AddWithValue("@email", email);

                        long existingCount = Convert.ToInt64(checkCmd.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("An account with this ID Number, Username, or Email already exists.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            InvalidateStep2();
                        }
                        else
                        {
                            isAccountInfoVerified = true;
                            AccountInfo_Button.Text = "Verified";
                            AccountInfo_Button.FillColor = verifiedButtonColor;
                            AccountInfo_Button.HoverState.FillColor = verifiedButtonColor;
                            AccountInfo_Button.ForeColor = Color.White;

                            Password_Input.Enabled = true;
                            ConfirmPassword_Input.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InvalidateStep2();
            }

            CheckRegisterButtonState();
        }

        private void InvalidateStep2()
        {
            isAccountInfoVerified = false;
            AccountInfo_Button.Text = "Verify";
            AccountInfo_Button.FillColor = defaultButtonColor;
            AccountInfo_Button.HoverState.FillColor = defaultButtonColor;
            AccountInfo_Button.ForeColor = Color.White;

            Password_Input.Enabled = false;
            ConfirmPassword_Input.Enabled = false;
            CheckRegisterButtonState();
        }

        // ==========================================
        // 3. FINAL REGISTRATION SUBMISSION
        // ==========================================
        private void Register_Button_Click(object sender, EventArgs e)
        {
            string lastName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LastName_Input.Text.Trim().ToLower());
            string firstName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FirstName_Input.Text.Trim().ToLower());
            string phone = PhoneNumber_Input.Text.Trim();
            string username = Username_Input.Text.Trim();
            string idNumber = IDNumber_Input.Text.Trim();
            string email = Email_Input.Text.Trim();
            string password = Password_Input.Text.Trim();
            string confirmPassword = ConfirmPassword_Input.Text.Trim();

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter and confirm your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = @"INSERT INTO users (id_number, first_name, last_name, username, email_address, phone_number, password, created_at) 
                                   VALUES (@id_number, @first_name, @last_name, @username, @email_address, @phone_number, @password, NOW())";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@id_number", idNumber);
                        insertCmd.Parameters.AddWithValue("@first_name", firstName);
                        insertCmd.Parameters.AddWithValue("@last_name", lastName);
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@email_address", email);
                        insertCmd.Parameters.AddWithValue("@phone_number", phone);
                        insertCmd.Parameters.AddWithValue("@password", password);

                        int rows = insertCmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowPanel(LogIn_Panel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Password_Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Input_IconRightClick(object sender, EventArgs e)
        {
            Password_Input.UseSystemPasswordChar = !Password_Input.UseSystemPasswordChar;

            if (Password_Input.UseSystemPasswordChar)
            {
                Password_Input.IconRight = Properties.Resources.hide;
            }
            else
            {
                Password_Input.IconRight = Properties.Resources.show;
            }
        }

        private void ConfirmPassword_Input_IconRightClick(object sender, EventArgs e)
        {
            ConfirmPassword_Input.UseSystemPasswordChar = !ConfirmPassword_Input.UseSystemPasswordChar;

            if (ConfirmPassword_Input.UseSystemPasswordChar)
            {
                ConfirmPassword_Input.IconRight = Properties.Resources.hide;
            }
            else
            {
                ConfirmPassword_Input.IconRight = Properties.Resources.show;
            }
        }

        private void Input_Password_IconRightClick(object sender, EventArgs e)
        {
            Input_Password.UseSystemPasswordChar = !Input_Password.UseSystemPasswordChar;

            if (Input_Password.UseSystemPasswordChar)
            {
                Input_Password.IconRight = Properties.Resources.hide;
            }
            else
            {
                Input_Password.IconRight = Properties.Resources.show;
            }
        }
    }
}