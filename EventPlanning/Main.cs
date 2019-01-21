using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Word = Microsoft.Office.Interop.Word;

namespace EventPlanning
{
    public partial class Main : Form
    {
        private DbContext _db;
        private DbSet<Employee> _dbSetEmployees;
        private DbSet<Position> _dbSetPositions;
        private DbSet<Group> _dbSetGroups;
        private int currentDataGridViewExportRow;

        public Main()
        {
            InitializeComponent();

            Init();
            LoadDataGridViewEmpoyees();
        }

        private void Init()
        {
            _db = new EventPlanningContainer();
            _dbSetEmployees = _db.Set<Employee>();
            _dbSetPositions = _db.Set<Position>();
            _dbSetGroups = _db.Set<Group>();
            comboBoxGroup.DataSource = _dbSetGroups.Select(group => group.Name).ToList();
            comboBoxPosition.DataSource = _dbSetPositions.Select(position => position.Name).ToList();
        }

        public void RefreshDataGridViewMain()
        {
            var query = _dbSetEmployees.Select(employee => new
            {
                employee.Id,
                employee.FullName.LastName,
                employee.FullName.FirstName,
                employee.FullName.SureName,
                Group = employee.Group.Name,
                Position = employee.Position.Name
            });

            dataGridViewEmployees.DataSource = query.ToList();
            dataGridViewEmployees.Columns[0].Visible = false;
        }

        public void LoadDataGridViewEmpoyees()
        {
            currentDataGridViewExportRow = 0;

            var query = _dbSetEmployees.Select(employee => new
            {
                employee.Id,
                employee.FullName.LastName,
                employee.FullName.FirstName,
                employee.FullName.SureName,
                Group = employee.Group.Name,
                Position = employee.Position.Name
            });

            dataGridViewEmployees.DataSource = query.ToList();

            for (var i = 0; i < dataGridViewEmployees.Columns.Count; i++)
            {
                dataGridViewExport.Columns.Add(dataGridViewEmployees.Columns[i].Name, dataGridViewEmployees.Columns[i].Name);
            }

            dataGridViewExport.Columns[0].Visible = false;
            dataGridViewEmployees.Columns[0].Visible = false;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Application.Workbooks.Add(Type.Missing);
            excelApp.Columns.ColumnWidth = 15;

            excelApp.Cells[1, 2] = string.Join(string.Empty, "Event - ", textBoxEventName.Text);
            excelApp.Cells[2, 1] = "№п/п";
            excelApp.Cells[2, 2] = "Last name";
            excelApp.Cells[2, 3] = "First name";
            excelApp.Cells[2, 4] = "Sure name";
            excelApp.Cells[2, 5] = "Group";
            excelApp.Cells[2, 6] = "Position";

            for (var i = 0; i < dataGridViewExport.ColumnCount; i++)
            {
                for (var j = 0; j < dataGridViewExport.RowCount; j++)
                {
                    excelApp.Cells[j + 3, i + 1] = (dataGridViewExport[i, j].Value).ToString();
                }
            }
            excelApp.Visible = true;
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.Rows.Count > 0 && dataGridViewEmployees.CurrentRow != null)
            {
                MoveRow();
            }
            else
            {
                MessageBox.Show("No row selected");
            }
        }

