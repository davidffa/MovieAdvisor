﻿using System.Data.SqlClient;

namespace MovieAdvisor
{
    internal class TVSeries : AudiovisualContent
    {
        public static TVSeries FromReader(SqlDataReader reader)
        {
            TVSeries m = new TVSeries();

            m.ID = reader["ID"].ToString();
            m.Title = reader["Title"].ToString();
            m.Synopsis = reader["Synopsis"].ToString();
            m.TrailerURL = reader["TrailerURL"].ToString();
            m.Budget = reader["Budget"].ToString();
            m.Revenue = reader["Revenue"].ToString();
            m.Photo = reader["Photo"].ToString();
            m.AgeRate = reader["AgeRate"].ToString();
            m.ReleaseDate = reader["ReleaseDate"].ToString();
            m.FinishDate = reader["FinishDate"].ToString();
            m.State = reader["State"].ToString();

            return m;
        }

        private String _id;
        private String _state;
        private String _finishDate;

        public String ID { get => _id; set => _id = value; }
        public String State { get => _state; set => _state = value; }
        public String FinishDate { get => _finishDate; set => _finishDate = value; }
    }
}
