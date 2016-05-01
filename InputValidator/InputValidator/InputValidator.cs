using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace InputValidator
{
    public partial class InpValidator : Form
    {
        public InpValidator()
        {
            InitializeComponent();
        }

        private void InpValidator_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!Regex.IsMatch(TxtName.Text, @"^(A-Za-z]*\s*)*$"))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
            }
            if(!Regex.IsMatch(TxtPhone.Text, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$"))
            {
                MessageBox.Show("The phone number is not a valid US phone number");
            }
            if (!Regex.IsMatch(TxtEmail.Text, @"^([a-zA-Z0-9_\-” [email protected]\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                MessageBox.Show("The e-mail address is not valid.");
            }
            TxtPhone.Text = ReformatPhone(TxtPhone.Text);
        }

        static string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
            return String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
        }
    }
 }
