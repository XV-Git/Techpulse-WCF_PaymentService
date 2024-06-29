using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	SqlConnection con = new SqlConnection(@"Server=LOQ-JARVIS\SQLEXPRESS;Database=Vault;Integrated Security=true");
	public int GetBalance(int AccID)  // Sarat.V
    {
		string qry = "Select Account_Balance from AccountDetails where Account_ID=" +AccID;
		SqlCommand cmd = new SqlCommand(qry,con);
		if (con.State == ConnectionState.Open)
        {
			con.Close();
        }
		con.Open();
		int retval = Convert.ToInt32(cmd.ExecuteScalar());
		return retval;
    }




	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
