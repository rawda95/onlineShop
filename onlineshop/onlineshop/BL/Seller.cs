﻿using onlineshop.Dl;
using System;
using System.Data;
using System.Data.SqlClient;
namespace onlineshop.BL
{
    public class Seller
    {

        public static string getName(int id)
        {
            SqlCommand cmd = new SqlCommand("select frist_name  from users.Seller  where id =@id");
            cmd.Parameters.AddWithValue("@id", id);

            string name = DBLayer.select(cmd).Rows[0][0].ToString();
            return name;



        }
        //select
        public static DataTable getAll()
        {
            return DBLayer.select(new SqlCommand("select * from Users.Seller"));
        }


        //serch by id 
        public static DataTable getById(int id)
        {
            SqlCommand cmd = new SqlCommand("select *  from Users.Seller where id=@id");
            cmd.Parameters.AddWithValue("@id", id);
            return DBLayer.select(cmd);
        }


        //serch by name 
        public static DataTable getByName(string name)
        {
            SqlCommand cmd = new SqlCommand("select *  from Users.Seller where firts_name=@name");
            cmd.Parameters.AddWithValue("@name", name);
            return DBLayer.select(cmd);
        }


        // get id by email for reset password
        public static DataTable getByEmail(string email)
        {

            SqlCommand cmd = new SqlCommand("select id  from Users.Seller where email=@email");
            cmd.Parameters.AddWithValue("@email", email);
            return DBLayer.select(cmd);
        }



        //get seller shop 
        public static DataTable get_shop_ID(int seller_id)
        {
            SqlCommand cmd = new SqlCommand("select SS.* from Shop.Shop ss, Users.Seller us where ss.shop_owner = us.id and us.id = @seller_id ");
            cmd.Parameters.AddWithValue("@seller_id", seller_id);
            return DBLayer.select(cmd);

        }



        //get seller state 
        public static DataTable get_Seller_state(int id)
        {


            SqlCommand cmd = new SqlCommand("select s.Name from Users.Seller c, Users.User_state s where c.state = s.Id and c.id =@id ");
            cmd.Parameters.AddWithValue("@id", id);
            return DBLayer.select(cmd);
        }

        //get  id  from user id 
        public static DataTable get_id(int userid)
        {

            SqlCommand cmd = new SqlCommand("select id from Users.Seller where userid = @userid");
            cmd.Parameters.AddWithValue("@userid", userid);
            return DBLayer.select(cmd);
        }


        // get uersname unique
        public static DataTable get_username(int id)
        {
            SqlCommand cmd = new SqlCommand("select u.user_name from Users.Users u , Users.Seller c where u.Id = c.userid and  c.Id=@id ");
            cmd.Parameters.AddWithValue("@id", id);
            return DBLayer.select(cmd);
        }

        // procerss 
        public static DataTable getpassword(int id)
        {
            SqlCommand cmd = new SqlCommand("select u.password from Users.Users u , Users.Seller c where u.Id = c.userid and  c.Id=@id ");
            cmd.Parameters.AddWithValue("@id", id);
            return DBLayer.select(cmd);
        }

        //
        public static int add(string username, string fname, string lname, string email, string id_image, string password)
        {
            //check for userName unique
            SqlCommand cmd = new SqlCommand("insert into Users.Users values(@username,@password,1)");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            if (DBLayer.dml(cmd) == 1)
            { //get id 
                SqlCommand cmdGetId = new SqlCommand("select id from Users.Users where user_name=@username");
                cmdGetId.Parameters.AddWithValue("@username", username);
                DataTable result = DBLayer.select(cmdGetId);
                int user_id = int.Parse(result.Rows[0]["id"].ToString());

                // 1 for user state deactive
                SqlCommand cmdInserToCust = new SqlCommand("insert into Users.Seller values(@userid,@fname,@lname,@email,@idimage,1)");
                cmdInserToCust.Parameters.AddWithValue("@userid", user_id);
                cmdInserToCust.Parameters.AddWithValue("@fname", fname);
                cmdInserToCust.Parameters.AddWithValue("@lname", lname);
                cmdInserToCust.Parameters.AddWithValue("@email", email);

                cmdInserToCust.Parameters.AddWithValue("@idimage", id_image);

                return DBLayer.dml(cmdInserToCust);
            }
            else
            {

                throw new Exception("user name is token try diff one ");
                // return -1 

            }
        }

        public static int update(int id, string fname, string lname, string email, string id_image)
        {
            SqlCommand cmd = new SqlCommand("update Users.Seller set firts_name=@fname,last_name=@lname ,email=@email,id_image= @idimage where id=@id");
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@email", email);

            cmd.Parameters.AddWithValue("@idimage", id_image);
            cmd.Parameters.AddWithValue("@id", id);

            return DBLayer.dml(cmd);

        }

        public static int ChangePassword(int id, string newPass, string old_Password)
        {
            SqlCommand cmd = new SqlCommand("update Users.Users set Password=@pass from Users.Seller c, Users.Users u where c.userid = u.Id  and c.id = @id and u.Password = @old_Password");
            cmd.Parameters.AddWithValue("@pass", newPass);
            cmd.Parameters.AddWithValue("@old_Password", old_Password);

            cmd.Parameters.AddWithValue("@id", id);
            return DBLayer.dml(cmd);


        }


        // udpdate state 
        public static int ChangeState(int id)
        {
            SqlCommand cmd = new SqlCommand("update Users.Seller  set state=1 where id =@id");
            cmd.Parameters.AddWithValue("@id", id);
            return DBLayer.dml(cmd);

        }





    }
}
