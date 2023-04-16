using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _003_DisconnectedLayer
{
    public partial class Form1 : Form
    {
        private string _dPName;
        private string _connectionString;



        private DbProviderFactory _dbProviderFactory;
        private DbConnection _dbConnection;
        private DbDataAdapter _dataAdapter;

        private DataTable _dataTable;
        private DataSet _dataSet;

        public Form1()
        {
            InitializeComponent();

            _dPName = ConfigurationManager.AppSettings["SQLProvider"];
            _connectionString = ConfigurationManager.ConnectionStrings["SqlProvider"].ConnectionString;

            _dbProviderFactory = DbProviderFactories.GetFactory(_dPName);

            _dbConnection = _dbProviderFactory.CreateConnection();
            _dbConnection.ConnectionString = _connectionString;

            _dataAdapter = _dbProviderFactory.CreateDataAdapter();

            _dataSet = new DataSet();

            GetTableNameIntoCombobox();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            try
            {
                string query = textBox_Query.Text;
                if(query.Length < 12)
                {
                    throw new Exception("Введите тело запроса");
                    return;
                }
                _dataTable = new DataTable();

                DbCommand dbCommand = _dbProviderFactory.CreateCommand();
                dbCommand.Connection = _dbConnection;
                dbCommand.CommandText = query;
                _dbConnection.Open();

                DbDataReader dbDataReader = dbCommand.ExecuteReader();

                //Формируем DataTable------------------------------------------------start
                int lineIndex = 0; 
                do
                {
                    while (dbDataReader.Read())
                    {
                        if(lineIndex == 0)          //выгружаю шапку таблицы
                        {
                            for (int i = 0; i < dbDataReader.FieldCount; i++)
                            {
                                _dataTable.Columns.Add(dbDataReader.GetName(i));
                            }
                            lineIndex++;
                        }
                        DataRow dataRow = _dataTable.NewRow();
                        for (int i = 0; i < dbDataReader.FieldCount; i++)
                        {
                            dataRow[i] = dbDataReader[i];
                        }
                        _dataTable.Rows.Add(dataRow);
                    }

                } while (dbDataReader.NextResult());
                //Формируем DataTable------------------------------------------------end
                dataGridView_Results.DataSource = _dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        private void button_ExecDataSet_Click(object sender, EventArgs e)
        {
            try
            {
                string query = textBox_Query.Text;
                if (query.Length < 12)
                {
                    throw new Exception("Введите тело запроса");
                    return;
                }
                _dataSet.Clear();
                DbCommand dbCommand = _dbProviderFactory.CreateCommand();
                dbCommand.Connection = _dbConnection;
                dbCommand.CommandText = query;

                _dataAdapter.SelectCommand = dbCommand;

                //_dataAdapter.SelectCommand
                //_dataAdapter.InsertCommand
                //_dataAdapter.UpdateCommand
                //_dataAdapter.DeleteCommand
                _dataAdapter.Fill(_dataSet);

                dataGridView_Results.DataSource = _dataSet.Tables["users"];

                dataGridView_Results.DataSource = _dataSet.Tables[0];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dbConnection.Close();
            }
        }


        private void GetTableNameIntoCombobox()
        {
            DbCommand dbCommand = _dbProviderFactory.CreateCommand();
            dbCommand.Connection = _dbConnection;
            dbCommand.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES";

            _dbConnection.Open();
            DbDataReader dbDataReader;

            using (dbDataReader = dbCommand.ExecuteReader())
            {
                while (dbDataReader.Read())
                {
                    if(dbDataReader["TABLE_NAME"].ToString() != "sysdiagrams")
                        comboBox_selectDB.Items.Add(dbDataReader["TABLE_NAME"].ToString());
                }
            }
            _dbConnection.Close();
        }

        private void SelectFromTable(string tableName)
        {
            try
            {
                _dataTable = new DataTable();

                DbCommand dbCommand = _dbProviderFactory.CreateCommand();
                dbCommand.Connection = _dbConnection;
                dbCommand.CommandText = $"SELECT * FROM {tableName}";
                
                _dbConnection.Open();

                DbDataReader dbDataReader = dbCommand.ExecuteReader();

                //Формируем DataTable------------------------------------------------start
                int lineIndex = 0;
                do
                {
                    while (dbDataReader.Read())
                    {
                        if (lineIndex == 0)          //выгружаю шапку таблицы
                        {
                            for (int i = 0; i < dbDataReader.FieldCount; i++)
                            {
                                _dataTable.Columns.Add(dbDataReader.GetName(i));
                            }
                            lineIndex++;
                        }
                        DataRow dataRow = _dataTable.NewRow();
                        for (int i = 0; i < dbDataReader.FieldCount; i++)
                        {
                            dataRow[i] = dbDataReader[i];
                        }
                        _dataTable.Rows.Add(dataRow);
                    }

                } while (dbDataReader.NextResult());
                //Формируем DataTable------------------------------------------------end
                dataGridView_Results.DataSource = _dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dbConnection.Close();
            }
        }


        private void comboBox_selectDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectFromTable(comboBox_selectDB.SelectedItem.ToString());

        }
    }
}
