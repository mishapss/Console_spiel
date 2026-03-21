using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client; // Тот самый драйвер

namespace TextRpg
{
    public class DatabaseManager
    {
        // Строка подключения: пользователь, пароль и адрес (XEPDB1)
        private string connectionString = "User Id=C##CONSOLE_SPIEL_USER;Password=Oracle123;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));";
        public List<Location> GetLocationsFromDB()
        {
            List<Location> locations = new List<Location>();

            using (OracleConnection con = new OracleConnection(connectionString))
            {
                con.Open();
                // Пишем обычный SQL запрос
                // 1. LOCATION (string) -> Index 0
                // 2. CHANCE_FOR_CHEST (number) -> Index 1
                // 3. MOBS (string) -> Index 2
                // 4. LOCATION_ID (number) -> Index 3

                string sql = "SELECT LOCATION, TO_NUMBER(CHANCE_FOR_CHEST), MOBS, LOCATION_ID FROM locations"; //порядок из конструктора Location должен совпадать с порядком в запросе

                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Создаем объект Location из каждой строки таблицы
                            var loc = new Location(
                                reader.GetString(0),                        //name = LOCATION       
                                Convert.ToInt32(reader.GetValue(1)),        //chestChance = CHANCE_FOR_CHEST       
                                reader.GetString(2),                        //mobs = MOBS
                                Convert.ToInt32(reader.GetValue(3))         //locationID = LOCATION_ID
                            );
                            locations.Add(loc);
                        }
                    }
    }
            }
            return locations;
        }
    }
}