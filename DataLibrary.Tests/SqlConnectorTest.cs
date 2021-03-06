// <copyright file="SqlConnectorTest.cs">Copyright ©  2018</copyright>
using System;
using System.Data;
using System.Data.SqlClient;
using DataLibrary.DataAccess;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataLibrary.DataAccess.Tests
{
    /// <summary>Esta clase contiene pruebas unitarias parametrizadas para SqlConnector</summary>
    [PexClass(typeof(SqlConnector))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public class SqlConnectorTest
    {
        /// <summary>Código auxiliar de prueba para GetTable(SqlCommand, Int32&amp;)</summary>
        [PexMethod]
        [TestMethod]
        public DataTable GetTableTest()
        {
            SqlConnector.SetBuilder("Server=tcp:juanserverxd.database.windows.net,1433;Initial Catalog=myDBxd;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            SqlCommand cmd = new SqlCommand
            {
                CommandText = $"SELECT * FROM Hogares"
            };
            //cmd.Parameters.AddWithValue("@nombreProfesor", );

            var t = SqlConnector.GetTable(cmd, out var r);

            SqlConnector.PrintTable(t);

            return t;

        }
    }
}
