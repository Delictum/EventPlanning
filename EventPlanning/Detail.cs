using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace EventPlanning
{
    public partial class Detail : Form
    {
        private DbSet<Position> _dbSetPositions;
        private DbSet<Group> _dbSetGroups;
        private DbSet<FullName> _dbSetFullNames;
        private DbSet<Employee> _dbSetEmployees;
        private DbContext _db;
        private Employee _employee;

        private readonly bool _create;
        private Main _mainForm;

        public Detail(Main mainForm)
        {
            InitializeComponent();

            Init(mainForm);

            buttonDelete.Visible = false;
            _create = true;
        }

        public Detail(Main mainForm, Employee employee)
        {
            InitializeComponent();
            _employee = employee;

            Init(mainForm);
            FillEmployee();
        }

        private void Init(Main mainForm)
        {
            this._mainForm = mainForm;
            _db = new EventPlanningContainer();
            _dbSetPositions = _db.Set<Position>();
            _dbSetGroups = _db.Set<Group>();
            _dbSetFullNames = _db.Set<FullName>();
            _dbSetEmployees = _db.Set<Employee>();

            comboBoxGroup.DataSource = _dbSetGroups.Select(group => group.Name).ToList();
            comboBoxPosition.DataSource = _dbSetPositions.Select(position => position.Name).ToList();
        }

        private void FillEmployee()
        {
            textBoxFirstname.Text = _employee.FullName.FirstName;
            textBoxLastName.Text = _employee.FullName.LastName;
            textBoxSureName.Text = _employee.FullName.SureName;

            if (_employee.Male)
            {
                radioButtonMale.Checked = true;
            }
            else
            {
                radioButtonFemale.Checked = true;
            }

            dateTimePickerBirthday.Value = _employee.Birthday;
            
            comboBoxPosition.Text = _employee.Position.Name;
            comboBoxGroup.Text = _employee.Group.Name;

            textBoxAdress.Text = _employee.Adress;
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFirstname.Text) || string.IsNullOrEmpty(textBoxLastName.Text) ||
                string.IsNullOrEmpty(textBoxSureName.Text) || (!radioButtonFemale.Checked && !radioButtonMale.Checked) ||
                string.IsNullOrEmpty(comboBoxPosition.Text) || string.IsNullOrEmpty(comboBoxGroup.Text) ||
                string.IsNullOrEmpty(textBoxAdress.Text))
            {
                MessageBox.Show("Fill in all the fields");
                return;
            }

            if (_create)
            {
                var messageBoxResult = MessageBox.Show(
                    "Would you like to create?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (messageBoxResult == DialogResult.Yes)
                {
                    var fullNameExistence = true;

                    var fullName = _dbSetFullNames.FirstOrDefault(x => 
                        x.FirstName == textBoxFirstname.Text && 
                        x.LastName == textBoxLastName.Text &&
                        x.SureName == textBoxSureName.Text);

                    if (fullName == null)
                    {
                        fullNameExistence = false;
                        fullName = new FullName
                        {
                            LastName = textBoxLastName.Text,
                            FirstName = textBoxFirstname.Text,
                            SureName = textBoxSureName.Text
                        };
                    }

                    var position = _dbSetPositions.First(x => x.Name == comboBoxPosition.Text);
                    var group = _dbSetGroups.First(x => x.Name == comboBoxGroup.Text);

                    var employee = new Employee();
                    if (fullNameExistence)
                    {
                        employee = new Employee
                        {
                            FullNameId = fullName.Id,
                            PositionId = position.Id,
                            GroupId = group.Id,
                            Birthday = dateTimePickerBirthday.Value,
                            Male = (radioButtonMale.Checked == true) ? true : false,
                            Adress = textBoxAdress.Text
                        };
                    }
                    else
                    {
                        employee = new Employee
                        {
                            FullName = fullName,
                            PositionId = position.Id,
                            GroupId = group.Id,
                            Birthday = dateTimePickerBirthday.Value,
                            Male = (radioButtonMale.Checked == true) ? true : false,
                            Adress = textBoxAdress.Text
                        };
                    }

                    using (var db = new EmployeeContext())
                    {
                        db.Employees.Add(employee);
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                var messageBoxResult = MessageBox.Show(
                    "Would you like to edit?",
                    "Message",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (messageBoxResult == DialogResult.Yes)
                {
                    var fullNameExistence = true;

                    var fullName = _dbSetFullNames.FirstOrDefault(x =>
                        x.FirstName == textBoxFirstname.Text &&
                        x.LastName == textBoxLastName.Text &&
                        x.SureName == textBoxSureName.Text);

                    if (fullName == null)
                    {
                        fullNameExistence = false;
                        fullName = new FullName
                        {
                            LastName = textBoxLastName.Text,
                            FirstName = textBoxFirstname.Text,
                            SureName = textBoxSureName.Text
                        };
                    }

                    var position = _dbSetPositions.First(x => x.Name == comboBoxPosition.Text);
                    var group = _dbSetGroups.First(x => x.Name == comboBoxGroup.Text);

                    using (var db = new EmployeeContext())
                    {
                        _employee = db.Employees.First(x => x.Id == _employee.Id);
                        _employee.PositionId = position.Id;
                        _employee.GroupId = group.Id;
                        _employee.Birthday = dateTimePickerBirthday.Value;
                        _employee.Male = (radioButtonMale.Checked == true) ? true : false;
                        _employee.Adress = textBoxAdress.Text;

                        if (fullNameExistence)
                        {
                            _employee.FullNameId = fullName.Id;
                        }
                        else
                        {
                            _employee.FullName = fullName;
                        }

                        db.SaveChanges();
                    }
                }
            }

            _mainForm.RefreshDataGridViewMain();
            Close();
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            using (var db = new EmployeeContext())
            {
                _employee = db.Employees.First(x => x.Id == _employee.Id);
                db.Employees.Remove(_employee);
                db.SaveChanges();
            }

            _mainForm.RefreshDataGridViewMain();
            Close();
        }
    }
}
