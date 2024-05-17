using CSW8Test;
using CSW8Test.Model.Enums;


namespace GUIWithCSW8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Init Config handler
            ConfigurationHandler.Initialize();
        }

        List<string> Members = new List<string>();

       // Counter: Here a is the value of number of counters
        private int a = 0;

        private void AddMemberBtn_Click(object sender, EventArgs e)
        {
            // Get text from the TextBox
            string textToAdd = MemberTbx.Text.Trim();


            // Add text to the ListBox if it's not empty
            if (!string.IsNullOrEmpty(textToAdd))
            {
                Memberslbx.Items.Add(textToAdd);
                MemberTbx.Clear(); // Clear the TextBox after adding the text
                a++;     // increase the member count if member added to listbox
            }
            else
            {
                MessageBox.Show("Please enter text to add.");
            }

            NoOfmembers.Text = a.ToString();

            /*
             * Update language
             */

            string temp = Language.Deutsch.ToString();

            ConfigurationHandler.SystemConfiguration.GeneralConfig.Language = (Language)Enum.Parse(typeof(Language), temp);

            // When save button is pressed
            
            SaveConfiguration();

            // When read
            Read();

        }

        private void SaveConfiguration()
        {
            ConfigurationHandler.Save();
        }

        private void Read()
        {
            ConfigurationHandler.Read();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = minValue;
            numericUpDown1.Maximum = maxValue;
        }

        private int minValue = 16;
        private int maxValue = 250;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < minValue)
            {
                MessageBox.Show($"Please enter a value greater than or equal to {minValue}.");
                numericUpDown1.Value = minValue;
            }
            else if (numericUpDown1.Value > maxValue)
            {
                MessageBox.Show($"Please enter a value less than or equal to {maxValue}.");
                numericUpDown1.Value = maxValue;
            }
        }

        private void Langaugebox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem.ToString() == null || ((ComboBox)sender).SelectedItem.ToString().Equals(""))
                return;
    
            var objItem = (Language)Enum.Parse(typeof(Language), ((ComboBox)sender).SelectedItem.ToString());

            ConfigurationHandler.SystemConfiguration.GeneralConfig.Language = objItem;

        }


    }
}

