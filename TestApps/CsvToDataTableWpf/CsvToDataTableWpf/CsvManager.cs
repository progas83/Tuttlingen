using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace CsvToDataTableWpf
{
    public class CsvManager
    {
        private string csvPath = @"C:\Ilya\NavisionCVS\dbo.top10.xls";
        private char _splitChar = ';';
        public void ReadScv(string filePath, char delimeter)
        {
            using (var sr = new StreamReader(filePath))
            {
                DataTable dt = new DataTable();

                int rowCount = 0;
                string[] columnNames = null;
                string[] dataValues = null;

                while (!sr.EndOfStream)
                {
                    string rowData = sr.ReadLine().Trim();
                    if (rowData.Length > 0)
                    {
                        dataValues = rowData.Split(_splitChar);
                        if (rowCount == 0)
                        {
                            rowCount = 1;
                            columnNames = dataValues;
                            foreach (string csvHeader in columnNames)
                            {
                                DataColumn dataColumn = new DataColumn(csvHeader);
                                dataColumn.DefaultValue = string.Empty;
                                dt.Columns.Add(dataColumn);
                            }
                        }
                    }
                    else
                    {// full shit!!!!
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < columnNames.Length; i++)
                        {
                            dr[columnNames[i]] = dataValues[i] == null ? string.Empty : dataValues[i].ToString();

                        }

                        dt.Rows.Add(dr);
                    }

                }

            }


        }

    }
}
