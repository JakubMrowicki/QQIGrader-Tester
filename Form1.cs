using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Text;

namespace QQIGrader
{
    public partial class frmMain : Form
    {
        List<TestCases> testCases;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.ReadAllLines(ofd.FileName).First().Length > 0)
                    {
                        try
                        {
                            testCases = File.ReadAllLines(ofd.FileName).Skip(1).Select(x => TestCases.FromCsv(x)).ToList();
                            runTests();
                        }
                        catch
                        {
                            MessageBox.Show("Error opening this file.", "Info");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your csv file is empty.", "Info");
                    }
                } catch
                {
                    MessageBox.Show("Your csv file may be open in another program.", "Info");
                }
            } 
            else return;
        }

        private void runTests()
        {
            int passes = 0;
            if (this.dataResults.Rows.Count > 0) this.dataResults.Rows.Clear();
            for (int i = 0; i < testCases.Count; i++)
            {
                bool testResult = testCases[i].Expected == getGrade(testCases[i].Input);
                if (testResult) passes++;
                this.dataResults.Rows.Add($"{(i + 1)}", $"{testCases[i].Input}", $"{testCases[i].Expected}", getGrade(testCases[i].Input), $"{(testResult ? "Pass" : "Fail")}");
                this.dataResults.Rows[i].DefaultCellStyle.BackColor = testResult ? Color.Green : Color.Red;
            }

            txtRes.Text = $"{passes}/{testCases.Count}";
            lblResult.Text = (passes == testCases.Count) ? "All Test Passed!" : "Some tests failed, see results below.";
        }

        private string getGrade(int grade)
        {
            switch (grade)
            {
                case >= 80:
                    {
                        return grade > 100 ? "Invalid" : "Distincton";
                    }
                case >= 65:
                    {
                        return "Merit";
                    }
                case > 50:
                    {
                        return "Pass";
                    }
                default:
                    {
                        return grade < 0 ? "Invalid" : "Unsuccesful";
                    }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataResults.Rows.Count > 0)
            {
                SaveFileDialog sfd = new();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the file to disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataResults.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataResults.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataResults.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dataResults.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataResults.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCsv);
                            MessageBox.Show("Data Exported Successfully.", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nothing to export.", "Info");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public class TestCases
    {
        public int Input;
        public string Expected;

        public static TestCases FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            TestCases testCases = new()
            {
                Input = int.Parse(values[1]),
                Expected = values[2]
            };
            return testCases;
        }
    }
}