using MySql.Data.MySqlClient;
using System.Data;

namespace B21leowa_DOTNet.Models
{
    public class ChildRelationModel
    {
        private IConfiguration _configuration;
        private string _connectionString;
        
        public ChildRelationModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllChildRelation()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM barnRelation;", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable childRelationTable = ds.Tables["result"];
            connection.Close();
            return childRelationTable != null ? childRelationTable : new DataTable();
        }

        public void InsertChildRelation(string PNR1, string name1, string PNR2, string name2, string typeOfRelation) 
        {
            if(PNR1 != PNR2 && name1 != name2)
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                string insertChildRelation = "INSERT INTO barnRelation(PNR1, namn1, PNR2, namn2, typAvRelation) VALUES (@PNR1, @namn1, @PNR2, @namn2, @typeOfRelation);";
                MySqlCommand sqlCmd = new MySqlCommand(insertChildRelation, connection);
                sqlCmd.Parameters.AddWithValue("@PNR1", PNR1);
                sqlCmd.Parameters.AddWithValue("@name1", name1);
                sqlCmd.Parameters.AddWithValue("@PNR2", PNR2);
                sqlCmd.Parameters.AddWithValue("@namn2", name2);
                sqlCmd.Parameters.AddWithValue("@typeOfRelation", typeOfRelation);
                int rows = sqlCmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