        private void buttonMoveAll_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.Rows.Count > 0)
            {
                MoveRow(true);
            }
            else
            {
                MessageBox.Show("No rows selected");
            }
        }

        private void MoveRow(bool all = false)
        {
            if (all)
            {
                for (var i = 0; i < dataGridViewEmployees.RowCount; i++)
                {
                    dataGridViewExport.Rows.Add(1);
                    for (var j = 0; j < dataGridViewExport.Columns.Count; j++)
                    {
                        dataGridViewExport.Rows[currentDataGridViewExportRow].Cells[j].Value =
                            dataGridViewEmployees.Rows[i].Cells[j].Value;
                    }
                    currentDataGridViewExportRow++;
                }
            }
            else
            {
                dataGridViewExport.Rows.Add(1);
                for (var i = 0; i < dataGridViewExport.Columns.Count; i++)
                {
                    dataGridViewExport.Rows[currentDataGridViewExportRow].Cells[i].Value =
                        dataGridViewEmployees.CurrentRow.Cells[i].Value;
                }
                currentDataGridViewExportRow++;
            }
            
        }

        private void dataGridViewEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                var query = _dbSetEmployees.Select(employee => new
                {
                    employee.Id,
                    employee.FullName.LastName,
                    employee.FullName.FirstName,
                    employee.FullName.SureName,
                    Group = employee.Group.Name,
                    Position = employee.Position.Name
                });
                
                switch (e.ColumnIndex)
                {
                    case (1):
                    {
                        query = query.OrderBy(x => x.FirstName);
                        break;
                    }
                    case (2):
                    {
                        query = query.OrderBy(x => x.LastName);
                        break;
                    }
                    case (3):
                    {
                        query = query.OrderBy(x => x.SureName);
                        break;
                    }
                    case (4):
                    {
                        query = query.OrderBy(x => x.Group);
                        break;
                    }
                    case (5):
                    {
                        query = query.OrderBy(x => x.Position);
                        break;
                    }
                }

                dataGridViewEmployees.DataSource = query.ToList();
                dataGridViewEmployees.Columns[0].Visible = false;
                return;
            }

            GetDetail();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var detail = new Detail(this);
            detail.ShowDialog();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            GetDetail();
        }

        private void GetDetail()
        {
            var employeeId = int.Parse(dataGridViewEmployees.CurrentRow.Cells[0].Value.ToString());

            _db = new EventPlanningContainer();
            _dbSetEmployees = _db.Set<Employee>();

            var employee = _dbSetEmployees.FirstOrDefault(x => x.Id == employeeId);
            if (employee != null)
            {
                var detail = new Detail(this, employee);
                detail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Unexpected error");
            }
        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var filename = openFileDialog1.FileName;
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Open(filename);


            var last = excelApp.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

            excelApp.Columns.ColumnWidth = 15;

            for (var i = 0; i < dataGridViewExport.ColumnCount; i++)
            {
                for (var j = 0; j < dataGridViewExport.RowCount; j++)
                {
                    excelApp.Cells[j + last.Row + 1, i + 1] = (dataGridViewExport[i, j].Value).ToString();
                }
            }

            excelApp.Visible = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewExport.CurrentRow != null)
            {
                dataGridViewExport.Rows.Remove(dataGridViewExport.CurrentRow);
                currentDataGridViewExportRow--;
            }
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            if (dataGridViewExport.RowCount <= 0)
            {
                return;
            }

            var count = dataGridViewExport.RowCount;
            for (var i = 0; i < count; i++)
            {
                dataGridViewExport.Rows.Remove(dataGridViewExport.CurrentRow);
                currentDataGridViewExportRow--;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridViewMain();
        }

        private void comboBoxGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            var query = _dbSetEmployees.Select(employee => new
            {
                employee.Id,
                employee.FullName.LastName,
                employee.FullName.FirstName,
                employee.FullName.SureName,
                Group = employee.Group.Name,
                Position = employee.Position.Name
            });

            dataGridViewEmployees.DataSource = query.Where(x => x.Group == comboBoxGroup.Text).ToList();
            dataGridViewEmployees.Columns[0].Visible = false;
        }

        private void comboBoxPosition_SelectedValueChanged(object sender, EventArgs e)
        {
            var query = _dbSetEmployees.Select(employee => new
            {
                employee.Id,
                employee.FullName.LastName,
                employee.FullName.FirstName,
                employee.FullName.SureName,
                Group = employee.Group.Name,
                Position = employee.Position.Name
            });

            dataGridViewEmployees.DataSource = query.Where(x => x.Position == comboBoxPosition.Text).ToList();
            dataGridViewEmployees.Columns[0].Visible = false;
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "Word Documents (*.docx)|*.docx",
                FileName = "export.docx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportDataToWord(dataGridViewExport, sfd.FileName);
            }
        }

        public void ExportDataToWord(DataGridView dgv, string filename)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }

            var rowCount = dgv.Rows.Count;
            var columnCount = dgv.Columns.Count;
            var dataArray = new object[rowCount + 1, columnCount + 1];
            
            dataArray[0, 0] = "№";
            dataArray[0, 1] = "First name";
            dataArray[0, 2] = "First name";
            dataArray[0, 3] = "Sure name";
            dataArray[0, 4] = "Group";
            dataArray[0, 5] = "Position";

            for (var c = 0; c < columnCount; c++)
            {
                for (var r = 0; r < rowCount; r++)
                {
                    dataArray[r+1, c] = dgv.Rows[r].Cells[c].Value;
                } 
            } 

            var oDoc = new Word.Document();
            oDoc.Application.Visible = true;
            
            dynamic _oRange = oDoc.Content.Application.Selection.FormattedText;
            _oRange.Text = string.Join(string.Empty, "Event - ", textBoxEventName.Text, "\n");

            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            dynamic oRange = oDoc.Content.Application.Selection.Range;

            var oTemp = "";
            for (var r = 0; r < rowCount + 1; r++)
            {
                for (var c = 0; c < columnCount; c++)
                {
                    oTemp = oTemp + dataArray[r, c] + "\t";

                }
            }

            oRange.Text = oTemp;

            var separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
            object applyBorders = true;
            object autoFit = true;
            object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

            oRange.ConvertToTable(ref separator, ref rowCount, ref columnCount,
                Type.Missing, Type.Missing, ref applyBorders,
                Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, ref autoFit, ref autoFitBehavior, Type.Missing);

            oRange.Select();
        }
    }
}
