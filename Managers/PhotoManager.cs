using Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;



namespace Managers
{
    public class PhotoManager
    {
        public bool addphoto(string Name, string Detail, string Link, out Photograph photograph)
        {
            photograph = null;
            SqlCommand sqlCommand = new SqlCommand("addphotos");
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Name", Name);
            sqlCommand.Parameters.AddWithValue("@Detail", Detail);
            sqlCommand.Parameters.AddWithValue("@Link", Link);

            var DataTable = SqlManager.SqlManager.GetDataTable(sqlCommand);
            photograph = new Photograph
            {
                Name = Name.ToString(),
                Detail = Detail.ToString(),
                Link = Link.ToString(),
            };

            return photograph != null;
    }

        public bool photos(out List<Photograph> photolist)
        {
            photolist = new List<Photograph>();
            SqlCommand command = new SqlCommand("Select * From photographs");
            var datatable = SqlManager.SqlManager.GetDataTable(command);
            
            if(datatable!=null)
                foreach (DataRow row in datatable.Rows)
                {
                    photolist.Add(new Photograph
                    {
                        Link = row["Link"].ToString(),
                        Id = int.Parse(row["Id"].ToString()),
                        Name = row["Name"].ToString(),
                    }
                        );
                }
            return photolist != null && photolist.Count > 0;
        }
}
}
