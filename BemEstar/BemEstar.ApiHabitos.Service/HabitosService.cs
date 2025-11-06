using BemEstar.ApiHabitos.Models;
using Npgsql;                       
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BemEstar.ApiHabitos.Service
{
     

    public class HabitosService : BaseService<Habitos>
    {
        private readonly string _connectionString =
            "Host=18.220.9.40; Port=5432;Database=habito;Username=postgres;Password=123456";

        public override void Create(Habitos model)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            string commandText = "INSERT INTO habitos (name, frequencia, meta) VALUES (@name, @frequencia, @meta);";

            NpgsqlCommand insertComand = new NpgsqlCommand(commandText, connection);
            insertComand.Parameters.AddWithValue("name", model.name);
            insertComand.Parameters.AddWithValue("frequencia", model.frequencia);
            insertComand.Parameters.AddWithValue("meta", model.meta);
            insertComand.ExecuteNonQuery();

        }

        public override void Delete(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            string commandText = "DELETE FROM habitos WHERE id = @id";
            NpgsqlCommand deleteComand = new NpgsqlCommand(commandText, connection);
            deleteComand.Parameters.AddWithValue("@id", id);
            deleteComand.ExecuteNonQuery();
        }

        public override List<Habitos> Read()
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            string commandText = "SELECT * FROM habitos";
            NpgsqlCommand selectComand = new NpgsqlCommand(commandText, connection);
            NpgsqlDataReader dataReader = selectComand.ExecuteReader();
            List<Habitos> list = new List<Habitos>();
            while (dataReader.Read())
            {
                Habitos habitos = new Habitos();
                habitos.Id = Convert.ToInt32(dataReader["id"]);
                habitos.Frequencia = dataReader["frequencia"].ToString();
                habitos.Meta = dataReader["meta"].ToString();
                list.Add(habitos);
            }

            connection.Close();
            return List;
        }

        public override Habitos ReadById(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            string commandText = "SELECT * FROM habitos WHERE id = @id";
            NpgsqlCommand selectComand = new NpgsqlCommand(commandText, connection);
            selectComand.Parameters.AddWithValue("@id", id);
            NpgsqlDataReader dataReader = selectComand.ExecuteReader();
            Habitos habitos = new Habitos();
            if (dataReader.Read())
            {
                habitos.Id = Convert.ToInt32(dataReader["id"]);
                habitos.Frequencia = dataReader["frequencia"].ToString();
                habitos.Meta = dataReader["meta"].ToString();
            }

            return habitos;
        }

        public override void Update(Habitos model)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            string commandText = "UPDATE habitos SET name=@name, frequancia=@frequancia, meta@META where id=@id";
            NpgsqlCommand upComand = new NpgsqlCommand(commandText, connection);
            upComand.Parameters.AddWithValue("name", model.Nome);
            upComand.Parameters.AddWithValue("frequencia", model.Frequencia);
            upComand.Parameters.AddWithValue("meta", model.Meta);

            upComand.ExecuteNonQuery();
        }
    }
}
