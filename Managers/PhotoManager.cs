using Entities;

using System.Data.SqlClient;



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
}
}
