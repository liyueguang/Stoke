using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Stoke.USL.filetosql
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            string filename = Request["filename"];
            if (id != null && id != string.Empty && filename != null && filename != string.Empty)
            {
                string pattern = @"^[1-9]\d*$";
                Regex reg = new Regex(pattern);
                if (reg.IsMatch(id))
                {
                    string filename_wyw = "";
                    DataTable dt = Stoke.Components.Staff.GetFileName(int.Parse(id));
                    filename_wyw = dt.Rows[0][0].ToString();
                    int PictureCol = 0;  // position of Picture column in DataReader
                    int BUFFER_LENGTH = 32768; // chunk size
                    string connStr = DAL.SQLHelper.CONN_STRING;
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Select count(CategoryID) from Categories where CategoryID=" + id;
                        conn.Open();
                        if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                        {
                            //Make sure Photo is non-NULL and return TEXTPTR to it.
                            cmd.CommandText = "SELECT @Pointer=TEXTPTR(Picture), @Length=DataLength(Picture) FROM Categories WHERE CategoryID=" + id;
                            SqlParameter PointerOutParam = cmd.Parameters.Add("@Pointer", SqlDbType.VarBinary, 100);
                            PointerOutParam.Direction = ParameterDirection.Output;
                            SqlParameter LengthOutParam = cmd.Parameters.Add("@Length", SqlDbType.Int);
                            LengthOutParam.Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            if (PointerOutParam.Value != null)
                            {
                                // Set up READTEXT command, parameters, and open BinaryReader.
                                SqlCommand cmdReadBinary = new SqlCommand("READTEXT Categories.Picture @Pointer @Offset @Size HOLDLOCK", conn);
                                SqlParameter PointerParam = cmdReadBinary.Parameters.Add("@Pointer", SqlDbType.Binary, 16);
                                SqlParameter OffsetParam = cmdReadBinary.Parameters.Add("@Offset", SqlDbType.Int);
                                SqlParameter SizeParam = cmdReadBinary.Parameters.Add("@Size", SqlDbType.Int);
                                SqlDataReader dr;

                                Response.Clear();
                                long dataToRead = Convert.ToInt32(LengthOutParam.Value);
                                long p = 0;
                                filename = FileToMSSQL.Util.DecryptFilename(filename);
                                if (Request.Headers["Range"] != null)
                                {
                                    Response.StatusCode = 206;
                                    p = long.Parse(Request.Headers["Range"].Replace("bytes=", "").Replace("-", ""));
                                }
                                if (p != 0)
                                {
                                    Response.AddHeader("Content-Range", "bytes " + p.ToString() + "-" + ((long)(dataToRead - 1)).ToString() + "/" + dataToRead.ToString());
                                }
                                filename_wyw = filename_wyw.Substring(filename_wyw.LastIndexOf("."));
                                filename_wyw = "Stoke_Document_" + System.DateTime.Now.ToString("yyyy") + "_" + System.DateTime.Now.ToString("MM") + "_" + System.DateTime.Now.ToString("dd") + "_" + System.DateTime.Now.ToString("hh") + System.DateTime.Now.ToString("mm") + System.DateTime.Now.ToString("ss") + filename_wyw;
                                Response.AddHeader("Content-Length", ((long)(dataToRead - p)).ToString());
                                Response.ContentType = "application/octet-stream";
                                //								Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(System.Text.Encoding.GetEncoding(65001).GetBytes(filename)));
                                Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(System.Text.Encoding.UTF8.GetBytes(filename_wyw)));

                                long Offset = p;
                                OffsetParam.Value = Offset;
                                Byte[] Buffer = new Byte[BUFFER_LENGTH];

                                // Read buffer full of data and write to the file stream.

                                do
                                {
                                    if (Response.IsClientConnected)
                                    {
                                        PointerParam.Value = PointerOutParam.Value;

                                        // Calculate buffer size - may be less than BUFFER_LENGTH for last block.

                                        if ((Offset + BUFFER_LENGTH) >= System.Convert.ToInt32(LengthOutParam.Value))
                                            SizeParam.Value = System.Convert.ToInt32(LengthOutParam.Value) - Offset;
                                        else SizeParam.Value = BUFFER_LENGTH;

                                        dr = cmdReadBinary.ExecuteReader(CommandBehavior.SingleResult);
                                        dr.Read();
                                        dr.GetBytes(PictureCol, 0, Buffer, 0, System.Convert.ToInt32(SizeParam.Value));
                                        dr.Close();
                                        Response.OutputStream.Write(Buffer, 0, Buffer.Length);
                                        Response.Flush();
                                        Offset += System.Convert.ToInt32(SizeParam.Value);
                                        OffsetParam.Value = Offset;
                                    }
                                    else
                                    {
                                        Offset = dataToRead;
                                    }
                                } while (Offset < System.Convert.ToInt32(LengthOutParam.Value));
                                cmdReadBinary.Dispose();
                                Response.End();
                            }
                            else
                            {
                                Response.Write("Error: Photo field is null.");
                            }
                        }
                        else
                        {
                            Response.Write("Error: File doesn't exist.");
                        }
                    }
                    finally
                    {
                        if (cmd != null)
                            cmd.Dispose();
                        if (conn != null && conn.State != ConnectionState.Closed)
                            conn.Close();
                        if (conn != null)
                            conn.Dispose();
                    }
                }
                else
                {
                    Response.Write("Error: Unvalid parameter");
                }
            }
            else
            {
                Response.Write("Error: Unvalid parameter");
            }
        }
    }
}
