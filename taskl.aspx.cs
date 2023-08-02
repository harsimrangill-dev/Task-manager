using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class taskl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = string.Empty;
        if (!IsPostBack)
        {
            crt();
        }
    }

    private bool isexist(string name, string source)
    {
        SqlConnection conn = new SqlConnection(source);
        conn.Open();
        DataTable dt = conn.GetSchema("TABLES", new string [] {null, null, name });
        conn.Close();
        return dt.Rows.Count> 0;
    }

    private void crt()
    {
        
        string cont = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Computing\source\repos\WebSite1\App_Data\Database.mdf;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(cont);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rdr;

        try
        {
            string create_tbl = "CREATE TABLE task (task varchar(255), progress varchar(255))";
            string update = "ALTER TABLE task DROP COLUMN id; ALTER TABLE task ADD  id  INT IDENTITY(1,1)";
            //update = "UPDATE task SET id= INT IDENTITY(1,1)";
            string gets = "SELECT  * FROM task";
            int val = 0;
            cmd.Connection= con;
            int add;
            con.Open();
            if (isexist("task", cont))
            {
                //

            }
            else
            {
                val++;
                cmd.CommandText = create_tbl;
                add = cmd.ExecuteNonQuery();
            }
            cmd.CommandText = update;
            cmd.ExecuteNonQuery();
            cmd.CommandText = gets;
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                

                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2= new TableCell();
                TableCell cell3 = new TableCell();
                cell1.Text = rdr[3].ToString();
                cell2.Text = rdr[1].ToString();
                cell3.Text= rdr[2].ToString();
                row.Controls.Add(cell1);
                row.Controls.Add(cell2);
                row.Controls.Add(cell3);
                tbl.Controls.Add(row);
            }

        }
        catch
        {
            lbl.Text = "Sorry the excution had not done";
        }

        finally
        {
            con.Close();
            
        }
    }

    protected void delt(object o, EventArgs e)
    {
        string cont = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Computing\source\repos\WebSite1\App_Data\Database.mdf;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(cont);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        int attemt = 0;
        try
        {
            string command = "DELETE FROM task WHERE id=@num";
            cmd.CommandText = command;
            cmd.Parameters.AddWithValue("@num", deltask.Text);
            con.Open();
            attemt = cmd.ExecuteNonQuery();
        }
        catch
        {
            lbl.Text = "Command is not exceuted";
        }
        finally { con.Close(); }

        crt();
        
    }

    protected void adds(object o, EventArgs e)
    {
        string cont = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Computing\source\repos\WebSite1\App_Data\Database.mdf;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(cont);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        int attemt = 0;
        try

        {

            string command = "INSERT INTO task(task,progress) VALUES(@tsk,@prg)";
            cmd.CommandText = command;
            cmd.Parameters.AddWithValue("@tsk", taskinput.Text);
            cmd.Parameters.AddWithValue("@prg",  "Not Done");
            con.Open();
            attemt = cmd.ExecuteNonQuery();
        }
        catch
        {
            lbl.Text = "Command is not exceuted";
        }
        finally { con.Close(); }


            crt();

    }

    protected void updte(object o, EventArgs e)
    {
        string cont = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Computing\source\repos\WebSite1\App_Data\Database.mdf;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(cont);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        int attemt = 0;
        try
        {
            string command = "UPDATE task SET progress=@prg WHERE  id=@num";
            cmd.CommandText = command;
            cmd.Parameters.AddWithValue("@num", Update.Text);
            cmd.Parameters.AddWithValue("@prg", "Done");
            con.Open();
            attemt = cmd.ExecuteNonQuery();
        }
        catch
        {
            lbl.Text = "Command is not exceuted";
        }
        finally { con.Close(); }


            crt();

    }

}