using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for DbAccess
/// </summary>
/// 

public class DbAccess
{
    private static string databaseconnection;
    private SqlConnection cnn;
    // sets the connection string on creation
    public DbAccess(string attendancedb)
    {
        databaseconnection = ConfigurationManager.ConnectionStrings[attendancedb].ConnectionString;
        cnn = new SqlConnection(databaseconnection);
    }
    private void OpenDatabase()
    {
        if (cnn.State.ToString() == "Open")
        {
            cnn.Close();

        }

        cnn.Open();

    }
    private void CloseDatabase()
    {

        cnn.Close();

    }

    /// <summary>
    /// pass me in a string and i will spit back a datatable
    /// </summary>

    /// <param name="strSQL">the sql string you want me to run</param>
    /// <returns> a datable</returns>
    //public DataTable BuildSql(string strSQL)
    //{
    // you use this to run sql strings from your code but we are doing nothing but stored procs

    //    OpenDatabase();

    //    DataTable dtResult = new DataTable();

    //    SqlCommand m_objCommand = new SqlCommand(strSQL, cnn);
    //    m_objCommand.CommandTimeout = 150;
    //    SqlDataAdapter objDataAdapter = new SqlDataAdapter(m_objCommand);

    //    objDataAdapter.Fill(dtResult);

    //    objDataAdapter.Dispose();

    //    m_objCommand.Dispose();

    //    CloseDatabase();

    //    return dtResult;

    //}
    /// <summary>
    /// pass me in a stored proc and get back a datatable
    /// </summary>
    /// <param name="procedurename"> stored proc name</param>
    /// <param name="parameters">sql parameter</param>
    /// <returns>datatable</returns>
    public DataTable BuildSql(string procedurename, SqlParameter[] parameters)
    {

        OpenDatabase();

        DataTable dtResult = new DataTable();
        // this time use the proc name as the first variable in
        SqlCommand m_objCommand = new SqlCommand(procedurename, cnn);

        // set the stored proc name
        // m_objCommand.CommandText = procedurename;
        // tell it it is going to be a stored proc
        m_objCommand.CommandType = CommandType.StoredProcedure;
        // add the parameters
        m_objCommand.Parameters.AddRange(parameters);


        m_objCommand.CommandTimeout = 150;
        SqlDataAdapter objDataAdapter = new SqlDataAdapter(m_objCommand);

        objDataAdapter.Fill(dtResult);

        objDataAdapter.Dispose();

        m_objCommand.Dispose();

        CloseDatabase();

        return dtResult;

    }
    /// <summary>
    /// pass me in a stored proc and get back a datatable
    /// </summary>
    /// <param name="procedurename"> stored proc name</param>
    /// <param name="parameters">sql parameter</param>
    /// <returns>datatable</returns>
    public DataTable BuildSql(string procedurename)
    {

        OpenDatabase();

        DataTable dtResult = new DataTable();
        // this time use the proc name as the first variable in
        SqlCommand m_objCommand = new SqlCommand(procedurename, cnn);

        // set the stored proc name
        // m_objCommand.CommandText = procedurename;
        // tell it it is going to be a stored proc
        m_objCommand.CommandType = CommandType.StoredProcedure;

        m_objCommand.CommandTimeout = 150;
        SqlDataAdapter objDataAdapter = new SqlDataAdapter(m_objCommand);

        objDataAdapter.Fill(dtResult);

        objDataAdapter.Dispose();

        m_objCommand.Dispose();

        CloseDatabase();

        return dtResult;

    }
    /// <summary>
    /// this will just run sql like insert or updates and not spit anything back
    /// </summary>
    /// <param name="SQl"></param>
    public void RunSql(string procedurename, SqlParameter[] parameters)
    {
        OpenDatabase();

        DataTable dtResult = new DataTable();
        // this time use the proc name as the first variable in
        SqlCommand m_objCommand = new SqlCommand(procedurename, cnn);

        // set the stored proc name
        // m_objCommand.CommandText = procedurename;
        // tell it it is going to be a stored proc
        m_objCommand.CommandType = CommandType.StoredProcedure;
        // add the parameters
        m_objCommand.Parameters.AddRange(parameters);

        m_objCommand.ExecuteNonQuery();

        CloseDatabase();

    }

}
