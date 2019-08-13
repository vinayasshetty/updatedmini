using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace studentlib
{
    public class Adoconnected
    {
        SqlConnection con;
        SqlCommand cmd;
        public Adoconnected()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost;Initial Catalog=studentresultmanagement;Integrated Security=True";
            //read connection string from config file
            //string constr = ConfigurationManager.ConnectionStrings["sqlconstr"].ConnectionString;
            //con.ConnectionString = con;
            cmd = new SqlCommand();
            cmd.Connection = con;
        }


        public string verifyLogin(string username,string password)
        {
            try {
            con.Open();
            cmd.CommandText = "select * from admin where username=@un and password=@ps";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@un", username);
            cmd.Parameters.AddWithValue("@ps", password);
            SqlDataReader row = cmd.ExecuteReader();
            if(row!=null)
            {
                return row[1].ToString();

            }
            else
            {
                return "failure";
            }
            }
            catch(DllNotFoundException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
           


        }
        //public List<student> SelectAllstudents()
        //{
        //    try
        //    {
        //        List<student> stdLst = new List<student>();
        //        //configure command for select all stmt
        //        cmd.CommandText = "select * from student";
        //        cmd.CommandType = CommandType.Text;
        //        //open connection
        //        con.Open();
        //        //Execute command
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            //retrieve the current record values
        //            student std = new student();
        //            std.usn = (string)sdr[0];
        //            std.name = (string)sdr[1];
        //            std.email = (string)sdr[2];
        //            std.address = (string)sdr[3];
        //            std.semester = (int)sdr[4];
        //            //add the record to collection
        //            stdLst.Add(std);
        //        }

        //        sdr.Close();
        //        return stdLst;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (InvalidCastException ex)
        //    {
        //        throw ex;
        //    }
        //    finally { 
        //    con.Close();
        //    }
        //}
        public List<student> SelectAllstudents(int semester)
        {
            try
            {
                List<student> stdLst = new List<student>();
                //configure command for select all stmt
                cmd.CommandText = "select * from student where semester=" + semester;
                cmd.CommandType = CommandType.Text;
                //open connection
                con.Open();
                //Execute command
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    //retrieve the current record values
                    student std = new student();
                    std.usn = (string)sdr[0];
                    std.name = (string)sdr[1];
                    std.email = (string)sdr[2];
                    std.address = (string)sdr[3];
                    std.semester = (int)sdr[4];
                    //add the record to collection
                    stdLst.Add(std);
                }

                sdr.Close();
                return stdLst;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        //public subject selectsubid(string branchid,int semester)
        public List<string> selectsubid(string branchid, int semester)
        {
            try
            {

                //subject sb = new subject();
                List<string> slt = new List<string>();
                cmd.CommandText = "select subjectid from subject where branchid='"+ branchid + "' and semester ="+ semester;
                //cmd.CommandText = "select subjectid from subject where semester=" + semester;
                //cmd.CommandText = "select subjectid from subject where branchid="+ branchid;
                cmd.CommandType = CommandType.Text;
                string subjectid;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    subjectid= (string)(sdr[0]);
                    slt.Add(subjectid);
                   
                }

                return slt;
                sdr.Close();
            }
         

            finally { 
            con.Close();
            }
        }
        public List<score> searchscore(string usn)
        {
            try
            {
                List<score> score = new List<score>();
                cmd.CommandText = "select * from score where usn='" + usn + "'";
                //cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@usn", usn);
                cmd.CommandType = CommandType.Text;
                
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    score sc = new score();
                    sc.usn = (string)sdr[0];
                    sc.subjectid = (string)sdr[1];
                    sc.marks = (int)sdr[2];
                    sc.grade = (string)sdr[3];
                    score.Add(sc);

                }

                return score;
                sdr.Close();
            }


            finally
            {
                con.Close();
            }
        }
        public void Insertscore(insertscore sc)
        {
            try
            {//configure command for insert statement
             //insert into tbl
             
                cmd.CommandText = "insert into score values(@usn,@subid1,@marks1,@grade1)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usn", sc.usn);
                cmd.Parameters.AddWithValue("@subid1", sc.subjectid1);
                cmd.Parameters.AddWithValue("@marks1", sc.marks1);
                cmd.Parameters.AddWithValue("@grade1", sc.grade1);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into score values(@usn,@subid2,@marks2,@grade2)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usn", sc.usn);
                cmd.Parameters.AddWithValue("@subid2", sc.subjectid2);
                cmd.Parameters.AddWithValue("@marks2", sc.marks2);
                cmd.Parameters.AddWithValue("@grade2", sc.grade2);
                
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into score values(@usn,@subid3,@marks3,@grade3)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usn", sc.usn);
                cmd.Parameters.AddWithValue("@subid3", sc.subjectid3);
                cmd.Parameters.AddWithValue("@marks3", sc.marks3);
                cmd.Parameters.AddWithValue("@grade3", sc.grade3);
               
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into score values(@usn,@subid4,@marks4,@grade4)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usn", sc.usn);
                cmd.Parameters.AddWithValue("@subid4", sc.subjectid4);
                cmd.Parameters.AddWithValue("@marks4", sc.marks4);
                cmd.Parameters.AddWithValue("@grade4", sc.grade4);
                
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into score values(@usn,@subid5,@marks5,@grade5)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usn", sc.usn);
                cmd.Parameters.AddWithValue("@subid5", sc.subjectid5);
                cmd.Parameters.AddWithValue("@marks5", sc.marks5);
                cmd.Parameters.AddWithValue("@grade5", sc.grade5);
                
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into score values(@usn,@subid6,@marks6,@grade6)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usn", sc.usn);
                cmd.Parameters.AddWithValue("@subid6", sc.subjectid6);
                cmd.Parameters.AddWithValue("@marks6", sc.marks6);
                cmd.Parameters.AddWithValue("@grade6", sc.grade6);
               
                cmd.ExecuteNonQuery();
            }
            catch(NullReferenceException ex)
            {
                throw ex;
            }
            finally { 
            //close connection
            con.Close();
            }
        }
        public void Updatscore(string usn, int marks)
        {
            try
            {
                cmd.CommandText = "update marks set marks=@ma where usn="+usn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usn", usn);
                cmd.Parameters.AddWithValue("@ma", marks);
                con.Open();
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("ecode does not exist");
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
            con.Close();
            }
        }
        public score displayscore(string usn,int semester)
        {
            try
            {
                score s = new score();
                cmd.CommandText= "select * from score  where usn=" + usn + " and semester =" + semester;
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    s.usn = (string)(sdr[0]);
                    s.subjectid = (string)(sdr[0]);
                    s.marks = (int)(sdr[0]);
                    s.grade = (string)(sdr[0]);

                }
                return s;
                sdr.Close();

            }
           
            finally
            {
                con.Close();
            }
        }

    }
    
}
