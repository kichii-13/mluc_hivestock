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

        private readonly Color defaultButtonColor = Color.FromArgb(9, 28, 64);
        private readonly Color verifiedButtonColor = Color.FromArgb(18, 77, 28);

        // VERIFICATION FLAGS
        private bool isPersonalInfoVerified = false;
        private bool isAccountInfoVerified = false;
        private bool isForgotEmailVerified = false;

        public LogIn_Register()
        {
            InitializeComponent();

            // Set password mask immediately on component creation
            Password_Input.UseSystemPasswordChar = false;
            ConfirmPassword_Input.UseSystemPasswordChar = false;
            Input_Password.UseSystemPasswordChar = false;
            NewPass_Input.UseSystemPasswordChar = false;
            Confirm_Input.UseSystemPasswordChar = false;

            Password_Input.PasswordChar = '•';
            ConfirmPassword_Input.PasswordChar = '•';
            Input_Password.PasswordChar = '•';
            NewPass_Input.PasswordChar = '•';
            Confirm_Input.PasswordChar = '•';
        }

        private void LogIn_Register_Load(object sender, EventArgs e)
        {
            ResetLoginForm();
            ResetForgotPasswordForm();
            ShowPanel(LogIn_Panel);
        }

        private void ShowPanel(Panel panel)
        {
            LogIn_Panel.Visible = false;
            Register_Panel.Visible = false;
            Forgot_Panel.Visible = false;
            ForgotPassword_Label.Visible = false;

            panel.Visible = true;
            panel.BringToFront();

            if (panel == Register_Panel)
            {
                ResetRegistrationForm();
            }
            else if (panel == LogIn_Panel)
            {
                ResetLoginForm();
            }
        }

        private void ResetLoginForm()
        {
            Input_StudentID.Clear();
            Input_Password.Clear();
            Input_Password.PasswordChar = '•';
        }

        private void ResetRegistrationForm()
        {
            isPersonalInfoVerified = false;
            isAccountInfoVerified = false;

            // Clear all text inputs
            LastName_Input.Clear();
            FirstName_Input.Clear();
            PhoneNumber_Input.Clear();
            Username_Input.Clear();
            IDNumber_Input.Clear();
            Email_Input.Clear();
            Password_Input.Clear();
            ConfirmPassword_Input.Clear();

            // Personal Info Enabled
            LastName_Input.Enabled = true;
            FirstName_Input.Enabled = true;
            PhoneNumber_Input.Enabled = true;
            PersonalInfo_Button.Enabled = true;
            PersonalInfo_Button.Text = "Verify";
            PersonalInfo_Button.FillColor = defaultButtonColor;
            PersonalInfo_Button.HoverState.FillColor = defaultButtonColor;
            PersonalInfo_Button.ForeColor = Color.White;

            // Account Info Disabled
            Username_Input.Enabled = false;
            IDNumber_Input.Enabled = false;
            Email_Input.Enabled = false;
            AccountInfo_Button.Enabled = false;
            AccountInfo_Button.Text = "Verify";
            AccountInfo_Button.FillColor = defaultButtonColor;
            AccountInfo_Button.HoverState.FillColor = defaultButtonColor;
            AccountInfo_Button.ForeColor = Color.White;

            // Passwords & Register Disabled
            Password_Input.Enabled = false;
            ConfirmPassword_Input.Enabled = false;
            Register_Button.Enabled = false;

            // Enforce password mask on reset
            Password_Input.PasswordChar = '•';
            ConfirmPassword_Input.PasswordChar = '•';
        }

        private void ResetForgotPasswordForm()
        {
            isForgotEmailVerified = false;

            FEmail_Input.Enabled = true;
            FEmail_Input.Clear();

            ForgotEmailVerify_Button.Enabled = true;
            ForgotEmailVerify_Button.Text = "Verify";
            ForgotEmailVerify_Button.FillColor = defaultButtonColor;
            ForgotEmailVerify_Button.HoverState.FillColor = defaultButtonColor;
            ForgotEmailVerify_Button.ForeColor = Color.White;

            NewPass_Input.Enabled = false;
            NewPass_Input.Clear();
            NewPass_Input.PasswordChar = '•';

            Confirm_Input.Enabled = false;
            Confirm_Input.Clear();
            Confirm_Input.PasswordChar = '•';

            Done_Button.Enabled = false;
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
            string userIdInput = Input_StudentID.Text.Trim();
            string passwordInput = Input_Password.Text.Trim();

            if (string.IsNullOrEmpty(userIdInput) || string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Please enter both your User ID / Username and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Strip dashes/spaces to check digit length
            string cleanUserId = Regex.Replace(userIdInput, @"[\s-]", "");

            // Automatically format 8-digit Student IDs into xxx-xxxx-x for login check
            if (Regex.IsMatch(cleanUserId, @"^[0-9]{8}$"))
            {
                userIdInput = string.Format("{0}-{1}-{2}", cleanUserId.Substring(0, 3), cleanUserId.Substring(3, 4), cleanUserId.Substring(7, 1));
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
            ResetForgotPasswordForm();
            Forgot_Panel.Visible = true;
            ForgotPassword_Label.Visible = true;
        }

        private void ForgotCancel_Button_Click(object sender, EventArgs e)
        {
            ResetForgotPasswordForm();
            ShowPanel(LogIn_Panel);
        }

        // SAVE NEW PASSWORD
        private void Done_Button_Click(object sender, EventArgs e)
        {
            if (!isForgotEmailVerified)
            {
                MessageBox.Show("Please verify your email address first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = FEmail_Input.Text.Trim();
            string newPassword = NewPass_Input.Text.Trim();
            string confirmPassword = Confirm_Input.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter and confirm your new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password Validation (Alphanumeric + at least 1 symbol, minimum 12 characters)
            Regex passwordRegex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{12,}$");
            if (!passwordRegex.IsMatch(newPassword))
            {
                MessageBox.Show("Password must be at least 12 characters long and contain letters, numbers, and at least one special character/symbol.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE users SET password = @password WHERE email_address = @email";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@password", newPassword);
                        updateCmd.Parameters.AddWithValue("@email", email);

                        int rows = updateCmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Password has been changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForgotPasswordForm();
                            ShowPanel(LogIn_Panel);
                        }
                        else
                        {
                            MessageBox.Show("Password change failed. Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // VERIFY PERSONAL INFORMATION
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

            // Phone Number Validation (Strip non-digits to verify exactly 11 numbers)
            string cleanPhone = Regex.Replace(phone, @"[^\d]", "");
            if (cleanPhone.Length != 11 || !Regex.IsMatch(phone, @"^[0-9]+$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InvalidateStep1();
                return;
            }

            // SUCCESS - DISABLE VERIFIED INPUTS & UPDATE GUNA BUTTON STYLE
            isPersonalInfoVerified = true;
            PersonalInfo_Button.Text = "Verified";
            PersonalInfo_Button.FillColor = verifiedButtonColor;
            PersonalInfo_Button.HoverState.FillColor = verifiedButtonColor;
            PersonalInfo_Button.ForeColor = Color.White;

            LastName_Input.Enabled = false;
            FirstName_Input.Enabled = false;
            PhoneNumber_Input.Enabled = false;

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

            LastName_Input.Enabled = true;
            FirstName_Input.Enabled = true;
            PhoneNumber_Input.Enabled = true;

            Username_Input.Enabled = false;
            IDNumber_Input.Enabled = false;
            Email_Input.Enabled = false;
            AccountInfo_Button.Enabled = false;
            CheckRegisterButtonState();
        }

        // VERIFY ACCOUNT INFORMATION
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

            // Strip dashes/spaces to verify exactly 8 digits entered
            string cleanId = Regex.Replace(idNumber, @"[\s-]", "");
            if (!Regex.IsMatch(cleanId, @"^[0-9]{8}$"))
            {
                MessageBox.Show("ID Number must be exactly 8 digits (e.g., 12345678).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InvalidateStep2();
                return;
            }

            // Format to xxx-xxxx-x before checking the database
            string formattedId = string.Format("{0}-{1}-{2}", cleanId.Substring(0, 3), cleanId.Substring(3, 4), cleanId.Substring(7, 1));

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE id_number = @id_number OR username = @username OR email_address = @email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@id_number", formattedId);
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
                            // SUCCESS - DISABLE VERIFIED INPUTS & UPDATE GUNA BUTTON STYLE
                            isAccountInfoVerified = true;
                            AccountInfo_Button.Text = "Verified";
                            AccountInfo_Button.FillColor = verifiedButtonColor;
                            AccountInfo_Button.HoverState.FillColor = verifiedButtonColor;
                            AccountInfo_Button.ForeColor = Color.White;

                            Username_Input.Enabled = false;
                            IDNumber_Input.Enabled = false;
                            Email_Input.Enabled = false;

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

            Username_Input.Enabled = true;
            IDNumber_Input.Enabled = true;
            Email_Input.Enabled = true;

            Password_Input.Enabled = false;
            ConfirmPassword_Input.Enabled = false;
            CheckRegisterButtonState();
        }

        // FINAL REGISTRATION SUBMISSION
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

            // Password Validation (Alphanumeric + at least 1 symbol, minimum 12 characters)
            Regex passwordRegex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{12,}$");
            if (!passwordRegex.IsMatch(password))
            {
                MessageBox.Show("Password must be at least 12 characters long and contain letters, numbers, and at least one special character/symbol.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Format the 8-digit input into xxx-xxxx-x before inserting into database
            string cleanId = Regex.Replace(idNumber, @"[\s-]", "");
            if (cleanId.Length == 8)
            {
                idNumber = string.Format("{0}-{1}-{2}", cleanId.Substring(0, 3), cleanId.Substring(3, 4), cleanId.Substring(7, 1));
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
            if (Password_Input.PasswordChar == '•')
            {
                Password_Input.PasswordChar = '\0';
                Password_Input.IconRight = Properties.Resources.show;
            }
            else
            {
                Password_Input.PasswordChar = '•';
                Password_Input.IconRight = Properties.Resources.hide;
            }
        }

        private void ConfirmPassword_Input_IconRightClick(object sender, EventArgs e)
        {
            if (ConfirmPassword_Input.PasswordChar == '•')
            {
                ConfirmPassword_Input.PasswordChar = '\0';
                ConfirmPassword_Input.IconRight = Properties.Resources.show;
            }
            else
            {
                ConfirmPassword_Input.PasswordChar = '•';
                ConfirmPassword_Input.IconRight = Properties.Resources.hide;
            }
        }

        private void Input_Password_IconRightClick(object sender, EventArgs e)
        {
            if (Input_Password.PasswordChar == '•')
            {
                Input_Password.PasswordChar = '\0';
                Input_Password.IconRight = Properties.Resources.show;
            }
            else
            {
                Input_Password.PasswordChar = '•';
                Input_Password.IconRight = Properties.Resources.hide;
            }
        }

        private void ForgotEmailVerify_Button_Click(object sender, EventArgs e)
        {
            string email = FEmail_Input.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE email_address = @email";
                    using (MySqlCommand cmd = new MySqlCommand(checkQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);

                        long count = Convert.ToInt64(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // SUCCESS - UPDATE BUTTON STYLE & DISABLE EMAIL INPUT
                            isForgotEmailVerified = true;
                            ForgotEmailVerify_Button.Text = "Verified";
                            ForgotEmailVerify_Button.FillColor = verifiedButtonColor;
                            ForgotEmailVerify_Button.HoverState.FillColor = verifiedButtonColor;
                            ForgotEmailVerify_Button.ForeColor = Color.White;

                            FEmail_Input.Enabled = false;
                            NewPass_Input.Enabled = true;
                            Confirm_Input.Enabled = true;
                            Done_Button.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("No account found registered with this email address.", "Email Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}