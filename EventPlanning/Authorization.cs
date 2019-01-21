using System;
using System.Linq;
using System.Windows.Forms;

namespace EventPlanning
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LogIn(sender, e);
        }

        private void LogIn(object sender, EventArgs e)
        {
            var dbSet = new EventPlanningContainer().Set<User>();

            if (dbSet.FirstOrDefault(x => x.Login == textBoxLogin.Text && x.Password == textBoxPassword.Text) != null)
            {
                Hide();
                var main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show(@"Invalid login or password!");
            }
        }

        private void Authorization_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LogIn(sender, e);
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LogIn(sender, e);
        }
    }
}
