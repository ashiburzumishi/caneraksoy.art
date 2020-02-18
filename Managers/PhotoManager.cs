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
                        Like = int.Parse(row["likeCount"].ToString()),
                        Category=row["Detail"].ToString(),
                        artOwner=row["artOwner"].ToString(),
                        ownerMail=row["ownerMail"].ToString(),
                        
                    }
                        );
                }
            return photolist != null && photolist.Count > 0;
        }

        public bool addArt(string Name, string Detail, string Link, string artOwner, string ownerMail, string Category, out Photograph art)
        {
            art = null;
            SqlCommand sendArtCommand = new SqlCommand("addArt");
            sendArtCommand.CommandType = CommandType.StoredProcedure;
            sendArtCommand.Parameters.AddWithValue("Name", Name);
            sendArtCommand.Parameters.AddWithValue("Detail", Detail);
            sendArtCommand.Parameters.AddWithValue("Link", Link);
            sendArtCommand.Parameters.AddWithValue("artOwner", artOwner);
            sendArtCommand.Parameters.AddWithValue("ownerMail", ownerMail);
            sendArtCommand.Parameters.AddWithValue("Category", Category);

            var datatable= SqlManager.SqlManager.GetDataTable(sendArtCommand);

            art = new Photograph
            {
                Name = Name.ToString(),
                Detail = Detail.ToString(),
                Link = Link.ToString(),
                artOwner = artOwner.ToString(),
                ownerMail = ownerMail.ToString(),
                Category = Category.ToString()

            };
            return art != null;
        }
}
}
