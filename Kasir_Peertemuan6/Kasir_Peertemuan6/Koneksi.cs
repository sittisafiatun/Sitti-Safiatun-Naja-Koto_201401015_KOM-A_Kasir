/*
 * Created by SharpDevelop.
 * User: ASUS
 * Date: 4/19/2022
 * Time: 3:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Kasir_Peertemuan6
{
	/// <summary>
	/// Description of Koneksi.
	/// </summary>
	public class Koneksi
	{
		public SqlConnection GetConn(){
			SqlConnection Conn = new SqlConnection();
			Conn.ConnectionString = "Data Source=DESKTOP-15TBTTA; initial catalog=Kasir1; integrated security=true";
			return Conn;
		}
		
	}
}
