using Microsoft.VisualBasic.ApplicationServices;

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
            if (btnStart.Text != "Run Tests")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "CSV (*.csv)|*.csv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    testCases = File.ReadAllLines(ofd.FileName).Skip(1).Select(x => TestCases.FromCsv(x)).ToList();
                    lblResult.Text = "CSV loaded!";
                    btnStart.Text = "Run Tests";
                }
            }
            else
            {
                int passes = 0;
                this.dataResults.Rows.Clear();
                for (int i = 0; i < testCases.Count; i++)
                {
                    bool testResult = testCases[i].Expected == getGrade(testCases[i].Input);
                    if (testResult)
                    {
                        passes++;
                        txtRes.Text = $"{passes}/{testCases.Count}";
                    }
                    this.dataResults.Rows.Add($"{(i + 1)}", $"{testCases[i].Input}", $"{testCases[i].Expected}", getGrade(testCases[i].Input), $"{testResult.ToString()}");
                }

                if (passes == testCases.Count)
                {
                    lblResult.Text = "All Test Passed!";
                }
                else
                {
                    lblResult.Text = "Some tests failed, see results below.";
                }
            }
        }

        private string getGrade(int grade)
        {
            switch (grade)
            {
                case >= 80:
                    {
                        if (grade > 100) return "Invalid";
                        return "Distinction";
                    }
                case >= 65:
                    {
                        return "Merit";
                    }
                case >= 50:
                    {
                        return "Pass";
                    }
                default:
                    {
                        if (grade < 0) return "Invalid";
                        return "Unsuccessful";
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
    }

    public class TestCases
    {
        public int TestID;
        public int Input;
        public string Expected;

        public static TestCases FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            TestCases testCases = new()
            {
                TestID = int.Parse(values[0]),
                Input = int.Parse(values[1]),
                Expected = values[2]
            };
            return testCases;
        }
    }
}