﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;

public partial class PltDataTrans : System.Web.UI.Page
{
    string Sql_str, v_getValue;
    static string connStr = "jh815";
    //static string connStr = "JHERPDB";
    thomas_Conn tsconn = new thomas_Conn();
    thomas_function ts_Fun = new thomas_function();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ts_Fun.chk_verify())
        {
            //Server.Transfer("error.htm");
            Response.Redirect("error2.aspx", false);
        }

        try
        {
            string pv_job_no = "";     //流程卡號
            string pv_location = "";   //儲區
            string pd_proc_date = "";  //領用日期
            string pv_proc_emp = "";   //領用人員

            if ((Request.Params["pv_job_no"] != null) & (Request.Params["pv_location"] != null) &
                (Request.Params["pd_proc_date"] != null) & (Request.Params["pv_proc_emp"] != null))
            {
                pv_job_no = Request.Params["pv_job_no"].ToString();
                pv_location = Request.Params["pv_location"].ToString();
                pd_proc_date = Request.Params["pd_proc_date"].ToString();
                pv_proc_emp = Request.Params["pv_proc_emp"].ToString();
                Call_SP_PltScan(pv_job_no, pv_location, pd_proc_date, pv_proc_emp);

            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }

    protected void Call_SP_PltScan(string pv_job_no, string pv_location, string pd_proc_date, string pv_proc_emp)
    {

        using (OracleConnection objConn = new OracleConnection(
               ConfigurationManager.ConnectionStrings[connStr].ConnectionString))
        {

            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = objConn;
            objCmd.CommandText = "SP_PLT_SCAN";
            //objCmd.CommandText = "SP_WIPINV_SCAN";
            objCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                objCmd.Parameters.Add("pv_barcode1", OracleType.VarChar).Value = pv_job_no;        //流程卡號
                objCmd.Parameters.Add("pv_loc", OracleType.VarChar).Value = pv_location;    //儲區
                objCmd.Parameters.Add("pv_param", OracleType.VarChar).Value = "PDA";    //儲區
                objCmd.Parameters.Add("pd_proc_date", OracleType.DateTime).Value = DateTime.ParseExact(pd_proc_date, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces); //領用日期
                objCmd.Parameters.Add("pv_proc_emp", OracleType.VarChar).Value = pv_proc_emp;   //領用人員

                objCmd.Parameters.Add("pv_err_msg", OracleType.VarChar, 255).Direction = ParameterDirection.Output;


                objConn.Open();
                objCmd.ExecuteNonQuery();

                //v_getValue = (string)objCmd.Parameters["pv_err_msg"].Value;
                //Response.Write("Success," + pv_job_no + "," + pv_coil_no + "," + pd_proc_date + "," + pv_proc_emp );

                if (objCmd.Parameters["pv_err_msg"].Value is DBNull)
                {
                    Response.Write("Success");
                }
                else
                {
                    Response.Write(objCmd.Parameters["pv_err_msg"].Value);
                }
            }
            catch (Exception ex)
            {
                objCmd.Dispose();
                objConn.Dispose();
                objConn.Close();
                //err_mess4.Text = "發生異常：" + ex.ToString();
                Response.Write(ex.ToString());
            }
            finally
            {
                objCmd.Dispose();
                objConn.Dispose();
                objConn.Close();
            }
        }
    }
}