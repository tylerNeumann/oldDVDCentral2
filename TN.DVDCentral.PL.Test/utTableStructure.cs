﻿namespace TN.DVDCentral.PL2.Test
{
    public enum DataTypes
    {
        String = 0,
        Double,
        Int32,
        Guid,
        DateTime
    }

    [TestClass]
    public class utTableStructure
    {

        private bool CheckColumnDefinition(Type tableType,
                                          string columnName,
                                          DataTypes dataType,
                                          ref string message,
                                          ref string errmessage)
        {
            try
            {

                if (tableType.GetProperty(columnName) != null)
                {
                    var property = tableType.GetProperty(columnName);
                    if (property.PropertyType.Name.Equals(dataType.ToString()))
                    {
                        message += "Passed: " + tableType.Name + "." + columnName + " (" + dataType.ToString() + ")\r\n";
                        return true;
                    }
                    else
                    {
                        errmessage += "Failed: Data Type: "
                                    + tableType.Name
                                    + "." + columnName
                                    + " (" + property.PropertyType.Name
                                    + " is not "
                                    + dataType.ToString()
                                    + ")\r\n";

                        message += "Failed: Data Type: "
                                    + tableType.Name
                                    + "." + columnName
                                    + " (" + property.PropertyType.Name
                                    + " is not "
                                    + dataType.ToString()
                                    + ")\r\n";

                        return false;
                    }
                }
                else
                {
                    errmessage += "Failed: " + tableType.Name + "." + columnName + " does not exist.\r\n";
                    message += "Failed: " + tableType.Name + "." + columnName + " does not exist.\r\n";
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                errmessage += "Failed: " + tableType.Name + "." + columnName + " does not exist.\r\n";
                message += "Failed: " + tableType.Name + "." + columnName + " does not exist.\r\n";
                return false;
            }

        }

        public class ColumnInfo
        {
            public string Name { get; set; }
            public DataTypes DataType { get; set; }
            public string DataTypeDesc { get; set; }
            public ColumnInfo(string name, DataTypes dataType)
            {
                Name = name;
                DataType = dataType;
                DataTypeDesc = dataType.ToString();


            }
            public void setDataType(DataTypes dataType)
            {
                DataType = dataType;
            }

        }
        private class Structure
        {
            public string TableName { get; set; }
            //public Type Type { get; set; }
            public string Type { get; set; }

            public List<ColumnInfo> ColumnInfos { get; set; }
        }

        [TestMethod]
        public void CheckTableStructure()
        {
            string message = "Results:\r\n";
            string errMessage = "Errors:\r\n";
            bool rowsAffected = true;
            List<Structure> structures = new List<Structure>();

            structures = ReadStructures();

            foreach (Structure structure1 in structures)
            {
                Type myType = typeof(utTableStructure);
                string[] namespaceNames = myType.Namespace.ToString().Split(".");
                string namespaceName = namespaceNames[0] + "." + namespaceNames[1] + "." + namespaceNames[2]; // + ".Entities";

                string tableTypeName = structure1.Type.Replace("BDF", namespaceNames[0]).Split(",")[0];

                Type tableType = Type.GetType(tableTypeName + ", " + namespaceName);
                if (tableType == null)
                    tableType = Type.GetType(tableTypeName + ", " + namespaceName);

                foreach (ColumnInfo column in structure1.ColumnInfos)
                {

                    rowsAffected = CheckColumnDefinition(tableType,
                                                    column.Name,
                                                    column.DataType,
                                                    ref message,
                                                    ref errMessage) ? rowsAffected : false;
                }
            }


            Debug.WriteLine(message);
            //TestContext.Out.WriteLine(message);
            Assert.IsTrue(rowsAffected, errMessage);

        }

        private static List<Structure> ReadStructures()
        {
            List<Structure> structures = new List<Structure>();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://fvtcdp.azurewebsites.net/api/");
                HttpResponseMessage response = client.GetAsync("TableStructure/DVDCentralV2").Result;
                string rowsAffected = response.Content.ReadAsStringAsync().Result;
                structures = JsonConvert.DeserializeObject<List<Structure>>(rowsAffected);
                //TestContext.Out.WriteLine(structures.Count + " structures found.");
                Debug.WriteLine(structures.Count + " structures found.");
            }
            catch (Exception)
            {
                //TestContext.Out.WriteLine("structure.json not found.");
                Debug.WriteLine("structure.json not found.");
            }

            return structures;
        }

    }
}
