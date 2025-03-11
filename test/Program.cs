using MySql.Data.MySqlClient;

class Program {
    public static void Main(string[] args) {
        MySqlConnection conn = new MySqlConnection("User Id=root;Host=localhost;Database=ensat;password=saidaelm");
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand();
        cmd.Connection = conn;
        /* cmd.CommandText = "insert into eleve(nom,prenom,ville,specialite) " +
             "values('ALAMI','Ramadan','Tanger','Informatique')";
         cmd.ExecuteNonQuery();*/
        cmd.CommandText = "select * from eleve";
        MySqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
            Console.WriteLine(dr.GetInt32(0) + " " + dr["nom"] + " " + dr.GetString(2) + " " + dr["ville"] + " " + dr["specialite"]);



    }


}